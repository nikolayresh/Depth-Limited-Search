using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UninformedSearch.Task.Logic
{
    public sealed class Node
    {
        public Node(BoardState state)
        {
            State = state;
            Parent = default;
        }

        public Node(BoardState state, Node parent, Action action)
        {
            State = state;
            Parent = parent;
            Action = action;
        }

        /// <summary>
        /// Returns state of a board
        /// </summary>
        public BoardState State
        {
            get;
        }

        /// <summary>
        /// Returns a parent node
        /// </summary>
        public Node Parent
        {
            get;
        }

        /// <summary>
        /// Returns action
        /// </summary>
        public Action Action
        {
            get;
        }

        public bool IsRoot()
        {
            return (Parent is null);
        }

        public ReadOnlyCollection<Action> GetActionsChain()
        {
            var chain = new List<Action>();
            var current = this;

            while (true)
            {
                chain.Insert(0, current.Action);

                if (current.IsRoot())
                {
                    break;
                }

                current = current.Parent;
            }

            chain.RemoveAll(x => x is null);
            return chain.AsReadOnly();
        }

        public int GetDepth()
        {
            var depth = 0;
            var parent = Parent;

            while (parent != null)
            {
                depth++;
                parent = parent.Parent;
            }

            return depth;
        }
    }
}