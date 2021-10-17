namespace LeetCode.Classes.Problems.TwoSum;

internal class DuplicateInput
{
    record IndexNumber(int Index,
                       int Value);

    record ReturnType(IndexNumber IndexNumber1,
                      IndexNumber IndexNumber2);

    public int[] ListWithLinq()
    {
        List<IndexNumber> lstIndexNumber = new List<IndexNumber>();
        List<ReturnType>? lstReturnType;

        for (int i = 0;
                    i < TwoSum.Nums.Length;
                    i++)
        {
            lstIndexNumber.Add(new IndexNumber(i,
                                        TwoSum.Nums[i]));
        }

        lstReturnType = lstIndexNumber.Join(lstIndexNumber,
                                                x => true,
                                                y => true,
                                                (x, y) => new ReturnType(x, y))
                                        .ToList();

        ReturnType? ret = lstReturnType.Where(rt => rt.IndexNumber1.Index != rt.IndexNumber2.Index &&
                                                                        rt.IndexNumber1.Value + rt.IndexNumber2.Value == TwoSum.Target)
                                        .DefaultIfEmpty(null)
                                        .First();

        if (ret is not null)
        {
            return new int[] {ret.IndexNumber1.Index,
                                    ret.IndexNumber2.Index };
        }

        throw new Exception("Input doesn't contain answer!");
    }

    public int[] Dictionary2Pass()
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
            value2 = TwoSum.Target - TwoSum.Nums[i];

            if (dict.ContainsKey(value2))
            {
                index2 = dict[value2];
                return new int[] { i, index2 };
            }
        }

        throw new Exception("Input doesn't contain answer!");
    }

    public int[] Dictionary1Pass()
    {
        int value2,
            index2;

        Dictionary<int, int> dict = new();

        for (int i = 0;
                    i < TwoSum.Nums.Length;
                    i++)
        {
            value2 = TwoSum.Target - TwoSum.Nums[i];

            if (dict.ContainsValue(value2))
            {
                index2 = dict.FirstOrDefault(x => x.Value == value2)
                                .Key;
                return new int[] { i, index2 };
            }

            dict.Add(i,
                     TwoSum.Nums[i]);
        }

        throw new Exception("Input doesn't contain answer!");
    }
}