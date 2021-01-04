﻿using System;
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
            var solution = SearchDLS.Solve(problem, maxDepth);

            Console.WriteLine($"Depth Limit: {maxDepth}");
            Console.WriteLine($"Has Solution: {solution.HasSolution}");
            Console.WriteLine($"Is Cut-Off: {solution.IsCutOff}");

            if (solution.HasSolution)
            {
                Console.WriteLine();
                Console.WriteLine("Initial State:");
                Console.WriteLine(problem.GetInitialState());

                if (solution.FinalState != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Final State:");
                    Console.WriteLine(solution.FinalState);
                    Console.WriteLine();
                }

                int i = 0;
                Console.WriteLine("Steps to Solution:");
                foreach (var action in solution.Actions)
                {
                    Console.WriteLine($"({++i}) {action.CommandText}");
                }
            }

            Console.ReadLine();
        }
    }
}
