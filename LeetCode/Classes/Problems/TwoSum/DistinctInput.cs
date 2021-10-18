namespace LeetCode.Classes.Problems.TwoSum;

internal class DistinctInput
{
    /// <summary>
    /// 1. Reverse Dictionary - Key and Value are reversed <br/>
    /// 2. To use Reverse Dictionary - Value should be distinct, so that it can be used as key <br/>
    /// 3. 2pass - 2 loop to self cross join and check
    /// </summary>
    /// <exception cref="Exception"></exception>
    public int[] ReverseDictionary2Pass()
    {
        int value2,
            index2;
        
        Dictionary<int, int> dict = new();

        for (int i = 0;
                    i < TwoSum.Nums.Length;
                    i++)
        {
            dict.Add(TwoSum.Nums[i],
                     i);
        }

        for (int i = 0;
                i < TwoSum.Nums.Length;
                i++)
        {
            // Input = { 7, 5, 3, 4, 8 }, Target = 9
            // value2 = target - value1
            // Iteraton1 → 2  = 9 - 7
            // Iteration2 → 4 = 9 - 5 etc..
            value2 = TwoSum.Target - TwoSum.Nums[i];

            if (dict.ContainsKey(value2) &&
                dict[value2] != i)
            {
                index2 = dict[value2];
                return new int[] { i, index2 };
            }
        }

        throw new Exception("Input doesn't contain answer!");
    }

    /// <summary>
    /// 1. Reverse Dictionary - Key and Value are reversed <br/>
    /// 2. To use Reverse Dictionary - Value should be distinct, so that it can be used as key <br/>
    /// 3. 1pass - 1 loop to self cross join and check
    /// </summary>
    /// <exception cref="Exception"></exception>
    public int[] ReverseDictionary1Pass()
    {
        int value2,
            index2;

        Dictionary<int, int> dict = new();

        for (int i = 0;
                    i < TwoSum.Nums.Length;
                    i++)
        {
            // Input = { 7, 5, 3, 4, 8 }, Target = 9
            // value2 = target - value1
            // Iteraton1 → 2  = 9 - 7
            // Iteration2 → 4 = 9 - 5 etc..
            value2 = TwoSum.Target - TwoSum.Nums[i];

            if (dict.ContainsKey(value2))
            {
                index2 = dict[value2];
                return new int[] { index2, i };
            }

            dict.Add(TwoSum.Nums[i],
                     i);
        }

        throw new Exception("Input doesn't contain answer!");
    }
}
