using System;
using UninformedSearch.Task.Logic;

namespace UninformedSearch.Task
{
    internal sealed class Program
    {
        internal static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            const int maxDepth = 19;
            var problem = new Problem();
            var sr = SearchDLS.ExecuteSearch(problem, maxDepth);

            Console.WriteLine($"Depth Limit: {maxDepth}");
            Console.WriteLine($"Has Solution: {HasSolutionText(sr.HasSolution)}");
            Console.WriteLine($"Is Cut-Off: {sr.IsCutOff}");

            if (sr.HasSolution != null && sr.HasSolution.Value)
            {
                Console.WriteLine();
                Console.WriteLine("Initial State:");
                Console.WriteLine(problem.GetInitialState());

                if (sr.FinalState != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Final State:");
                    Console.WriteLine(sr.FinalState);
                    Console.WriteLine();
                }

                var i = 0;
                Console.WriteLine("Steps to Solution:");
                foreach (var action in sr.Actions)
                {
                    Console.WriteLine($"({++i}) {action.CommandText}");
                }
            }

            Console.ReadLine();
        }

        private static string HasSolutionText(bool? flag)
        {
            return !flag.HasValue 
                ? "Unknown" 
                : flag.Value.ToString();
        }
    }
}