namespace LeetCode.Classes
{
    internal class TwoSum
    {
        public void Execute()
        {
            int[] nums = { 2, 7, 11, 15 };
            int[] result;
            int target = 9;

            result = BruteForce(nums, 
                                target);

            MessageBox.Show($"[{result[0]}, {result[1]}] = {target}"); // [0, 1] = 9
            
        }

        public int[] BruteForce(int[] nums,
                                int target)
        {
            for (int i = 0;
                    i < nums.Length;
                    i++)
            {
                for (int j = 0;
                        j < nums.Length;
                        j++)
                {
                    if (i != j &&
                        nums[i] + nums[j] == target)
                    {
                        return new int[] { i,j};
                    }
                }
            }

            throw new Exception("Input doesn't contain answer!");
        }
    }
}