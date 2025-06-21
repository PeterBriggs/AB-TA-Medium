# Sequence Match Counter – C# Technical Assessment

This is a C# console application developed as part of a technical assessment for a Senior Developer position at Agile Bridge.

## 🧠 Problem Description

Given a series of DNA sequence test cases, each consisting of a **search sequence** and a **target sequence**, the goal is to determine how many times variants of the search sequence appear in the target.

There are three types of matches:

- **Type 1 (Exact Match)**: The search sequence appears exactly as-is.
- **Type 2 (Single Deletion Match)**: A version of the search sequence with one character removed appears.
- **Type 3 (Single Insertion Match)**: A version of the search sequence with one additional character (A, G, C, or T) inserted appears.

### 📥 Input Format

- Each line contains two strings: the search sequence and the target sequence.
- Input ends when a line containing only `0` is encountered.

### 📤 Output Format

- For each test case, output three integers separated by spaces:
  ```
  <Type1Count> <Type2Count> <Type3Count>
  ```

### ✅ Example

**Input:**

```
AGC AGCTAGCAAGC
TTT GATTACATTTA
0
```

**Output:**

```
2 4 8
1 3 7
```

---

## 🛠 Technologies Used

- Language: **C# (.NET Core)**
- Input/Output: `Console.ReadLine()` / `Console.WriteLine()`
- Data structures: `HashSet<string>` for generating unique variants

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
   dotnet run
   ```

You will be prompted to enter the input manually. End the input with a line containing just `0`.

---

## 💡 Notes

- The program assumes all input is well-formed and consists of uppercase A/G/C/T characters only.
- Match counting is non-overlapping and based on exact substring matching.
- Duplicate variants are only counted once per type.

---
