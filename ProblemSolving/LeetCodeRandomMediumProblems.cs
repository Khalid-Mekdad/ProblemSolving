using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProblemSolving
{
    public class LeetCodeRandomMediumProblems
    {
        ///https://leetcode.com/problems/group-anagrams
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            int[] prime = { 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107 };

            Dictionary<long, List<string>> map = new Dictionary<long, List<string>>();
            List<List<string>> vs = new List<List<string>>();

            foreach (var item in strs)
            {
                long key = 1;
                foreach (var c in item)
                {
                    key *= prime[c - 'a'];
                }
                if (!map.ContainsKey(key))
                {
                    map.Add(key, new List<string>());
                }
                map[key].Add(item);
            }
            foreach (var item in map.Values)
            {
                vs.Add(item);
            }
            return vs.ToArray();


            //Dictionary<string, List<string>> v = new Dictionary<string, List<string>>();
            //List<List<string>> vs = new List<List<string>>();
            //foreach (var item in strs)
            //{
            //    var key = string.Join("" ,item.OrderBy(v => v));
            //    if (!v.ContainsKey(key))
            //    {
            //        v.Add(key, new List<string>() { item });
            //    }
            //    else
            //    {
            //        v[key].Add(item);
            //    }
            //}

            //foreach (var item in v.Values)
            //{
            //    vs.Add(item);
            //}
            //return vs.ToArray();
        }

        ///https://leetcode.com/problems/letter-combinations-of-a-phone-number
        public static IList<string> LetterCombinations(string digits)
        {
            var codes = new Dictionary<int, List<char>>()
            {
                {2,new List<char> { 'a', 'b', 'c' }},
                {3,new List<char> { 'd', 'e', 'f' }},
                {4,new List<char> { 'g', 'h', 'i' }},
                {5,new List<char> { 'j', 'k', 'l' }},
                {6,new List<char> { 'm', 'n', 'o' }},
                {7,new List<char> { 'p', 'q', 'r','s' }},
                {8,new List<char> { 't', 'u', 'v' }},
                {9,new List<char> { 'w', 'x', 'y','z' }}
            };

            List<string> res = new List<string>();
            res.Add("");

            foreach (var digit in digits)
            {
                List<string> prev = new List<string>();
                foreach (var chars in (codes[int.Parse(digit.ToString())]))
                {
                    foreach (var p in res)
                    {
                        prev.Add(p + chars.ToString());
                    }
                }
                res = prev;
            }

            return res.ToArray();
        }

        ///https://leetcode.com/problems/watering-plants/
        public static int WateringPlants(int[] plants, int capacity)
        {
            int steps = 0;
            int currentCapacity = capacity;
            for (int i = 0; i < plants.Length; i++)
            {
                if (plants[i] <= currentCapacity)
                {
                    currentCapacity -= plants[i];
                    steps += 1;
                }
                else
                {
                    // return to river 
                    steps += (i) - 0;
                    //refill
                    currentCapacity = capacity;
                    //water the plant
                    steps += (i + 1) - 0;
                    currentCapacity -= plants[i];
                }
            }
            return steps;
        }

        ///https://leetcode.com/problems/longest-consecutive-sequence/
        public static int LongestConsecutive(int[] nums)
        {
            var n = nums.Length;
            if (n == 0) return 0;
            var numAndLeftRight = new Dictionary<int, Tuple<int, int>>();

            var global = 1;

            foreach (var num in nums)
            {
                if (numAndLeftRight.ContainsKey(num)) continue;

                var pre = num - 1;
                var next = num + 1;

                var start = numAndLeftRight.ContainsKey(pre) ? numAndLeftRight[pre].Item1 : num;
                var end = numAndLeftRight.ContainsKey(next) ? numAndLeftRight[next].Item2 : num;

                global = Math.Max(end - start + 1, global);

                var curRange = Tuple.Create(start, end);
                numAndLeftRight[num] = curRange;
                numAndLeftRight[start] = curRange;
                numAndLeftRight[end] = curRange;
            }

            return global;
        }

        ///https://leetcode.com/problems/top-k-frequent-elements/
        public static int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!d.ContainsKey(nums[i]))
                {
                    d.Add(nums[i], 1);
                }
                else
                {
                    d[nums[i]] += 1;
                }
            }

            return d.OrderByDescending(s => s.Value).Take(k).Select(v => v.Key).ToArray();
        }

        ///https://leetcode.com/problems/sort-colors/
        public static void SortColors(int[] nums)
        {
            int[] counter = new int[3];
            for (int i = 0; i < nums.Length; i++)
            {
                counter[nums[i]] += 1;
            }

            int j = 0;
            int index = 0;
            foreach (var item in counter)
            {
                while (counter[j] > 0)
                {
                    nums[index] = j;
                    counter[j] -= 1;
                    index++;
                }
                j++;
            }
        }

        ///https://leetcode.com/problems/swap-nodes-in-pairs/
        public static ListNode<T> SwapPairs<T>(ListNode<T> head)
        {
            return null;
        }
    }
}