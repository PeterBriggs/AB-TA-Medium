# 🔬 AB-TA-Medium: Search String Pattern Matching

This project was created as part of a technical assessment and solves a pattern matching problem involving a search string and a target string. The goal is to count how many times the search string appears in the target under three conditions.

---

## 📋 Problem Summary

For each pair of strings:

- **Type 1**: Count exact matches of the search string in the target.
- **Type 2**: Count matches for all unique one-character deletions of the search string.
- **Type 3**: Count matches for all unique one-character insertions into the search string.

---

## 💡 Solution Overview

The logic is broken down into clean, separate methods for each match type. `HashSet<string>` is used to ensure unique variants for Types 2 and 3, and a reusable substring counting method handles the match checking. The program reads multiple test cases from standard input and outputs the three counts per line.

---

## 🚀 How to Run

### Using .NET CLI

1. Open a terminal and navigate to the project folder.
2. Build the program:
   ```bash
   dotnet build
   ```
3. Run the program:
   ```bash
   dotnet run --project ProblemB\ProblemB.csproj
   ```

You will be prompted to enter the input manually. End the input with a line containing just `0`.

---

## ✅ Running the Tests

To execute the included unit tests:

1. Ensure you are in the root directory of the project.
2. Run the following command:
   ```bash
   dotnet test
   ```

This will build and run all tests located in the `UnitTests.cs` file. Each test validates different match scenarios to ensure correctness across Types 1, 2, and 3.

---
