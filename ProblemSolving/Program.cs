using System;
using System.Linq;

namespace ProblemSolving
{
    class Program
    {
        static void Main(string[] args)
        {

            var arr = new int[] { 2, 3, 5, 1, 3 };
            var arr2 = new int[] { 1, 2, 3, 4 };
            //var resu = ArraysProblems.KidsWithCandies(arr, 3);

            var nums = new int[] { 0, 1, 2, 3, 4 };
            var indexes = new int[] { 0, 1, 2, 2, 1 };

            var searchNums = new int[] { 1, 4, 5, 6, 7, 8, 12, 23, 56, 77, 81 };

            //ArraysProblems.BinarySearch(searchNums, 81);
            //var x = new int[] { 12, 9, 3, 7, 14, 11, 6, 2, 10, 5 };
            //ArraysProblems.MergeSort(x, 0, x.Length - 1);
            //Console.WriteLine(string.Join(',', x));

            var countX = new int[] { 4, 1, 5, 0, 1, 6, 5, 1, 5, 3 };

            var equal = ArraysProblems.COUNTKEYSEQUAL(countX, countX.Length, 7);

            //Console.WriteLine( LeetCodeRandomEasyProblems.NumIdenticalPairs(new int[] { 1, 2, 3, 1, 1, 3 }));
            //Console.WriteLine(string.Join(',', LeetCodeRandomEasyProblems.CountKDifference(new int[] { 1,2,2 ,1 },1)));
            //Console.WriteLine(LeetCodeRandomEasyProblems.ShortestCompletingWord("Ah71752", 
            //    new string[] { "suggest", "letter", "of", "husband", "easy", "education", "drug", "prevent", "writer", "old" }));
            Console.WriteLine(LeetCodeRandomEasyProblems.IsAlienSorted(new string[] { "kuvp", "q" }, "ngxlkthsjuoqcpavbfdermiywz"));
            //Console.WriteLine(LeetCodeRandomEasyProblems.IsValidParentheses("(("));
        }
    }
}
