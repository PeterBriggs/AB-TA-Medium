using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

/*
* Test harness for the DNA sequence analysis program.
* Contains automated tests to verify the correctness of the sequence counting algorithms.
*/
class UnitTests
{
    static void Main(string[] args)
    {
        Console.WriteLine("Running automated tests for DNA sequence analysis...");
        Console.WriteLine("=================================================");

        RunAllTests();

        Console.WriteLine("=================================================");
        Console.WriteLine($"Test summary: {_passCount} passed, {_failCount} failed");
    }

    private static int _passCount = 0;
    private static int _failCount = 0;

    /*
    * Runs all test cases for the DNA sequence analysis program.
    */
    static void RunAllTests()
    {
        // Test case 1
        TestCase("AGC", "AGCAGC", 2, 4, 2, "Simple exact matches");

        // Test case 2
        TestCase("AAA", "AAAAA", 3, 4, 2, "Overlapping matches");

        // Test case 3: Edge case - search longer than target
        TestCase("AGCT", "AGC", 0, 1, 0, "Search longer than target");

        // Test case 4: Problem Example from sample input/output
        TestMultipleSequences(
            new List<(string search, string target)> {
                ("AGCT", "AGCTAGCT"),
                ("AAA", "AAAAAAAAAA"),
                ("AGC", "TTTTGT")
            },
            new List<(int type1, int type2, int type3)> {
                (2, 4, 2),
                (8, 9, 7),
                (0, 0, 0)
            },
            "Sample Input/Output Example"
        );
    }

    /*
    * Tests a single case and reports the results.
    * @param search The search sequence
    * @param target The target sequence
    * @param expectedType1 Expected count for Type 1
    * @param expectedType2 Expected count for Type 2
    * @param expectedType3 Expected count for Type 3
    * @param testName Name of the test for reporting
    */
    static void TestCase(string search, string target, int expectedType1, int expectedType2, int expectedType3, string testName)
    {
        try {
            // Arrange
            Console.WriteLine($"Test: {testName}");
            Console.WriteLine($"  Search: \"{search}\", Target: \"{target}\"");

            // Act
            int type1Count = Program.CountType1(search, target);
            int type2Count = Program.CountType2(search, target);
            int type3Count = Program.CountType3(search, target);

            // Assert
            bool success = type1Count == expectedType1 &&
                        type2Count == expectedType2 &&
                        type3Count == expectedType3;

            Console.WriteLine($"  Expected: [{expectedType1}, {expectedType2}, {expectedType3}]");
            Console.WriteLine($"  Actual:   [{type1Count}, {type2Count}, {type3Count}]");
            Console.WriteLine($"  Result:   {(success ? "PASS" : "FAIL")}");
            Console.WriteLine();

            if (success) _passCount++; else _failCount++;
        }
        catch (Exception ex) {
            Console.WriteLine($"Test: {testName} - ERROR");
            Console.WriteLine($"  Exception: {ex.Message}");
            Console.WriteLine();
            _failCount++;
        }
    }

    /*
    * Tests a multi-sequence case that matches the actual problem input/output format.
    * @param sequences List of search and target sequence pairs
    * @param expected List of expected results for each sequence pair
    * @param testName Name of the test for reporting
    */
    static void TestMultipleSequences(
        List<(string search, string target)> sequences,
        List<(int type1, int type2, int type3)> expected,
        string testName)
    {
        Console.WriteLine($"Test: {testName}");
        Console.WriteLine("  Processing multiple sequence pairs:");

        bool allPassed = true;
        int pairsCount = 0;

        for (int i = 0; i < sequences.Count; i++)
        {
            try {
                // Arrange
                var (search, target) = sequences[i];
                var (expectedType1, expectedType2, expectedType3) = expected[i];

                // Act
                int type1Count = Program.CountType1(search, target);
                int type2Count = Program.CountType2(search, target);
                int type3Count = Program.CountType3(search, target);

                // Assert
                bool pairSuccess = type1Count == expectedType1 &&
                                type2Count == expectedType2 &&
                                type3Count == expectedType3;

                Console.WriteLine($"  Pair {i+1}:");
                Console.WriteLine($"    Search: \"{search}\", Target: \"{target}\"");
                Console.WriteLine($"    Expected: [{expectedType1}, {expectedType2}, {expectedType3}]");
                Console.WriteLine($"    Actual:   [{type1Count}, {type2Count}, {type3Count}]");
                Console.WriteLine($"    Result:   {(pairSuccess ? "PASS" : "FAIL")}");

                if (!pairSuccess) allPassed = false;
                pairsCount++;
            }
            catch (Exception ex) {
                Console.WriteLine($"  Pair {i+1} - ERROR:");
                Console.WriteLine($"    Search: \"{sequences[i].search}\", Target: \"{sequences[i].target}\"");
                Console.WriteLine($"    Exception: {ex.Message}");
                allPassed = false;
            }
        }

        Console.WriteLine($"  Overall result: {(allPassed ? "PASS" : "FAIL")}");
        Console.WriteLine();

        if (allPassed) _passCount++; else _failCount++;
    }
}
