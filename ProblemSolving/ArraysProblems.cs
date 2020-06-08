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
            for (int i = 0; i <= J.Length-1; i++)
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
    }
}
