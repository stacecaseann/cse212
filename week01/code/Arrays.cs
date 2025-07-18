using System.Diagnostics;

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
        //1) Create a double array that is the size of length
        //2) Create a loop on i, starting at 1 and loop through i up to length
        //3) Inside the loop, Add number * i to the array at position i-1

        double[] results = new double[length];
        for (int i = 1; i <= length; i++)
        {
            results[i - 1] = number * i;
        }
        for (int i = 0; i < length; i++)
        {
            Debug.WriteLine(results[i]);
        }
        return results; // replace this return statement with your own
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
        //1) User list.GetRange to save a new list with the values that need to be rotated
        //      Beg Index = 0
        //      End Index = data.count - amount
        //2) Use list.RemoveRange to remove those same values from our original list
        //3) Use AddRange to attach the list from step 1 to the original list that was modified in step 2

        List<int> newList = data.GetRange(0, data.Count - amount);
        data.RemoveRange(0, data.Count - amount);
        data.AddRange(newList);

    }
}
