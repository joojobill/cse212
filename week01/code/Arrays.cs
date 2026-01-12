public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        //step 1: create an array of doubles with the size of length
        // This array will store the multiples of the number
        double[] multiples = new double[length];

        //step 2: loop from 0 up to (length - 1).
        //each index represents which multiples we are calculating.
        for (int i = 0; i < length; i++)
        {
            //step 3: calculate the multiple.
            // The first element should bee number * 1, the second number * 2, etc.
            // simce i starts at 0, we use (i + 1) to get the correct multiple.
            multiples[i] = number * (i + 1);
        }

        //step 4: return the array of multiples
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
        //step 1: understand the goal.
        // Rotating the list to the right means that the last 'amount' elemments
        //of the list will be move to the front, while the reamining elements 
        // will shift to the right.

        //step 2: determine the size of the list .
        //This helps identify which element need to
        //  be moved.
        int Count = data.Count;

        //step 3: identify the starting index of the elements
        // that will be moved to the front.
        //This element begind at the index (Count - amount).
        int startIndex = Count - amount;

        //step 4: create a temporary list to store the elements
        //that will be rotated to the front.
        List<int> rightPart = new List<int> ();
        
        //step 5: copy the last 'amount ' elements into the temporary list.
        for (int i = startIndex; i < Count; i++)
        {
            rightPart.Add(data[i]);
        }

        //step 6: Remove the last 'amount' elements from the original list.
        //Removing from the end prevents index shifting issues
        for (int i = 0; i < amount; i++)
        {
            data.RemoveAt(data.Count - 1);
        }

        //step7: insert the saved elements at the beginning of the list.
        data.InsertRange(0, rightPart);
    }
}