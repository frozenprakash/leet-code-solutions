namespace LeetCode.Classes.Problems.TwoSum;

internal class TwoSum
{
    record IndexNumber(int Index,
                   int Value);

    record ReturnType(IndexNumber IndexNumber1,
                      IndexNumber IndexNumber2);

    public static int[] Nums { get; set; } = { 3, 2, 3 };
    public static int Target { get; set; } = 6;

    public void Execute()
    {

        int[] result;

        result = DecidingLogic();

        MessageBox.Show($"[{result[0]}, {result[1]}] = {Target}"); // [0, 1] = 9

    }

    public int[] DecidingLogic()
    {
        DistinctInput distinctInput = new();

        if (IsDistinct())
        {
            return distinctInput.ReverseDictionary1Pass();
        }
        else
        {
            return List2Pass();
        }

        throw new Exception("Input doesn't contain answer!");
    }

    public int[] BruteForce()
    {
        for (int i = 0;
                i < Nums.Length;
                i++)
        {
            for (int j = 0;
                    j < Nums.Length;
                    j++)
            {
                if (i != j &&
                    Nums[i] + Nums[j] == Target)
                {
                    return new int[] { i, j };
                }
            }
        }

        throw new Exception("Input doesn't contain answer!");
    }

    /// <summary>
    /// 1. Checks whether the given array has distinct values <br/>
    /// 2. Uses HashSet which is 4x faster than Array.Distinct().Count()
    /// </summary>
    /// <returns></returns>

    private int[] List2Pass()
    {
        List<IndexNumber> lstIndexNumber = new List<IndexNumber>();
        List<ReturnType>? lstReturnType;

        for (int i = 0;
                    i < Nums.Length;
                    i++)
        {
            lstIndexNumber.Add(new IndexNumber(i,
                                        Nums[i]));
        }

        lstReturnType = lstIndexNumber.Join(lstIndexNumber,
                                                x => true,
                                                y => true,
                                                (x, y) => new ReturnType(x, y))
                                        .ToList();

        var ret = lstReturnType.Where(rt => rt.IndexNumber1.Index != rt.IndexNumber2.Index &&
                                                                    rt.IndexNumber1.Value + rt.IndexNumber2.Value == Target)
                                        .DefaultIfEmpty(null)
                                        .First();

        if (ret is not null)
        {
            return new int[] {ret.IndexNumber1.Index,
                                    ret.IndexNumber2.Index };
        }

        throw new Exception("Input doesn't contain answer!");
    }

    public bool IsDistinct()
    {
        HashSet<int> hs = new();

        // hs will return false the moment first duplicate value is added to it
        // nums.All() will stop when first false is returned
        return Nums.All(hs.Add);
    }
}
