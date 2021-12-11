using System;
using System.Linq;

namespace ProblemSolving
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new TreeNode<char>('F');
            tree.left = new TreeNode<char>('B');
            tree.left.left = new TreeNode<char>('A');
            tree.left.right = new TreeNode<char>('D');
            tree.left.right.left = new TreeNode<char>('C');
            tree.left.right.right = new TreeNode<char>('E');

            tree.right = new TreeNode<char>('G');
            tree.right.right = new TreeNode<char>('I');
            tree.right.right.left = new TreeNode<char>('H');

            var head = new ListNode<int>(1);
            head.next = new ListNode<int>(2);
            head.next.next = new ListNode<int>(3);
            head.next.next.next = new ListNode<int>(4);

            //var resu = LeetCodeBinaryTreeProblems.LevelOrder<char>(tree);

            LeetCodeRandomEasyProblems.SortedSquares(new int[] {-4, -1, 0, 3, 10 });

        }
    }
}
