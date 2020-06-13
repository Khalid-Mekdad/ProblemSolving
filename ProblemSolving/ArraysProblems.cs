using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProblemSolving
{
    static class ArraysProblems
    {
        //https://leetcode.com/problems/kids-with-the-greatest-number-of-candies/
        public static IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {

            int greatestNmbOfCandies = -1;
            for (int i = 0; i <= candies.Length - 1; i++)
            {
                greatestNmbOfCandies = Math.Max(greatestNmbOfCandies, candies[i]);
            }

            List<bool> result = new List<bool>(candies.Length);
            for (int i = 0; i <= candies.Length - 1; i++)
            {
                result.Add(candies[i] + extraCandies >= greatestNmbOfCandies ? true : false);
            }
            return result;

        }

        //https://leetcode.com/problems/defanging-an-ip-address/
        public static string DefangIPaddr(string address)
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i <= address.Length - 1; i += 1)
            {
                if (address[i] == '.')
                {
                    str.Append("[.]");
                }
                else
                {
                    str.Append(address[i]);
                }
            }
            return str.ToString();
        }

        //https://leetcode.com/problems/number-of-steps-to-reduce-a-number-to-zero/
        public static int NumberOfSteps(int num)
        {
            if (num == 0) return 0;
            else
            {
                int stepsCount = 0;
                while (num > 0)
                {
                    if (num % 2 == 0)
                        num /= 2;
                    else
                        num -= 1;

                    stepsCount++;
                }

                return stepsCount < 0 ? stepsCount - 1 : stepsCount;
            }
        }

        //https://leetcode.com/problems/jewels-and-stones/
        public static int NumJewelsInStones(string J, string S)
        {
            int count = 0;
            HashSet<int> types = new HashSet<int>();
            for (int i = 0; i <= J.Length - 1; i++)
            {
                types.Add(J[i]);
            }
            for (int i = 0; i <= S.Length - 1; i++)
            {
                if (types.Contains(S[i]))
                    count++;

            }
            return count;
        }

        //https://leetcode.com/problems/how-many-numbers-are-smaller-than-the-current-number/
        public static int[] SmallerNumbersThanCurrent(int[] nums)
        {
            var result = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                int count = 0;
                int value = nums[i];
                for (int j = 0; j < nums.Length; j++)
                {
                    if (value == nums[j])
                    {
                        continue;
                    }
                    else if (nums[j] > value)
                        count++;
                }
                result[i] = count;
            }
            return result;
        }

        //https://leetcode.com/problems/decompress-run-length-encoded-list/
        public static int[] DecompressRLElist(int[] nums)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < nums.Length / 2; i += 1)
            {
                int freq = nums[2 * i];
                int value = nums[2 * i + 1];

                for (int ii = 0; ii < freq; ii++)
                {
                    result.Add(value);
                }
            }

            return result.ToArray();
        }

        //https://leetcode.com/problems/subtract-the-product-and-sum-of-digits-of-an-integer/
        public static int SubtractProductAndSum(int num)
        {
            int prod = 1;
            int sum = 0;
            while (num > 0)
            {
                var digit = num % 10;
                prod *= digit;
                sum *= digit;
                num = num / 10;
            }
            return prod - sum;
        }

        //https://leetcode.com/problems/create-target-array-in-the-given-order/
        public static int[] CreateTargetArray(int[] nums, int[] index)
        {
            var result = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                var idx = index[i];
                if (idx < i)
                {
                    for (int j = i; j > idx; j--)
                    {
                        result[j] = result[j - 1];
                    }

                }
                result[idx] = nums[i];
            }
            return result;
        }

        //https://leetcode.com/problems/find-numbers-with-even-number-of-digits/
        public  static  int FindNumbers(int[] nums)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if ((nums[i] >= 10 && nums[i] < Math.Pow(10, 2)) ||
                    (nums[i] >= Math.Pow(10, 3) && (nums[i] < Math.Pow(10, 4))) ||
                    (nums[i] >= Math.Pow(10, 5) && (nums[i] < Math.Pow(10, 6))))
                {
                    count++;
                }
            }
            return count;
        }
        #region helper methods
        //private static int[] shiftArrayOnePositionRight(int[] arr, int startingIndex, int endingIndex)
        //{
        //    var shiftedArray = new int[arr.Length];
        //    for (int i = startingIndex, j = 0; i <= endingIndex; j++, i++)
        //    {
        //        shiftedArray[j] = arr[i];
        //    }
        //    return arr;
        //}
        #endregion
    }

}
