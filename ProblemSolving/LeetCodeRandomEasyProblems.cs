﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProblemSolving
{
    public static class LeetCodeRandomEasyProblems
    {
        //public static int RomanToInt(string s)
        //{
        //    var dict = new Dictionary<char, int>()
        //    {
        //        {'I',1 },
        //        {'V',5},
        //        {'X',10 },
        //        {'L',50},
        //        {'C',100 },
        //        {'D',500 },
        //        {'M',1000 },
        //    };
        //    int result = 0;

        //    for (int i = 0; i <= s.Length - 1; i++)
        //    {
        //        if (i == 0)
        //        {
        //            result += dict[s[i]];
        //        }
        //    }

        //    return result;
        //}

        //https://leetcode.com/problems/length-of-last-word/

        ///https://leetcode.com/problems/length-of-last-word/
        public static int LengthOfLastWord(string s)
        {
            int result = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (result > 0 && s[i] == ' ')
                {
                    break;
                }
                if (s[i] == ' ')
                {
                    continue;
                }
                result++;
            }
            return result;
        }

        ///https://leetcode.com/problems/valid-parentheses/
        public static bool IsValidParentheses(string s)
        {
            if (s.Length % 2 != 0)
            {
                return false;
            }

            Stack<char> ss = new Stack<char>();
            foreach (var item in s)
            {
                if (item == '(' || item == '[' || item == '{')
                {
                    ss.Push(item);
                }
                else if (ss.Count == 0 || GetClosed(item) != ss.Pop())
                {
                    return false;
                }
            }

            return ss.Count == 0;
        }
        private static char? GetClosed(char v)
        {
            if (v == '}')
            {
                return '{';
            }
            else if (v == ')')
            {
                return '(';
            }
            else if (v == ']')
            {
                return '[';
            }
            return null;
        }


        ///https://leetcode.com/problems/longest-common-prefix/
        public static string LongestCommonPrefix(string[] strs)
        {
            Array.Sort(strs, (x, y) => x.Length.CompareTo(y.Length));
            var longestPrefix = strs[0];
            int prefixLength = longestPrefix.Length;

            for (int i = 1; i <= strs.Length - 1; ++i)
            {
                var substring = strs[i].Substring(0, prefixLength);
                if (longestPrefix != substring)
                {
                    prefixLength -= 1;
                    i = 0;
                    longestPrefix = longestPrefix.Substring(0, prefixLength);
                }
            }

            return prefixLength == 0 ? "" : longestPrefix.Substring(0, prefixLength);

        }

        ///https://leetcode.com/problems/search-insert-position/
        public static int SearchInsert(int[] nums, int target)
        {
            int index = 0;

            if (target < nums[0])
            {
                return 0;
            }
            if (target > nums[nums.Length - 1])
            {
                return nums.Length;
            }

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == target)
                {
                    return i;
                }
                else if (nums[i] <= target)
                {
                    index = i + 1;
                }

            }

            return index;
        }

        ///https://leetcode.com/problems/majority-element/
        public static int MajorityElement(int[] nums)
        {
            var limit = Math.Ceiling((decimal)nums.Length / 2);
            Dictionary<int, int> x = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!x.ContainsKey(nums[i]))
                {
                    x.Add(nums[i], 1);
                }
                else
                {
                    x[nums[i]] += 1;
                }

                if (x[nums[i]] >= limit)
                {
                    return nums[i];
                }
            }

            return x.Where(so => so.Value >= limit).OrderByDescending(s => s.Value).FirstOrDefault().Key;
        }

        ///https://leetcode.com/problems/excel-sheet-column-number
        public static int TitleToNumber(string title)
        {
            int result = 0;
            title = string.Join("", title.Reverse().ToArray());
            for (int i = 0; i < title.Length; i++)
            {
                result += (int)Math.Pow(26, i) * ((title[i] - 'A') + 1);
            }

            return result;
        }


        ///https://leetcode.com/problems/single-number/
        public static int SingleNumber(int[] nums)
        {
            if (nums == null)
                return -1;

            int sum = 0;
            foreach (var item in nums)
            {
                sum ^= item;
            }

            return sum;
        }

        ///https://leetcode.com/problems/maximum-subarray/
        public static int MaxSubArray(int[] nums)
        {
            var n = nums.Length;
            if (n == 0) return nums[0];

            long globalMax = int.MinValue;
            long sumMin = 0;
            long sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += nums[i];

                long localMax = int.MinValue;

                localMax = sum - sumMin;
                globalMax = Math.Max(globalMax, localMax);
                sumMin = Math.Min(sumMin, sum);
            }

            return (int)globalMax;
            //int max = nums[0];
            //int sum = 0;
            //for (int i = 0; i <= nums.Length - 1; i++)
            //{
            //    sum += nums[i];
            //    if (sum > max)
            //    {
            //        max = sum;
            //    }
            //    else if (sum < 0)
            //    {
            //        sum = 0;
            //    }
            //}

        }

        ///https://leetcode.com/problems/number-of-steps-to-reduce-a-number-to-zero/
        public static int NumberOfSteps(int num)
        {
            int steps = 0;
            while (num > 0)
            {
                if (num % 2 == 0)
                {
                    num /= 2;
                }
                else
                {
                    num -= 1;
                }
                steps += 1;
            }
            return steps;
        }


        ///https://leetcode.com/problems/how-many-numbers-are-smaller-than-the-current-number/
        public static int[] SmallerNumbersThanCurrent(int[] nums)
        {
            List<int> x = new List<int>(nums);
            var r = new List<int>();
            foreach (var item in x)
            {
                r.Add(x.Count(v => v < item));
            }

            return r.ToArray();
        }

        ///just training
        public static bool CheckIfExist(int[] arr)
        {
            HashSet<int> vals = new HashSet<int>(arr);
            return vals.Any(s => s != 0 ? vals.Contains(s * 2) : arr.Count(v => v == 0) > 1);
        }

        ///https://leetcode.com/problems/two-sum/
        public static int[] TwoSum(int[] arr, int target)
        {
            int[] result = new int[2];
            Dictionary<int, int> x = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                int difference = target - arr[i];
                if (x.ContainsKey(difference))
                {
                    result[0] = x[difference];
                    result[1] = i;
                    return result;
                }
                else if (!x.ContainsKey(arr[i]))
                {
                    x.Add(arr[i], i);
                }
            }

            //for (int i = 0; i <= arr.Length -1; i++)
            //{
            //    for (int j = 0; j <= arr.Length - 1; j++)
            //    {
            //        if (arr[i] + arr[j] == target)
            //        {
            //            result[0] = i;
            //            result[1] = j;
            //            return result;
            //        }
            //    }
            //}
            return result;
        }

        ///https://leetcode.com/problems/build-array-from-permutation/
        public static int[] BuildArray(int[] nums)
        {
            var x = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                x[i] = nums[nums[i]];
            }
            return x;
        }

        ///https://leetcode.com/problems/concatenation-of-array/
        public static int[] GetConcatenation(int[] nums)
        {
            var ans = new List<int>();
            ans.AddRange(nums);
            ans.AddRange(nums);
            return ans.ToArray();
        }

        ///https://leetcode.com/problems/running-sum-of-1d-array/
        public static int[] RunningSum(int[] nums)
        {
            var result = new int[nums.Length];
            int max = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                max += nums[i];
                result[i] = max;
            }
            return result;

        }

        ///https://leetcode.com/problems/richest-customer-wealth/
        public static int MaximumWealth(int[][] accounts)
        {
            int max = 0;
            for (int i = 0; i < accounts.Length; i++)
            {
                max = Math.Max(max, accounts[i].Sum());
            }
            return max;
        }

        ///https://leetcode.com/problems/shuffle-the-array/
        public static int[] Shuffle(int[] nums, int n)
        {
            var firstHalf = new int[n];
            var secondHalf = new int[n];
            int[] result = new int[2 * n];

            for (int i = 0; i < n; i++)
            {
                firstHalf[i] = nums[i];
            }
            for (int i = 0; i < n; i++)
            {
                secondHalf[i] = nums[n + i];
            }
            int l = 0, r = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 2 == 0)
                {
                    result[i] = firstHalf[l];
                    l += 1;
                }
                else
                {
                    result[i] = secondHalf[r];
                    r += 1;
                }
            }
            return result;
        }

        ///https://leetcode.com/problems/kids-with-the-greatest-number-of-candies/
        public static IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            var x = new List<bool>();
            int max = 0;
            foreach (var item in candies)
            {
                max = Math.Max(max, item);
            }
            foreach (var item in candies)
            {
                x.Add(item + extraCandies >= max);
            }
            return x;
        }

        ///https://leetcode.com/problems/number-of-good-pairs/
        public static int NumIdenticalPairs(int[] nums)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        ///https://leetcode.com/problems/shuffle-string/discuss/?currentPage=1&orderBy=hot&query=
        public static string RestoreString(string s, int[] indices)
        {
            var x = new char[s.Length];
            for (int i = 0; i < indices.Length; i++)
            {
                x[indices[i]] = s[i];
            }

            return string.Join("", x);
        }

        /// https://leetcode.com/problems/decompress-run-length-encoded-list/
        public static int[] DecompressRLElist(int[] nums)
        {
            List<int> x = new List<int>();
            for (int i = 0; i < nums.Length; i += 2)
            {
                int freq = nums[i];
                if (freq == 0)
                {
                    continue;
                }
                int c = 1;
                while (c <= freq)
                {
                    x.Add(nums[i + 1]);
                }
            }
            return x.ToArray();
        }

        /// https://leetcode.com/problems/decompress-run-length-encoded-list/
        public static int[] CreateTargetArray(int[] nums, int[] index)
        {
            //Dictionary<int,Stack<int>> indexKey = new Dictionary<int, Stack<int>>();
            var h = new List<int>();
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (!indexKey.ContainsKey(index[i]))
            //    {
            //        var s = new Stack<int>();
            //        s.Push(nums[i]);
            //        indexKey.Add(index[i], s);
            //    }
            //    else
            //    {
            //        indexKey[index[i]].Push(nums[i]);
            //    }
            //}

            //foreach (var item in indexKey.OrderBy(s=>s.Key))
            //{
            //    while (item.Value.Count > 0)
            //    {
            //        h.Add(item.Value.Pop());
            //    }
            //}
            return h.ToArray();
        }

        ///https://leetcode.com/problems/count-items-matching-a-rule/
        public static int CountMatches(IList<IList<string>> items, string ruleKey, string ruleValue)
        {
            int keyIndex = ruleKey == "type" ? 0 : ruleKey == "color" ? 1 : ruleKey == "color" ? 2 : -1;
            int count = 0;
            for (int i = 0; i < items.Count; i++)
            {
                count = items[i][keyIndex] == ruleValue ? count + 1 : count;
            }


            return count;
        }

        ///https://leetcode.com/problems/count-number-of-pairs-with-absolute-difference-k/
        public static int CountKDifference(int[] nums, int k)
        {

            Dictionary<string, int> pairsPrint = new Dictionary<string, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (Math.Abs(nums[i] - nums[j]) == k)
                    {
                        string print = string.Join(",", nums[i], nums[j]);
                        if (!pairsPrint.ContainsKey(print))
                        {
                            pairsPrint.Add(print, 1);
                        }
                        else
                        {
                            pairsPrint[print] += 1;
                        }
                    }
                }
            }
            return pairsPrint.Sum(s => s.Value);
        }

        //https://leetcode.com/problems/contains-duplicate/
        public static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            var x = new HashSet<int>(nums);

            return x.Count == nums.Length;
        }


        ///https://leetcode.com/problems/contains-duplicate-ii/
        public static bool ContainsNearbyDuplicateII(int[] nums, int k)
        {
            var x = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!x.ContainsKey(nums[i]))
                {
                    x.Add(nums[i], i);
                }
                else
                {
                    if (i - x[nums[i]] <= k)
                    {
                        return true;
                    }
                    x[nums[i]] = i;
                }
            }

            return false;
        }

        ///https://leetcode.com/problems/ransom-note/
        public static bool CanConstruct(string ransomNote, string magazine)
        {
            var ransom = new Dictionary<char, int>();
            foreach (var item in ransomNote)
            {
                if (!ransom.ContainsKey(item))
                {
                    ransom.Add(item, 1);
                }
                else
                {
                    ransom[item] += 1;
                }
            }
            for (int j = 0; j < magazine.Length; j++)
            {
                if (ransom.ContainsKey(magazine[j]))
                {
                    ransom[magazine[j]] -= 1;
                }
            }

            return !ransom.Any(s => s.Value > 0);

        }

        /// https://leetcode.com/problems/valid-palindrome/
        public static bool IsValidPalindrome(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (isCharAlphanumeric(s[i]))
                {
                    char character = (s[i] >= 65 && s[i] <= 90) ? (char)(s[i] + 32) : s[i];
                    sb.Append(character);
                }
            }
            return IsPalindrome(sb.ToString());
        }

        ///https://leetcode.com/problems/valid-palindrome-ii/
        public static bool ValidPalindromeII(string s)
        {
            return false;
        }

        ///https://leetcode.com/problems/check-if-two-string-arrays-are-equivalent/
        public static bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            StringBuilder s1 = new StringBuilder();
            StringBuilder s2 = new StringBuilder();

            foreach (var item in word1)
            {
                s1.Append(item);
            }

            foreach (var item in word2)
            {
                s1.Append(item);
            }

            return s1.ToString() == s2.ToString();
        }

        /// https://leetcode.com/problems/goal-parser-interpretation/
        public static string Interpret(string command)
        {
            StringBuilder phrase = new StringBuilder();
            int i = 0;

            while (i < command.Length)
            {
                if (command[i] == 'G')
                {
                    phrase.Append('G');
                    i += 1;
                }
                else if (command[i + 1] == ')')
                {
                    phrase.Append('o');
                    i += 2;
                }
                else if (command[i + 1] == 'a')
                {
                    phrase.Append('a');
                    i += 3;
                }
            }

            return phrase.ToString();
        }


        ///https://leetcode.com/problems/pascals-triangle/
        public static IList<IList<int>> Generate(int numRows)
        {
            var x = new List<List<int>>();
            x.Add(new List<int>() { 1 });
            if (numRows == 1)
            {
                return x.ToArray();
            }

            for (int i = 1; i <= numRows; i++)
            {
                List<int> currentRow = new List<int>();
                currentRow.Add(1);

                for (int j = 0; j <= i - 2; j++)
                {
                    var prev = x[i - 1];
                    currentRow.Add(prev[j] + prev[j + 1]);
                }

                currentRow.Add(1);

                x.Add(currentRow);
            }
            return x.ToArray();
        }

        ///https://leetcode.com/problems/replace-all-digits-with-characters/
        public static string ReplaceDigits(string s)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                if (i % 2 == 0)
                {
                    sb.Append(s[i]);
                    continue;
                }
                var character = (char)((int)s[i - 1] + int.Parse(s[i].ToString()));
                sb.Append(character);
            }
            return sb.ToString();
        }

        /// https://leetcode.com/problems/check-if-numbers-are-ascending-in-a-sentence/
        public static bool AreNumbersAscending(string s)
        {
            var tokens = s.Split(' ');
            int max = 0;
            int currentToken;
            foreach (var item in tokens)
            {
                if (int.TryParse(item, out currentToken))
                {
                    if (currentToken > max)
                    {
                        max = currentToken;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        ///https://leetcode.com/problems/determine-if-string-halves-are-alike/
        public static bool HalvesAreAlike(string s)
        {
            HashSet<char> xx = new HashSet<char>() { 'A', 'a', 'E', 'e', 'I', 'i', 'O', 'o', 'U', 'u' };
            int l = 0;
            int r = 0;
            for (int i = 0; i < (s.Length / 2); i++)
            {
                if (xx.Contains(s[i]))
                {
                    l++;
                }
            }

            for (int i = (s.Length / 2); i < s.Length; i++)
            {
                if (xx.Contains(s[i]))
                {
                    r++;
                }
            }

            return l == r;

        }

        ///https://leetcode.com/problems/sorting-the-sentence/
        public static string SortSentence(string s)
        {
            var splitter = s.Split(' ');
            var sentenceAsArray = new string[splitter.Length];

            for (int i = 0; i < splitter.Length; i++)
            {
                var word = splitter[i];
                sentenceAsArray[int.Parse((word[word.Length - 1]).ToString()) - 1] = word.Substring(0, word.Length - 1);
            }
            var sentence = string.Join(" ", sentenceAsArray);
            return sentence;
        }

        ///https://leetcode.com/problems/count-the-number-of-consistent-strings/
        public static int CountConsistentStrings(string allowed, string[] words)
        {
            HashSet<char> chars = new HashSet<char>(allowed.ToCharArray());
            int matchingChars = 0;
            int count = 0;
            for (int i = 0; i < words.Length; i++)
            {
                matchingChars = 0;
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (chars.Contains(words[i][j]))
                        matchingChars += 1;
                    else
                    {
                        break;
                    }
                }
                if (matchingChars == words[i].Length)
                {
                    count += 1;
                }
            }
            return count;
        }


        public static bool IsPalindrome(string word)
        {
            var result = true;
            if (string.IsNullOrEmpty(word) || word.Length == 1)
            {
                return result;
            }

            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] != word[word.Length - i - 1])
                {
                    return false;
                }
            }
            return result;
        }

        private static bool isCharAlphanumeric(char s)
        {
            int asciiCode = (int)s;
            return (asciiCode >= 65 && asciiCode <= 90) || (asciiCode >= 97 && asciiCode <= 122) || (48 <= asciiCode && asciiCode <= 57);
        }
    }
}
