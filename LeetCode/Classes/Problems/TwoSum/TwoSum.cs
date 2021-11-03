namespace LeetCode.Classes.Problems.TwoSum;

internal class TwoSum
{    
    public static int[] Nums { get; set; } = { 4, 5, 5, 4, 8 };
    public static int Target { get; set; } = 9;

    public void Execute()
    {
        int[] result;

        result = DecidingLogic();
        MessageBox.Show($"[{result[0]}, {result[1]}] = {Target}"); // [0, 1] = 9
    }

    public int[] DecidingLogic()
    {
        DistinctInput distinctInput = new();
        DuplicateInput duplicateInput = new();

        if (IsDistinct())
        {
            return distinctInput.ReverseDictionary1Pass();
        }
        else
        {
            return duplicateInput.Dictionary1Pass();
        }

        throw new Exception("Input doesn't contain answer!");
    }

    /// <summary>
    /// 1. Checks whether the given array has distinct values <br/>
    /// 2. Uses HashSet which is 4x faster than Array.Distinct().Count()
    /// </summary>
    /// <returns></returns>
    public bool IsDistinct()
    {
        HashSet<int> hs = new();

        // hs will return false the moment first duplicate value is added to it
        // nums.All() will stop when first false is returned
        return Nums.All(hs.Add);
    }
}
