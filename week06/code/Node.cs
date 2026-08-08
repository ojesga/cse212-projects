using System;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    /// <summary>
    /// Problem 1: Inserts unique values into the tree (ignores duplicate entries).
    /// </summary>
    public void Insert(int value)
    {
        if (value < Data)
        {
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    /// <summary>
    /// Problem 2: Recursively searches for a value in the subtree.
    /// </summary>
    public bool Contains(int value)
    {
        if (value == Data)
            return true;

        if (value < Data)
            return Left is not null && Left.Contains(value);

        return Right is not null && Right.Contains(value);
    }

    /// <summary>
    /// Problem 4: Recursively calculates subtree height.
    /// </summary>
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}