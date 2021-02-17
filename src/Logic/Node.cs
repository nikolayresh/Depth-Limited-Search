using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UninformedSearch.Task.Logic
{
    /// <summary>
    /// Class that defines a single node with its state
    /// </summary>
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
        /// Returns state of the board
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
        /// Returns action to apply
        /// </summary>
        public Action Action
        {
            get;
        }

        /// <summary>
        /// Returns a boolean value whether this node is the root node (has no parent node)
        /// </summary>
        public bool IsRoot()
        {
            return Parent == null;
        }

        /// <summary>
        /// Gets sequence of actions from this node up to the root node
        /// </summary>
        public ReadOnlyCollection<Action> GetActionsChain()
        {
            List<Action> chain = new List<Action>();
            Node current = this;

            while (true)
            {
                chain.Insert(0, current.Action);

                if (current.IsRoot())
                {
                    break;
                }

                current = current.Parent;
            }

            chain.RemoveAll(x => x == null);
            return chain.AsReadOnly();
        }

        /// <summary>
        /// Gets depth of this node
        /// </summary>
        public int GetDepth()
        {
            var depth = 0;
            var node = Parent;

            while (node != null)
            {
                depth++;
                node = node.Parent;
            }

            return depth;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var otherNode = (Node) obj;

            return
                Equals(State, otherNode.State) &&
                Equals(Parent, otherNode.Parent) &&
                Equals(Action, otherNode.Action);
        }

        public override int GetHashCode()
        {
            return HashUtility.GetHashCode(State, Parent, Action);
        }
    }
}