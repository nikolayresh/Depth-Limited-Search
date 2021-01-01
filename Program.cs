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
            var solution = SearchDLS.Solve(new Problem(), maxDepth);

            Console.WriteLine($"Depth Limit: {maxDepth}");
            Console.WriteLine($"Is Solved: {solution.Solved}");
            Console.WriteLine($"Cut Off: {solution.CutOff}");

            if (solution.Solved)
            {
                Console.WriteLine();
                if (solution.FinalState != null)
                {
                    Console.WriteLine("Final State:");
                    Console.WriteLine(solution.FinalState);
                    Console.WriteLine();
                }


                Console.WriteLine("Steps:");
                int i = 0;
                foreach (var action in solution.Actions)
                {
                    Console.WriteLine($"({++i}) {action.CommandText}");
                }
            }

            Console.ReadLine();
        }
    }
}
