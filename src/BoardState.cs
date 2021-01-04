using System.Text;
using UninformedSearch.Task.Logic;

namespace UninformedSearch.Task
{
    /// <summary>
    /// State of the board with balls
    /// </summary>
    public sealed class BoardState
    {
        public const int BlackBalls = 4;
        public const int WhiteBalls = 3;
        public const int SlotsCount = BlackBalls + 1 + WhiteBalls;

        public BoardState()
        {
        }

        public BoardState(BoardState state)
        {
            Slots = new Slot[state.Slots.Length];

            for (var i = 0; i < Slots.Length; i++)
            {
                Slots[i] = state.Slots[i].Clone();
            }
        }

        public Slot[] Slots
        {
            get;
            set;
        }

        public BoardState Initialize()
        {
           Slots = new Slot[SlotsCount];

           for (var i = 0; i < SlotsCount; i++)
           {
               var slot = new Slot();
               Slots[i] = slot;

               if (i == BlackBalls)
               {
                   continue;
               }

               slot.SetBall((i < BlackBalls) 
                   ? new Ball(i + 1, Color.Black) 
                   : new Ball(i - 4, Color.White));
           }

           return this;
        }

        /// <summary>
        /// Returns a boolean value whether a slot
        /// at specified position contains a BLACK ball
        /// </summary>
        public bool IsBlackBallAt(int pos)
        {
            return 
                pos >= 0 &&
                pos < SlotsCount &&
                Slots[pos].GetBall() != null &&
                Slots[pos].GetBall().Color == Color.Black;
        }

        /// <summary>
        /// Returns a boolean value whether a slot
        /// at specified position contains a WHITE ball
        /// </summary>
        public bool IsWhiteBallAt(int pos)
        {
            return 
                pos >= 0 &&
                pos < SlotsCount &&
                Slots[pos].GetBall() != null &&
                Slots[pos].GetBall().Color == Color.White;
        }

        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var otherState = (BoardState) obj;

            if (Slots.Length != otherState.Slots.Length)
            {
                return false;
            }

            for (int i = 0; i < SlotsCount; i++)
            {
                var thisSlot = Slots[i];
                var otherSlot = otherState.Slots[i];

                if (!Equals(thisSlot, otherSlot))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Moves a ball from source position to target position specified by action
        /// </summary>
        public void MoveBall(Action action)
        {
            var ball = Slots[action.SourcePosition].GetBall();
            Slots[action.TargetPosition].SetBall(ball);
            Slots[action.SourcePosition].SetEmpty();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("[");

            for (var i = 0; i < Slots.Length; i++)
            {
                var slot = Slots[i];

                sb.Append(!slot.IsEmpty() ? slot.GetBall().Name : "<empty>");

                if (i + 1 != Slots.Length)
                {
                    sb.Append(", ");
                }
            }

            sb.Append("]");
            return sb.ToString();
        }
    }
}