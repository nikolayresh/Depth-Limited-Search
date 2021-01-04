using System.Collections.Generic;

namespace UninformedSearch.Task.Logic
{
    /// <summary>
    /// Class used to append successors to a specified node if applicable
    /// </summary>
    public static class NodeExpander
    {
        public static List<Node> Expand(Node node, Problem problem)
        {
            var successors = new List<Node>();
            var actionsFn = problem.GetActionsFunction();
            var resultFn = problem.GetResultFunction();

            foreach (var action in actionsFn(node.State))
            {
                var nextState = resultFn(node.State, action);
                successors.Add(CreateNode(nextState, node, action));
            }

            return successors;
        }

        private static Node CreateNode(BoardState state, Node parent, Action action)
        {
            return new Node(state, parent, action);
        }
    }
}