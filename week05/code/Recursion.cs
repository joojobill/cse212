using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2.
    /// If n <= 0, return 0.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case
        if (n <= 0)
            return 0;

        // Recursive case
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, generate permutations of length 'size'
    /// from the string 'letters' and store them in results.
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: permutation is complete
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Recursive case: choose each letter
        for (int i = 0; i < letters.Length; i++)
        {
            string remaining = letters.Remove(i, 1);
            PermutationsChoose(results, remaining, size, word + letters[i]);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count the number of ways to climb s stairs using steps of
    /// 1, 2, or 3 with memoization.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        // Check memoized results
        if (remember.ContainsKey(s))
            return remember[s];

        decimal result;

        // Base cases
        if (s == 0) result = 0;
        else if (s == 1) result = 1;
        else if (s == 2) result = 2;
        else if (s == 3) result = 4;
        else
        {
            // Recursive case
            result = CountWaysToClimb(s - 1, remember)
                   + CountWaysToClimb(s - 2, remember)
                   + CountWaysToClimb(s - 3, remember);
        }

        // Store result
        remember[s] = result;
        return result;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Generate all binary strings that match a wildcard pattern.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        // Base case: no wildcards left
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        // Recursive case: replace * with 0 and 1
        WildcardBinary(pattern[..index] + "0" + pattern[(index + 1)..], results);
        WildcardBinary(pattern[..index] + "1" + pattern[(index + 1)..], results);
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    /// Use recursion to find all paths from (0,0) to the end of the maze.
    /// </summary>
    public static void SolveMaze(
        List<string> results,
        Maze maze,
        int x = 0,
        int y = 0,
        List<ValueTuple<int, int>>? currPath = null)
    {
        // Initialize path if first call
        if (currPath == null)
            currPath = new List<(int, int)>();

        // Check if move is valid
        if (!maze.IsValidMove(currPath, x, y))
            return;

        // Add current position to path
        currPath.Add((x, y));

        // Check if we've reached the end
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            return;
        }

        // Explore all directions recursively
        SolveMaze(results, maze, x + 1, y, new List<(int, int)>(currPath)); // Right
        SolveMaze(results, maze, x - 1, y, new List<(int, int)>(currPath)); // Left
        SolveMaze(results, maze, x, y + 1, new List<(int, int)>(currPath)); // Down
        SolveMaze(results, maze, x, y - 1, new List<(int, int)>(currPath)); // Up
    }
}
