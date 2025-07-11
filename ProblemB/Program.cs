﻿using System;
using System.Collections.Generic;

namespace ProblemB // Make sure this namespace matches what you're using in tests
{
    public class Program // Class must be public
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

            foreach (var result in results)
            {
                Console.WriteLine($"{result.Type1Count} {result.Type2Count} {result.Type3Count}");
            }
        }

        /*
        * Processes a single sequence pair and returns the results.
        * Calculates Type 1, Type 2, and Type 3 matches as defined in the problem.
        * @param input The input string containing search sequence and target sequence
        * @return The sequence result containing count information
        */
        static SequenceResult ProcessSequence(string input)
        {
            string[] parts = input.Split(' ');
            string searchSequence = parts[0];
            string targetSequence = parts[1];

            int type1Count = CountType1(searchSequence, targetSequence);
            int type2Count = CountType2(searchSequence, targetSequence);
            int type3Count = CountType3(searchSequence, targetSequence);

            return new SequenceResult
            {
                Type1Count = type1Count,
                Type2Count = type2Count,
                Type3Count = type3Count,
            };
        }

        /*
        * Counts Type 1 matches between search and target sequences.
        * Type 1 matches are exact occurrences of the search sequence in the target sequence.
        * @param searchSequence The sequence to search for (e.g., "AGC")
        * @param targetSequence The sequence to search within (e.g., "AGCTAGCAAGC")
        * @return The number of times the search sequence appears exactly in the target sequence
        */
        public static int CountType1(string searchSequence, string targetSequence)
        {
            return CountSubstring(searchSequence, targetSequence);
        }

        /*
        * Counts Type 2 matches between search and target sequences.
        * Type 2 matches are occurrences where one character is deleted from the search sequence.
        * @param searchSequence The sequence to search for (e.g., "AGC")
        * @param targetSequence The sequence to search within (e.g., "AGCTAGCAAGC")
        * @return The number of times the modified search sequences appear in the target sequence
        */
        public static int CountType2(string searchSequence, string targetSequence)
        {
            HashSet<string> uniqueDeletionVariants = new HashSet<string>();

            for (int deletePosition = 0; deletePosition < searchSequence.Length; deletePosition++)
            {
                string variantWithDeletion = searchSequence.Substring(0, deletePosition) + searchSequence.Substring(deletePosition + 1);
                uniqueDeletionVariants.Add(variantWithDeletion);
            }

            int totalOccurrences = 0;
            foreach (string deletionVariant in uniqueDeletionVariants)
            {
                totalOccurrences += CountSubstring(deletionVariant, targetSequence);
            }

            return totalOccurrences;
        }

        public static int CountType3(string searchSequence, string targetSequence)
        {
            HashSet<string> uniqueInsertionVariants = new HashSet<string>();
            char[] validCharacters = { 'A', 'G', 'C', 'T' };

            // Generate all strings by inserting one character at each position
            for (int insertPosition = 0; insertPosition <= searchSequence.Length; insertPosition++)
            {
                foreach (char character in validCharacters)
                {
                    string variantWithInsertion = searchSequence.Substring(0, insertPosition) + character + searchSequence.Substring(insertPosition);
                    uniqueInsertionVariants.Add(variantWithInsertion);
                }
            }

            int totalOccurrences = 0;
            foreach (string insertionVariant in uniqueInsertionVariants)
            {
                totalOccurrences += CountSubstring(insertionVariant, targetSequence);
            }

            return totalOccurrences;
        }

        /*
        * Counts occurrences of a substring within a string.
        * @param searchSequence The substring to search for
        * @param targetSequence The main string to search within
        * @return The number of occurrences
        */
        static int CountSubstring(string searchSequence, string targetSequence)
        {
            if (searchSequence.Length > targetSequence.Length)
                return 0;

            int count = 0;

            for (int i = 0; i <= targetSequence.Length - searchSequence.Length; i++)
            {
                bool match = true;
                for (int j = 0; j < searchSequence.Length; j++)
                {
                    if (targetSequence[i + j] != searchSequence[j])
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                    count++;
            }
            return count;
        }
    }

    /*
    * Class to store the match counts for a sequence pair analysis.
    * Contains the results of Type 1, Type 2, and Type 3 matches
    * between a search sequence and target sequence.
    */
    class SequenceResult
    {
        /*
        * Number of Type 1 matches found.
        * Type 1 matches are exact occurrences of the search sequence in the target sequence.
        */
        public int Type1Count { get; set; }

        /*
        * Number of Type 2 matches found.
        * Type 2 matches are occurrences where the search sequence with one character deleted is found in the target sequence.
        */
        public int Type2Count { get; set; }
        /*
        * Number of Type 3 matches found.
        * Type 3 matches are occurrences where the search sequence with one character inserted is found in the target sequence.
        */
        public int Type3Count { get; set; }
    }
}
