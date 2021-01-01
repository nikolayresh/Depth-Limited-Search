using System;
using System.Collections.Generic;

namespace UninformedSearch.Task.Logic
{
    public sealed class Problem
    {
        private static readonly BoardState GoalState;

        private readonly BoardState _initialState;
        private readonly Predicate<BoardState> _goalPredicate;
        private readonly Func<BoardState, HashSet<Action>> _actionsFunction;
        private readonly Func<BoardState, Action, BoardState> _resultFunction;

        static Problem()
        {
            GoalState = new BoardState
            {
                Slots = new Slot[BoardState.SlotsCount]
            };

            for (var i = 0; i < BoardState.SlotsCount; i++)
            {
                var slot = new Slot();
                GoalState.Slots[i] = slot;

                if (i == BoardState.WhiteBalls)
                {
                    continue;
                }

                slot.SetBall((i < BoardState.WhiteBalls)
                      ? new Ball(i + 1, Color.White) 
                      : new Ball(i - 3, Color.Black));
            }
        }

        public Problem()
        {
            _initialState = new BoardState().Initialize();
            _goalPredicate = state => Equals(state, GoalState);
            _actionsFunction = state =>
            {
                var actions = new HashSet<Action>();
                var emptyPos = 0;

                while (emptyPos < state.Slots.Length)
                {
                    var slot = state.Slots[emptyPos];

                    if (slot.IsEmpty())
                    {
                        break;
                    }

                    emptyPos++;
                }

                if (state.IsBlackBallAt(emptyPos - 1))
                {
                    actions.Add(new Action
                    {
                        BallToRelocate = state.Slots[emptyPos - 1].GetBall(),
                        Direction = MoveDirection.ToRight,
                        SourcePosition = emptyPos - 1,
                        TargetPosition = emptyPos
                    });
                }

                if (state.IsBlackBallAt(emptyPos - 2))
                {
                    actions.Add(new Action
                    {
                        BallToRelocate = state.Slots[emptyPos - 2].GetBall(),
                        Direction = MoveDirection.ToRightWithJump,
                        SourcePosition = emptyPos - 2,
                        TargetPosition = emptyPos
                    });
                }

                if (state.IsWhiteBallAt(emptyPos + 1))
                {
                    actions.Add(new Action
                    {
                        BallToRelocate = state.Slots[emptyPos + 1].GetBall(),
                        Direction = MoveDirection.ToLeft,
                        SourcePosition = emptyPos + 1,
                        TargetPosition = emptyPos
                    });
                }

                if (state.IsWhiteBallAt(emptyPos + 2))
                {
                    actions.Add(new Action
                    {
                        BallToRelocate = state.Slots[emptyPos + 2].GetBall(),
                        Direction = MoveDirection.ToLeftWithJump,
                        SourcePosition = emptyPos + 2,
                        TargetPosition = emptyPos
                    });
                }

                return actions;
            };
            _resultFunction = (state, action) =>
            {
                var nextState = new BoardState(state);
                nextState.MoveBall(action);
                return nextState;
            };
        }

        public BoardState GetInitialState()
        {
            return _initialState;
        }

        public Predicate<BoardState> GetGoalPredicate()
        {
            return _goalPredicate;
        }

        public Func<BoardState,HashSet<Action>> GetActionsFunction()
        {
            return _actionsFunction;
        }

        public Func<BoardState, Action, BoardState> GetResultFunction()
        {
            return _resultFunction;
        }
    }
}