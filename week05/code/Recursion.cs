using System;
using System.Collections;
using System.Collections.Generic;

public static class Recursion
{
    /// <summary>
    /// Problem 1: Finds sum of 1^2 + 2^2 + ... + n^2 recursively.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
        {
            return 0;
        }

        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// Problem 2: Generates permutations of specified size from unique letters.
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            char choice = letters[i];
            string remaining = letters.Remove(i, 1);
            PermutationsChoose(results, remaining, size, word + choice);
        }
    }

    /// <summary>
    /// Problem 3: Counts staircase paths using memoization to handle large inputs.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        remember ??= new Dictionary<int, decimal>();

        if (s <= 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;

        if (remember.TryGetValue(s, out decimal cachedResult))
        {
            return cachedResult;
        }

        decimal ways = CountWaysToClimb(s - 1, remember) +
                       CountWaysToClimb(s - 2, remember) +
                       CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// Problem 4: Expands binary pattern wildcards (*) recursively.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        string option0 = pattern[..index] + "0" + pattern[(index + 1)..];
        string option1 = pattern[..index] + "1" + pattern[(index + 1)..];

        WildcardBinary(option0, results);
        WildcardBinary(option1, results);
    }

    /// <summary>
    /// Problem 5: Finds all valid paths to maze endpoint using recursive backtracking.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // Check movements in order: Right, Left, Down, Up
        if (maze.IsValidMove(currPath, x + 1, y))
        {
            SolveMaze(results, maze, x + 1, y, currPath);
        }
        if (maze.IsValidMove(currPath, x - 1, y))
        {
            SolveMaze(results, maze, x - 1, y, currPath);
        }
        if (maze.IsValidMove(currPath, x, y + 1))
        {
            SolveMaze(results, maze, x, y + 1, currPath);
        }
        if (maze.IsValidMove(currPath, x, y - 1))
        {
            SolveMaze(results, maze, x, y - 1, currPath);
        }

        // Backtrack current step before returning up the recursion stack
        currPath.RemoveAt(currPath.Count - 1);
    }
}