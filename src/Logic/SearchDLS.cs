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

            if (problem.IsGoalState(root.State))
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
                    // result is unknown
                    // as level of depth is low
                    return new SolutionResult(null, true);
                }

                if (problem.IsGoalState(node.State))
                {
                    return new SolutionResult(true, false, node.GetActionsChain(), node.State);
                }

                foreach (var nextNode in NodeExpander.Expand(node, problem))
                {
                    if (nextNode.GetDepth() <= maxDepth && problem.IsGoalState(nextNode.State))
                    {
                        // return result immediately
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