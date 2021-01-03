using System.Collections.Generic;

namespace UninformedSearch.Task.Logic
{
    public static class NodeExpander
    {
        public static List<Node> Expand(Node node, Problem problem)
        {
            var expandNodes = new List<Node>();
            var actionsFn = problem.GetActionsFunction();
            var resultFn = problem.GetResultFunction();

            foreach (var action in actionsFn(node.State))
            {
                var nextState = resultFn(node.State, action);
                expandNodes.Add(CreateNode(nextState, node, action));
            }

            return expandNodes;
        }

        private static Node CreateNode(BoardState state, Node parent, Action action)
        {
            return new Node(state, parent, action);
        }
    }
}