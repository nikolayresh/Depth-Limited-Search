using System.Collections.Generic;

namespace UninformedSearch.Task.Logic
{
    public static class SearchDLS
    {
        /// <summary>
        /// Solves a problem using Depth Limited Search algorithm
        /// </summary>
        public static SolutionResult Solve(Problem problem, int maxDepth)
        {
            var root = new Node(problem.GetInitialState());
            var goalPredicate = problem.GetGoalPredicate();

            if (goalPredicate(root.State))
            {
                return new SolutionResult(true, false, root.GetActionsChain());
            }

            var stack = new Stack<Node>();
            stack.Push(root);

            while (stack.Count != 0)
            {
                var node = stack.Pop();

                if (node.GetDepth() > maxDepth)
                {
                    return new SolutionResult(false, true);
                }

                if (goalPredicate(node.State))
                {
                    return new SolutionResult(true, false, node.GetActionsChain(), node.State);
                }

                foreach (var nextNode in NodeExpander.Expand(node, problem))
                {
                    if (nextNode.GetDepth() <= maxDepth && goalPredicate(nextNode.State))
                    {
                        // return node immediately
                        return new SolutionResult(true, false, nextNode.GetActionsChain(), nextNode.State);
                    }

                    stack.Push(nextNode);
                }
            }

            // FAILURE, solution was not found
            return new SolutionResult(false, false);
        }
    }
}