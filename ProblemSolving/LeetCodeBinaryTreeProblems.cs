using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProblemSolving
{
    class LeetCodeBinaryTreeProblems
    {
        public static IList<T> PreorderTraversal<T>(TreeNode<T> root)
        {
            var result = new List<T>();
            if (root == null) return result;

            var stack = new Stack<TreeNode<T>>();
            stack.Push(root);

            while (stack.Any())
            {
                var cur = stack.Pop();
                result.Add(cur.val);

                if (cur.right != null)
                {
                    stack.Push(cur.right);
                }

                if (cur.left != null)
                {
                    stack.Push(cur.left);
                }
            }

            return result;
        }
        public static IList<T> InorderTraversal<T>(TreeNode<T> root)
        {
            var result = new List<T>();
            if (root == null) return result;

            var stack = new Stack<TreeNode<T>>();

            while (root != null || stack.Count > 0)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                var curr = stack.Pop();

                result.Add(curr.val);

                root = curr.right;
            }

            return result;
        }
        public static IList<T> PostorderTraversal<T>(TreeNode<T> root)
        {
            IList<T> res = new List<T>();
            Stack<TreeNode<T>> s = new Stack<TreeNode<T>>();

            while (root != null || s.Count > 0)
            {
                while (root != null)
                {
                    s.Push(root);
                    root = root.left;
                }

                if (s.Peek().right != null)
                    root = s.Peek().right;
                else
                {
                    TreeNode<T> cur = s.Pop();

                    res.Add(cur.val);

                    while (s.Count > 0 && s.Peek().right == cur)
                    {
                        cur = s.Pop();
                        res.Add(cur.val);
                    }
                }
            }

            return res;

        }

        public static IList<IList<T>> LevelOrder<T>(TreeNode<T> root)
        {
            if (root == null)
            {
                return new List<IList<T>>();
            }
            List<IList<T>> result = new List<IList<T>>();
            int level = 0;
            Order(root, result, level);
            return result;
            //int sizeInLevel = 0;
            //IList<IList<T>> results = new List<IList<T>>();
            //IList<T> resultInLevel = null;
            //Queue<TreeNode<T>> level = new Queue<TreeNode<T>>();
            //TreeNode<T> currentNode = null;

            //level.Enqueue(root);

            //while (level.Count != 0)
            //{
            //    sizeInLevel = level.Count;
            //    resultInLevel = new List<T>();
            //    while (sizeInLevel > 0)
            //    {
            //        currentNode = level.Dequeue();

            //        if (currentNode.left != null)
            //            level.Enqueue(currentNode.left);
            //        if (currentNode.right != null)
            //            level.Enqueue(currentNode.right);

            //        resultInLevel.Add(currentNode.val);
            //        sizeInLevel--;
            //    }
            //    results.Add(resultInLevel);
            //}

           // return results;
        }

        public static void Order<T>(TreeNode<T> root, List<IList<T>> list, int level)
        {
            if (root == null)
            {
                return;
            }

            if (list.Count == level)
            {
                list.Add(new List<T>());
            }

            list.ElementAt(level).Add(root.val);

            if (root.left != null)
            {
                Order(root.left, list, level + 1);
            }
            if (root.right != null)
            {
                Order(root.right, list, level + 1);
            }
        }
    }
}
