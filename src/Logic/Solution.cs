using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace UninformedSearch.Task.Logic
{
    /// <summary>
    /// Class that defines solution's result of a problem
    /// </summary>
    public sealed class Solution
    {
        public Solution(bool solved, bool cutOff, ReadOnlyCollection<Action> actions = null, BoardState finalState = null)
        {
            Solved = solved;
            CutOff = cutOff;
            Actions = actions;
            FinalState = finalState;
        }

        /// <summary>
        /// Returns a boolean value whether a problem was solved
        /// </summary>
        public bool Solved
        {
            get;
        }

        /// <summary>
        /// Returns a boolean value whether solution failed
        /// due to a low depth limit of search
        /// </summary>
        public bool CutOff
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
        /// Returns final state of a board
        /// </summary>
        public BoardState FinalState
        {
            get;
        }
    }
}
