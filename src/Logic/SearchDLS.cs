using System.Collections.Generic;

namespace UninformedSearch.Task.Logic
{
    public static class SearchDLS
    {
        /// <summary>
        /// Solves a problem using Depth Limited Search algorithm
        /// </summary>
        public static SearchResult ExecuteSearch(Problem problem, int maxDepth)
        {
            var root = new Node(problem.GetInitialState());

            if (problem.IsGoalState(root.State))
            {
                return new SearchResult(true, false, root.GetActionsChain());
            }

            var stack = new Stack<Node>();
            stack.Push(root);

            while (stack.Count != 0)
            {
                var node = stack.Pop();

                if (node.GetDepth() > maxDepth)
                {
                    // result is unknown
                    // as maximal level of depth is too low
                    return new SearchResult(null, true);
                }

                if (problem.IsGoalState(node.State))
                {
                    return new SearchResult(true, false, node.GetActionsChain(), node.State);
                }

                foreach (var nextNode in NodeExpander.Expand(node, problem))
                {
                    if (nextNode.GetDepth() <= maxDepth && problem.IsGoalState(nextNode.State))
                    {
                        // return result immediately
                        return new SearchResult(true, false, nextNode.GetActionsChain(), nextNode.State);
                    }

                    stack.Push(nextNode);
                }
            }

            // FAILURE, solution nodes were not found
            return new SearchResult(false, false);
        }
    }
}