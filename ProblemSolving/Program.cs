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

            Console.WriteLine(string.Join(',', ArraysProblems.InsertionSort(new int[] { 12, 11, 13, 5, 6 })));

        }
    }
}
