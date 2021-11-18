using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProblemSolving
{
    public class LeetCodeRandomEasyProblems
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

        ///https://leetcode.com/problems/pasacals-triangle/
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

        ///https://leetcode.com/problems/number-of-strings-that-appear-as-substrings-in-word/
        public static int NumOfStrings(string[] patterns, string word)
        {
            int count = 0;
            for (int i = 0; i < patterns.Length; i++)
            {
                if (word.Contains(patterns[i]))
                {
                    count += 1;
                }
            }
            return count;
        }

        /// https://leetcode.com/problems/destination-city/
        public static string DestCity(IList<IList<string>> paths)
        {
            Dictionary<string, int> vp = new Dictionary<string, int>();
            foreach (var path in paths)
            {
                for (int i = 0; i < path.Count; i++)
                {
                    if (!vp.ContainsKey(path[i]))
                    {
                        if (i == 0)
                        {
                            vp.Add(path[i], 1);
                        }
                        else
                        {
                            vp.Add(path[i], 3);
                        }
                    }
                    else
                    {
                        if ((vp[path[i]] == 3 && i == 0) || (vp[path[i]] == 1 && i == 1))
                        {
                            vp[path[i]] = 2;
                        }
                    }
                }
            }

            return vp.FirstOrDefault(s => s.Value == 3).Key;
        }

        ///https://leetcode.com/problems/reverse-only-letters/
        public static string ReverseOnlyLetters(string s)
        {
            int l = 0;
            int r = s.Length - 1;
            char temp;
            StringBuilder result = new StringBuilder(s);
            while (l <= r)
            {
                if (!isCharAlphabetic(s[l]) && !isCharAlphabetic(s[r]))
                {
                    l += 1;
                    r -= 1;
                }
                else if (!isCharAlphabetic(s[l]) && !isCharAlphabetic(s[r]))
                {
                    temp = result[l];
                    result[l] = result[r];
                    result[r] = temp;

                    l += 1;
                    r -= 1;
                }
                else if (!isCharAlphabetic(s[l]))
                {
                    l += 1;
                }
                else if (!isCharAlphabetic(s[r]))
                {
                    r -= 1;
                }

            }
            return result.ToString();
        }

        ///https://leetcode.com/problems/shortest-distance-to-a-character/
        public static int[] ShortestToChar(string s, char c)
        {
            var indexs = new HashSet<int>();
            var result = new List<int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == c)
                    indexs.Add(i);
            }

            for (int i = 0; i < s.Length; i++)
            {
                result.Add(indexs.Min(s => Math.Abs(i - s)));
            }

            return result.ToArray();

        }

        /// https://leetcode.com/problems/truncate-sentence/
        public static string TruncateSentence(string s, int k)
        {
            var words = s.Split(' ');
            return string.Join(" ", words.Take(k).ToArray());
        }

        /// https://leetcode.com/problems/check-if-all-characters-have-equal-number-of-occurrences/
        public static bool AreOccurrencesEqual(string s)
        {
            Dictionary<char, int> counter = new Dictionary<char, int>();
            foreach (var item in s)
            {
                if (!counter.ContainsKey(item))
                {
                    counter.Add(item, 1);
                }
                else
                {
                    counter[item] += 1;
                }
            }

            return (counter.GroupBy(s => s.Value).Select(s => s.Key)).Count() == 1;
        }

        ///https://leetcode.com/problems/isomorphic-strings/
        public static bool IsIsomorphic(string s, string t)
        {
            var mapper1 = new Dictionary<char, char>();
            var mapper2 = new Dictionary<char, char>();
            for (int i = 0; i < s.Length; i++)
            {
                if ((mapper1.ContainsKey(s[i]) && mapper1[s[i]] != t[i]) ||
                   mapper2.ContainsKey(t[i]) && mapper2[t[i]] != s[i])
                {
                    return false;
                }
                else
                {
                    mapper1.TryAdd(s[i], t[i]);
                    mapper1.TryAdd(t[i], s[i]);
                }
            }

            return true;
        }

        ///https://leetcode.com/problems/find-the-difference/
        public static char FindTheDifference(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
            {
                return t[0];
            }
            Dictionary<char, int> k = new Dictionary<char, int>();
            foreach (var item in t)
            {
                if (!k.ContainsKey(item))
                {
                    k.Add(item, 1);
                }
                else
                {
                    k[item] += 1;
                }
            }

            if (k.Any(s => s.Value == 1))
            {
                return k.FirstOrDefault(s => s.Value == 1).Key;
            }
            else
            {
                return k.FirstOrDefault(s => k.Max(o => o.Value) == s.Value).Key;
            }
        }

        ///https://leetcode.com/problems/split-a-string-in-balanced-strings/
        public static int BalancedStringSplit(string s)
        {
            int L = 0;
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'L')
                {
                    L += 1;
                }
                else
                {
                    L -= 1;
                }
                if (L == 0)
                {
                    count += 1;
                }
            }

            return count;
        }

        ///https://leetcode.com/problems/check-if-the-sentence-is-pangram/
        public static bool CheckIfPangram(string sentence)
        {
            HashSet<char> chars = new HashSet<char>();
            for (int i = 0; i < sentence.Length; i++)
            {
                if (!chars.Contains(sentence[i]))
                {
                    chars.Add(sentence[i]);
                }
            }

            return chars.Count == 26;
        }

        ///https://leetcode.com/problems/determine-color-of-a-chessboard-square/
        public static bool SquareIsWhite(string coordinates)
        {
            HashSet<char> oddBlack = new HashSet<char>()
            {
                'a','c','e','g'
            };
            if (oddBlack.Contains(coordinates[0]) && coordinates[1] % 2 != 0 ||
                !oddBlack.Contains(coordinates[0]) && coordinates[1] % 2 == 0)
            {
                return false;
            }
            else
                return true;
        }

        ///https://leetcode.com/problems/reverse-words-in-a-string-iii/
        public static string ReverseWords(string s)
        {
            var splitter = s.Split(" ");
            StringBuilder ss = new StringBuilder();
            StringBuilder sub = new StringBuilder();
            for (int i = 0; i < splitter.Length; i++)
            {
                sub.Clear();
                for (int j = splitter[i].Length - 1; j >= 0; j--)
                {
                    sub.Append(splitter[i][j]);
                }
                ss.Append(sub);
                if (i < (splitter.Length - 1))
                    ss.Append(" ");
            }


            return ss.ToString();
        }

        ///https://leetcode.com/problems/maximum-number-of-words-you-can-type/
        public static int CanBeTypedWords(string text, string brokenLetters)
        {
            HashSet<char> xx = new HashSet<char>(brokenLetters.ToCharArray());
            var splitter = text.Split(" ");
            var count = 0;
            var match = false;
            for (int i = 0; i < splitter.Length; i++)
            {
                match = false;
                for (int j = 0; j < splitter[i].Length; j++)
                {
                    if (xx.Contains(splitter[i][j]))
                    {
                        match = true;
                    }
                }
                if (!match)
                {
                    count++;
                }

            }
            return count;
        }

        ///https://leetcode.com/problems/reformat-phone-number/
        public static string ReformatNumber(string number)
        {
            int i = 0;
            StringBuilder sb = new StringBuilder();
            StringBuilder nums = new StringBuilder();
            while (i < number.Length)
            {
                if (number[i] == ' ' || number[i] == '-')
                {
                    i += 1;
                    continue;
                }
                nums.Append(number[i]);
                i += 1;
            }
            i = 0;
            int subStringLength = 0;
            while (i < nums.Length)
            {
                subStringLength = nums.Length - i;

                if (subStringLength > 4 || subStringLength == 3)
                {
                    sb.Append(nums[i]);
                    sb.Append(nums[i + 1]);
                    sb.Append(nums[i + 2]);
                    sb.Append("-");
                    i += 3;
                }
                else if (subStringLength == 2)
                {
                    sb.Append(nums[i]);
                    sb.Append(nums[i + 1]);
                    sb.Append("-");
                    i += 2;
                }
                else if (subStringLength == 4)
                {
                    sb.Append(nums[i]);
                    sb.Append(nums[i + 1]);
                    sb.Append("-");
                    sb.Append(nums[i + 2]);
                    sb.Append(nums[i + 3]);
                    sb.Append("-");
                    i += 4;
                }
            }

            return sb.ToString(0, sb.Length - 1);
        }

        ///https://leetcode.com/problems/uncommon-words-from-two-sentences/
        public static string[] UncommonFromSentences(string s1, string s2)
        {
            var s1Splitter = s1.Split(" ");
            var s2Splitter = s2.Split(" ");
            var s1Map = new Dictionary<string, int>();

            var s2Map = new Dictionary<string, int>();
            List<string> sd = new List<string>();
            for (int i = 0; i < s1Splitter.Length; i++)
            {
                if (!s1Map.ContainsKey(s1Splitter[i]))
                {
                    s1Map.Add(s1Splitter[i], 1);
                }
                else
                {
                    s1Map[s1Splitter[i]] += 1;
                }
            }

            for (int i = 0; i < s2Splitter.Length; i++)
            {
                if (!s1Map.ContainsKey(s2Splitter[i]))
                {
                    s2Map.Add(s2Splitter[i], 1);
                }
                else
                {
                    s2Map[s2Splitter[i]] += 1;
                }
            }

            foreach (var item in s1Map.Where(s => s.Value == 1))
            {
                if (!s2Map.ContainsKey(item.Key))
                {
                    sd.Add(item.Key);
                }
            }
            foreach (var item in s2Map.Where(s => s.Value == 1))
            {
                if (!s2Map.ContainsKey(item.Key))
                {
                    sd.Add(item.Key);
                }
            }
            return sd.ToArray();
        }

        ///https://leetcode.com/problems/redistribute-characters-to-make-all-strings-equal/
        public static bool MakeEqual(string[] words)
        {
            var allWords = string.Join("", words);

            var vals = new Dictionary<char, int>();
            foreach (var item in allWords)
            {
                if (!vals.ContainsKey(item))
                {
                    vals.Add(item, 1);
                }
                else
                {
                    vals[item] += 1;
                }
            }

            if (vals.ContainsValue(1))
            {
                return false;
            }
            foreach (var item in vals)
            {
                if (item.Value % words.Length != 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// https://leetcode.com/problems/maximum-nesting-depth-of-the-parentheses
        public static int MaxDepth(string s)
        {
            int count = 0;
            int depth = 0;
            foreach (var item in s)
            {
                if (item == '(')
                {
                    depth += 1;
                    count = Math.Max(count, depth);
                }
                else if (item == ')')
                {
                    depth--;
                }
            }

            return Math.Max(count, 0);
        }

        /// https://leetcode.com/problems/largest-substring-between-two-equal-characters/
        public static int MaxLengthBetweenEqualCharacters(string s)
        {
            if (s.Length <= 2)
            {
                return 0;
            }
            Dictionary<char, List<int>> mapper = new Dictionary<char, List<int>>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!mapper.ContainsKey(s[i]))
                {
                    mapper.Add(s[i], new List<int>() { i });
                }
                else
                {
                    if (mapper[s[i]].Count == 1)
                    {
                        mapper[s[i]].Add(i);
                    }
                    else
                    {
                        mapper[s[i]][1] = i;
                    }
                }
            }

            if (mapper.Values.All(s => s.Count == 1))
            {
                return -1;
            }
            int max = 0;
            foreach (var item in mapper.Values.Where(s => s.Count() > 1))
            {
                max = Math.Max(max, Math.Abs(item[0] - (item[1] - 1)));
            }
            return max;
        }

        /// https://leetcode.com/problems/unique-email-addresses/
        public static int NumUniqueEmails(string[] emails)
        {
            HashSet<string> mail = new HashSet<string>();
            StringBuilder alteredMail = new StringBuilder();
            for (int i = 0; i < emails.Length; i++)
            {
                var splitter = emails[i].Split('@');
                alteredMail.Clear();
                for (int j = 0; j < splitter[0].Length; j++)
                {
                    var character = emails[i][j];

                    if (character != '.' && character != '+')
                    {
                        alteredMail.Append(character);
                    }
                    else if (character == '.')
                    {
                        continue;
                    }
                    else if (character == '+')
                    {
                        break;
                    }
                }
                mail.Add((alteredMail.Append('@').Append(splitter[1]).ToString()));
            }

            return mail.Count;
        }

        /// https://leetcode.com/problems/remove-all-adjacent-duplicates-in-string/
        public static string RemoveDuplicates(string s)
        {
            Stack<char> ss = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (ss.Count > 0 && ss.Peek() == s[i])
                {
                    ss.Pop();
                }
                else
                {
                    ss.Push(s[i]);
                }
            }

            return string.Join("", ss.ToArray().Reverse());
        }

        ///https://leetcode.com/problems/maximum-score-after-splitting-a-string/
        public static int MaxScore(string s)
        {
            int max = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                var l = s.Substring(0, i + 1);
                var r = s.Substring(i + 1);

                max = Math.Max(l.Count(s => s == '0') + r.Count(s => s == '1'), max);
            }
            return max;

            //int[] onesCount = new int[s.Length];
            //int[] zerosCount = new int[s.Length];
            //for (int i = 0; i < s.Length; i++)
            //{
            //    if (i != 0)
            //    {
            //        zerosCount[i] += zerosCount[i - 1];
            //        onesCount[s.Length - i - 1] += onesCount[s.Length - i];
            //    }
            //    if (s[i] == '0')
            //        zerosCount[i]++;
            //    if (s[s.Length - i - 1] == '1')
            //        onesCount[s.Length - i - 1]++;
            //}

            //int maxScore = 0;
            //for (int i = 0; i < s.Length - 1; i++)
            //    maxScore = Math.Max(maxScore, zerosCount[i] + onesCount[i + 1]);

            //return maxScore;
        }

        ///https://leetcode.com/problems/maximum-number-of-balloons/
        public static int MaxNumberOfBalloons(string text)
        {
            Dictionary<char, int> x = new Dictionary<char, int>();
            HashSet<char> chars = new HashSet<char>() { 'b', 'a', 'l', 'o', 'n' };

            for (int i = 0; i < text.Length; i++)
            {
                if (!x.ContainsKey(text[i]) && chars.Contains(text[i]))
                {
                    x.Add(text[i], 1);
                }
                else
                {
                    x[text[i]] += 1;
                }
            }
            if (x.Keys.Count < 5)
            {
                return 0;
            }
            x['l'] = x['l'] / 2;
            x['o'] = x['o'] / 2;

            return x.OrderBy(s => s.Value).FirstOrDefault().Value;
        }

        ///https://leetcode.com/problems/find-words-that-can-be-formed-by-characters/
        public static int CountCharacters(string[] words, string chars)
        {
            Dictionary<char, int> o = new Dictionary<char, int>();
            Dictionary<char, int> wordfreq = new Dictionary<char, int>();
            bool escape = false;
            int count = 0;
            foreach (var item in chars)
            {
                if (!o.ContainsKey(item))
                {
                    o.Add(item, 1);
                }
                else
                {
                    o[item] += 1;
                }
            }
            foreach (var word in words)
            {
                escape = false;
                wordfreq.Clear();
                foreach (var character in word)
                {
                    if (!wordfreq.ContainsKey(character))
                    {
                        wordfreq.Add(character, 1);
                    }
                    else
                    {
                        wordfreq[character] += 1;
                    }
                    if (!o.ContainsKey(character) || (wordfreq[character] > o[character]))
                    {
                        escape = true;
                        break;
                    }
                }
                if (escape)
                {
                    continue;
                }
                count += word.Length;
            }

            return count;
        }

        ///https://leetcode.com/problems/long-pressed-name/
        public static bool IsLongPressedName(string name, string typed)
        {
            if (typed.Length < name.Length)
            {
                return false;
            }
            if (name == typed)
            {
                return true;
            }
            var t = 0;
            var n = 0;
            while (t < typed.Length)
            {
                if (n < name.Length && name[n] == typed[t])
                {
                    t += 1;
                    n += 1;
                }
                else if (t != 0 && name[n - 1] == typed[t])
                {
                    t += 1;
                }
                else
                {
                    return false;
                }
            }
            return n == name.Length;
        }

        ///https://leetcode.com/problems/license-key-formatting/
        public static string LicenseKeyFormatting(string s, int k)
        {
            StringBuilder sb = new StringBuilder();
            var pureString = s.Where(s => s != '-').ToList();
            int i = pureString.Count % k;
            int currentSegmentSize = 0;
            if (i > 0)
            {
                for (int j = 0; j < i; j++)
                {
                    sb.Append(pureString[j]);
                }

                if (i < pureString.Count)
                {
                    sb.Append('-');
                }
            }

            for (int x = i; x < pureString.Count; x++)
            {
                currentSegmentSize += 1;
                sb.Append((pureString[x]));

                if (currentSegmentSize == k && x != pureString.Count - 1)
                {
                    sb.Append('-');
                    currentSegmentSize = 0;
                }
            }

            return sb.ToString().ToUpper();
        }

        ///https://leetcode.com/problems/fizz-buzz/
        public static IList<string> FizzBuzz(int n)
        {
            var x = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    x.Add("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    x.Add("Fizz");
                }
                else if (i % 5 == 0)
                {
                    x.Add("Buzz");
                }
                else
                {
                    x.Add(i.ToString());
                }
            }
            return x;
        }

        ///https://leetcode.com/problems/shortest-completing-word/
        public static string ShortestCompletingWord(string licensePlate, string[] words)
        {
            Dictionary<char, int> x = new Dictionary<char, int>();
            Dictionary<char, int> wrd = new Dictionary<char, int>();
            var ans = string.Empty;
            int max = int.MaxValue;
            foreach (var item in licensePlate.ToLower())
            {
                if (char.IsLetter(item) && !x.ContainsKey(item))
                {
                    x.Add(item, 1);
                }
                else if (char.IsLetter(item) && x.ContainsKey(item))
                {
                    x[item] += 1;
                }
            }
            foreach (var item in words)
            {
                wrd.Clear();
                foreach (var c in item.ToLower())
                {
                    if (!wrd.ContainsKey(c) && x.ContainsKey(c))
                    {
                        wrd.Add(c, x[c] - 1);
                    }
                    else if (wrd.ContainsKey(c))
                    {
                        wrd[c] -= 1;
                    }
                }
                if (wrd.Count == x.Count && !wrd.Any(s => s.Value > 0) && max > item.Length)
                {
                    ans = item;
                    max = item.Length;
                }

            }
            return ans;
        }

        ///https://leetcode.com/problems/word-pattern/
        public static bool WordPattern(string pattern, string s)
        {
            var ss = s.Split(" ");
            Dictionary<char, string> chars = new Dictionary<char, string>();
            Dictionary<string, char> words = new Dictionary<string, char>();
            for (int i = 0; i < pattern.Length; i++)
            {
                var word = ss[i];
                var p = pattern[i];
                if ((chars.ContainsKey(p) && chars[p] != word) || (words.ContainsKey(word) && words[word] != p))
                {
                    return false;
                }
                else
                {
                    chars.TryAdd(p, word);
                    words.TryAdd(word, p);
                }
            }
            return true;
        }

        ///https://leetcode.com/problems/student-attendance-record-i/
        public static bool CheckRecord(string s)
        {
            var result = true;
            var a = 0;
            var l = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'A')
                {
                    l = 0;
                    a += 1;
                    if (a == 2)
                    {
                        return false;
                    }
                }
                else if (s[i] == 'L')
                {
                    l += 1;
                    if (l == 3)
                    {
                        return false;
                    }
                }
                else
                {
                    l = 0;
                }
            }


            return result;

        }

        ///https://leetcode.com/problems/most-common-word/
        public static string MostCommonWord(string paragraph, string[] banned)
        {
            HashSet<string> banneds = new HashSet<string>(banned);
            HashSet<char> punctiuation = new HashSet<char>(new char[] { '.', ',', ';', '\'' });
            Dictionary<string, int> dic = new Dictionary<string, int>();
            StringBuilder processedPara = new StringBuilder();

            for (int i = 0; i < paragraph.Length; i++)
            {
                if (char.IsLetter(paragraph[i]))
                {
                    processedPara.Append(paragraph[i]);
                }
                else if (processedPara.Length > 0 && char.IsLetter(paragraph[i - 1]) && (punctiuation.Contains(paragraph[i]) || char.IsWhiteSpace(paragraph[i])))
                {
                    processedPara.Append(" ");
                }
            }
            var words = processedPara.ToString().Split(" ");
            if (banned.Length == 0 && words.Length == 1)
            {
                return words[0];
            }
            for (int i = 0; i < words.Length; i++)
            {
                if (!banneds.Contains(words[i].ToLower()))
                {
                    if (!dic.ContainsKey(words[i].ToLower()))
                    {
                        dic.Add(words[i].ToLower(), 1);
                    }
                    else
                    {
                        dic[words[i].ToLower()] += 1;
                    }
                }
            }
            return dic.OrderByDescending(s => s.Value).FirstOrDefault().Key.ToLower();

        }

        ///https://leetcode.com/problems/make-the-string-great/
        public static string MakeGood(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }
            Stack<char> sb = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {

                if (sb.Count > 0 && Math.Abs((int)(sb.Peek()) - (int)(s[i])) == 32)
                {
                    sb.Pop();
                }
                else
                {
                    sb.Push(s[i]);
                }
            }

            return string.Join("", sb.Reverse());
        }

        ///https://leetcode.com/problems/verifying-an-alien-dictionary/
        public static bool IsAlienSorted(string[] words, string order)
        {
            Dictionary<char, int> xx = new Dictionary<char, int>();
            for (int i = 0; i < order.Length; i++)
            {
                xx.Add(order[i], i);

            }

            for (int i = 0; i < words.Length - 1; i++)
            {
                string word1 = words[i];
                string word2 = words[i + 1];

                if (xcompare(xx, word1, word2))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool xcompare(Dictionary<char, int> xx, string word1, string word2)
        {
            int w1 = 0;
            int w2 = 0;
            bool x = true;
            while (w1 < word1.Length && w2 < word2.Length)
            {
                if (xx[word1[w1]] > xx[word2[w2]])
                {
                    return true;
                }
                else if (xx[word1[w1]] == xx[word2[w2]])
                {
                    w1 += 1;
                    w2 += 1;
                }
                else
                {
                    x = false;
                    break;
                }
            }

            if (x && word1.Length > word2.Length)
            {
                return true;
            }
           
            return false;
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
        private static bool isCharAlphabetic(char s)
        {
            int asciiCode = (int)s;
            return (asciiCode >= 65 && asciiCode <= 90) || (asciiCode >= 97 && asciiCode <= 122);
        }
    }
}
