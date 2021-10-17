using System.Linq;

namespace LeetCode.Classes
{
    //record IndexNumber(int Index, 
    //                    int Value);


    //class ReturnType
    //{
    //    public int Index1 { get; set; }
    //    public int Index2 { get; set; }
    //}

    //record ReturnType(int Index1,
    //                    int Index2);

    //class IndexNumber
    //{
    //    public int Index { get; set; }
    //    public int Value { get; set; }

    //    public IndexNumber(int index, 
    //                        int value)
    //    {
    //        Index = index;
    //        Value = value;
    //    }
    //}

    internal class TwoSum
    {
        int[] Nums { get; set; } = { 3, 3 };
        int Target { get; set; } = 6;

        public void Execute()
        {
            
            int[] result;

            result = DecidingLogic();

            MessageBox.Show($"[{result[0]}, {result[1]}] = {Target}"); // [0, 1] = 9

        }
        
        public int[] DecidingLogic()
        {
            if (IsInputDistinct())
            {
                return ReverseDictionary2Pass();
            }
            else
            {
                return BruteForce();
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
                        return new int[] { i,j};
                    }
                }
            }

            throw new Exception("Input doesn't contain answer!");
        }

        /// <summary>
        /// 1. Reverse Dictionary - Key and Value are reversed <br/>
        /// 2. To use Reverse Dictionary - Value should be distinct, so that it can be used as key <br/>
        /// 3. Two pass - Two loops
        /// </summary>
        /// <exception cref="Exception"></exception>
        private int[] ReverseDictionary2Pass()
        {
            int value2,
                index2;

            Dictionary<int, int> dict = new();

            for (int i = 0; 
                        i < Nums.Length; 
                        i++)
            {
                dict.Add(Nums[i],
                         i);
            }

            for (int i = 0;
                        i < Nums.Length;
                        i++)
            {
                value2 = Target - Nums[i];

                if(dict.ContainsKey(value2) &&
                    dict[value2] != i)
                {
                    index2 = dict[value2];
                    
                    return new int[] {i, index2};
                }
            }

            throw new Exception("Input doesn't contain answer!");
        }
        
        /// <summary>
        /// 1. Checks whether the given array has distinct values <br/>
        /// 2. Uses HashSet which is 4x faster than Array.Distinct().Count()
        /// </summary>
        /// <returns></returns>
        public bool IsInputDistinct()
        {
            HashSet<int> hs = new();
            
            // hs will return false the moment first duplicate value is added to it
            // nums.All() will stop when first false is returned
            return Nums.All(hs.Add);
        }

        //private int[] List2Pass()
        //{
        //    List<IndexNumber> lst = new List<IndexNumber>();
        //    IndexNumber indNum;

        //    for (int i = 0;
        //                i < nums.Length;
        //                i++)
        //    {
        //        lst.Add(new IndexNumber(i,
        //                                    nums[i]));
        //    }

        //    var ret = lst.Join(lst,
        //                            x => true,
        //                            y => true,
        //                            (x,y) => new ReturnType()
        //                            {

        //                            }
                                   
            

        //    throw new Exception("Input doesn't contain answer!");
        //}
    }
}