using System;

namespace ProblemSolving
{
    class Program
    {
        static void Main(string[] args)
        {

            var arr = new int[] { 2, 3, 5, 1, 3};
            var arr2 = new int[] { 1, 2, 3, 4};
            //var resu = ArraysProblems.KidsWithCandies(arr, 3);

            var nums = new int[] { 0, 1, 2, 3, 4 };
            var indexes = new int[] { 0, 1, 2, 2, 1 };
            Console.WriteLine(ArraysProblems.CreateTargetArray(nums,indexes));

        }
    }
}
