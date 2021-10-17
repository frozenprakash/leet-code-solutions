namespace LeetCode.Classes.Problems.TwoSum;

internal class AnyInput
{
    public int[] BruteForce()
    {
        for (int i = 0;
                i < TwoSum.Nums.Length;
                i++)
        {
            for (int j = 0;
                    j < TwoSum.Nums.Length;
                    j++)
            {
                if (i != j &&
                    TwoSum.Nums[i] + TwoSum.Nums[j] == TwoSum.Target)
                {
                    return new int[] { i, j };
                }
            }
        }

        throw new Exception("Input doesn't contain answer!");
    }
}