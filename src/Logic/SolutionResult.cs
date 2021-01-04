﻿using System.Collections.ObjectModel;

namespace UninformedSearch.Task.Logic
{
    /// <summary>
    /// Class that defines solution's result of a problem
    /// </summary>
    public sealed class SolutionResult
    {
        public SolutionResult(bool? hasSolution, bool isCutOff, ReadOnlyCollection<Action> actions = null, BoardState finalState = null)
        {
            HasSolution = hasSolution;
            IsCutOff = isCutOff;
            Actions = actions;
            FinalState = finalState;
        }

        /// <summary>
        /// Returns a boolean value whether a problem has solution
        /// </summary>
        public bool? HasSolution
        {
            get;
        }

        /// <summary>
        /// Returns a boolean value whether solution failed
        /// due to a low depth limit of search
        /// </summary>
        public bool IsCutOff
        {
            get;
        }

        /// <summary>
        /// Returns a sequence of actions that solved a problem
        /// </summary>
        public ReadOnlyCollection<Action> Actions
        {
            get;
        }

        /// <summary>
        /// Returns final state of the board
        /// </summary>
        public BoardState FinalState
        {
            get;
        }
    }
}
