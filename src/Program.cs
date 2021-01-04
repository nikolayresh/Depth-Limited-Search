using System;
using UninformedSearch.Task.Logic;

namespace UninformedSearch.Task
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            var maxDepth = 19;
            var problem = new Problem();
            var solutionResult = SearchDLS.Solve(problem, maxDepth);

            Console.WriteLine($"Depth Limit: {maxDepth}");
            Console.WriteLine($"Has Solution: {solutionResult.HasSolution}");
            Console.WriteLine($"Is Cut-Off: {solutionResult.IsCutOff}");

            if (solutionResult.HasSolution)
            {
                Console.WriteLine();
                Console.WriteLine("Initial State:");
                Console.WriteLine(problem.GetInitialState());

                if (solutionResult.FinalState != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Final State:");
                    Console.WriteLine(solutionResult.FinalState);
                    Console.WriteLine();
                }

                int i = 0;
                Console.WriteLine("Steps to Solution:");
                foreach (var action in solutionResult.Actions)
                {
                    Console.WriteLine($"({++i}) {action.CommandText}");
                }
            }

            Console.ReadLine();
        }
    }
}
