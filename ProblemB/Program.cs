using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<SequenceResult> results = new List<SequenceResult>();

        while (true)
        {
            string input = Console.ReadLine() ?? "";
            if (input == "0") break;

            SequenceResult result = ProcessSequence(input);
            results.Add(result);
        }

        // Output all results at the end
        foreach (var result in results)
        {
            Console.WriteLine($"{result.Type1Count} {result.Type2Count} {result.Type3Count}");
        }
    }

    /*
    * Processes a single sequence pair and outputs the results.
    * Calculates Type 1, Type 2, and Type 3 matches as defined in the problem.
    * @param input The input string containing search sequence and target sequence
    */
    static void ProcessSequence(string input)
    {
        string[] parts = input.Split(' ');
        string searchSequence = parts[0];
        string targetSequence = parts[1];

        return new SequenceResult
        {
           //TODO
        };
    }
}

// Class to store the results for a sequence pair
class SequenceResult
{
    public int Type1Count { get; set; }
    public int Type2Count { get; set; }
    public int Type3Count { get; set; }
}
