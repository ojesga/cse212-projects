using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan:
        // 1. Initialize a new array of doubles called 'multiples' with a size equal to 'length'.
        // 2. Create a for loop that iterates from 0 up to 'length - 1' using a loop counter variable 'i'.
        // 3. Inside the loop, calculate the current multiple by multiplying 'number' by (i + 1).
        // 4. Assign this calculated value to the current index 'i' in the 'multiples' array.
        // 5. After the loop completes, return the populated 'multiples' array.

        // 1. Initialize the array
        double[] multiples = new double[length];

        // 2. Loop through the array indices
        for (int i = 0; i < length; i++)
        {
            // 3 & 4. Calculate the multiple and assign it to the index
            multiples[i] = number * (i + 1);
        }

        // 5. Return the result array
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan:
        // 1. Determine where to split the list. The number of elements staying at the front is equal to (data.Count - amount).
        // 2. Use GetRange to extract the target elements from the back of the list (starting at the split index, running for 'amount' elements). Store this in a temporary list.
        // 3. Use GetRange to extract the remaining elements from the front of the list (starting at index 0, running for the remaining length). Store this in a temporary list.
        // 4. Clear the original 'data' list entirely.
        // 5. Use AddRange to add the back elements temporary list to 'data' first.
        // 6. Use AddRange to add the front elements temporary list to 'data' second, completing the rotation.

        // Guard condition: If the list is empty, contains 1 item, or rotation amount matches length, no work is needed.
        if (data == null || data.Count <= 1 || amount == data.Count)
        {
            return;
        }

        // 1. Calculate the index split point
        int splitIndex = data.Count - amount;

        // 2. Slice out the back portion that wraps to the front
        List<int> backPart = data.GetRange(splitIndex, amount);

        // 3. Slice out the front portion that shifts to the back
        List<int> frontPart = data.GetRange(0, splitIndex);

        // 4. Wipe the original list clear
        data.Clear();

        // 5 & 6. Repopulate the original list in the newly rotated order
        data.AddRange(backPart);
        data.AddRange(frontPart);
    }
}