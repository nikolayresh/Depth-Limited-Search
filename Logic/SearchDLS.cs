using System.Collections.Generic;

namespace UninformedSearch.Task.Logic
{
    public static class SearchDLS
    {
        /// <summary>
        /// Solves a problem using Depth Limited Search algorithm
        /// </summary>
        public static Solution Solve(Problem problem, int maxDepth)
        {
            var root = new Node(problem.GetInitialState());
            var goalPredicate = problem.GetGoalPredicate();

            if (goalPredicate(root.State))
            {
                return new Solution(true, false, root.GetActionsChain());
            }

            var stack = new Stack<Node>();
            stack.Push(root);

            while (stack.Count != 0)
            {
                var node = stack.Pop();

                if (node.GetDepth() > maxDepth)
                {
                    return new Solution(false, true);
                }

                if (goalPredicate(node.State))
                {
                    return new Solution(true, false, node.GetActionsChain(), node.State);
                }

                foreach (var nextNode in NodeExpander.Expand(node, problem))
                {
                    stack.Push(nextNode);
                }
            }

            // FAILURE, solution was not found
            return new Solution(false, false);
        }
    }
}