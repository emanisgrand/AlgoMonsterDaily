using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;

namespace Algorithms.DFS
{
    public class DepthFirstSearch
    {
        #region dfs
        /// <summary>
        /// Binary Tree dfs algorithm
        /// </summary>
        /// <param name="root"></param>
        /// <returns>max depth of a binary tree/returns>
        private static int dfs(TreeNode<int> root)
        {
            if (root == null) return 0;
            return Math.Max(dfs(root.left), dfs(root.right)) + 1;
        }

        /// <summary>
        /// depth search for permutations
        /// </summary>
        /// <param name="startIndex">starting index of input</param>
        /// <param name="path">input characters</param>
        /// <param name="used">boolean array length of input string</param>
        /// <param name="res">list of strings stores results</param>
        /// <param name="letters">I have no idea what purpose this serves</param>
        private static void dfs(int startIndex, List<char> path, bool[] used, List<string> res, string letters)
        {
            if (startIndex == used.Length)
            {
                res.Add(String.Join("", path));
                return;
            }
            for (int i=0; i<used.Length; i++)
            {
                // skip used letters
                if (used[i]) continue;
                // add letter to permutation, mark letter as used
                path.Add(letters[i]);
                used[i] = true;
                dfs(startIndex + 1, path, used, res, letters);
                // remove letter from permutation, mark letter as unused
                path.RemoveAt(path.Count - 1);
                used[i] = false;
            }
        }
        #endregion

        public static List<string> Premutations(string letters)
        {
            List<string> res = new List<string>();
            dfs(0, new List<char>(letters), new bool[letters.Length], res, letters);
            return res;
        }

        public static int TreeMaxDepth(TreeNode<int> root)
        {
            return (root != null) ? dfs(root) - 1 : 0;
        }
    }
}


/*
        public IList<int> InorderTraversal(TreeNode<int> root)
        {
            IList<int> list = new List<int>();
            return list;
        }
        public static int TreeMaxDepth(TreeNode<int> root)
        {
            if (root == null) return 0;
            return Math.Max(TreeMaxDepth(root.left), TreeMaxDepth(root.right)) + 1;
        }
        public static int VisibleTreeNode(TreeNode<int> root)
        {
            return dfs(root, Int32.MinValue);
        }
        private static int dfs(TreeNode<int> root, int maxSoFar)
        {
            if (root == null) return 0;
            int visible = 0;

            if (root.val > maxSoFar)
                visible++;

            visible += dfs(root.left, Math.Max(maxSoFar, root.val));
            visible += dfs(root.right, Math.Max(maxSoFar, root.val));

            return visible;
        }

        public static int TreeHeight(TreeNode<int> tree)
        {
            if (tree == null) return 0;

            int leftHeight = TreeHeight(tree.left);
            int rightHeight = TreeHeight(tree.right);

            if (leftHeight == -1 || rightHeight == -1)
                return -1;
            // calculate difference of heigt of subtree
            if (Math.Abs(leftHeight - rightHeight) > 1)
                return -1;

            // similar to TreeMaxDepth
            return Math.Max(leftHeight, rightHeight) + 1;

        }
        public static bool IsBalanced(TreeNode<int> tree)
        {
            return TreeHeight(tree) != -1;
        }

        public static TreeNode<int> Deserialize(string root)
        {
            // use this function to create and store the reference to pos.
            int pos = 0;
            return DeserializeDFS(root.Split(" ").ToList(), ref pos);
        }

        public static TreeNode<int> DeserializeDFS(List<string> nodes, ref int pos)
        {
            string val = nodes[pos];
            pos++;

            if (val == "x") return null;


            TreeNode<int> cur = new TreeNode<int>(int.Parse(val));
            cur.left = DeserializeDFS(nodes, ref pos);
            cur.right = DeserializeDFS(nodes, ref pos);
            return cur;
        }
        public static string Serialize(TreeNode<int> root)
        {
            List<string> res = new List<string>();
            SerializeDFS(root, res);
            return string.Join(" ", res);
        }
        public static void SerializeDFS(TreeNode<int> root, List<string> result)
        {
            if (root == null)
            {
                result.Add("x");
                return;
            }
            result.Add(root.val.ToString());
            SerializeDFS(root.left, result);
            SerializeDFS(root.right, result);
        }
        // Lowest Common Ancestor
        public static TreeNode<int> Lca(TreeNode<int> root, TreeNode<int> node1, TreeNode<int> node2)
        {
            if (root == null) return null;

            //2 
            if (Object.ReferenceEquals(root, node1) || Object.ReferenceEquals(root, node2))
                return root;
            TreeNode<int> left = Lca(root.left, node1, node2);
            TreeNode<int> right = Lca(root.right, node1, node2);

            //1
            if (left != null && right != null) return root;

            // 4 & 5
            if (left != null) return left;
            if (right != null) return right;

            // 3
            return null;
        }

        public static TreeNode<int> FindNode(TreeNode<int> root, int target)
        {
            if (root == null) return null;

            if (root.val == target) return root;

            TreeNode<int> leftSearch = FindNode(root.left, target);
            if (leftSearch != null) return leftSearch;

            return FindNode(root.right, target);
        }
        public static void PrintTree<T>(TreeNode<T> root, List<string> tree)
        {
            if (root == null)
            {
                tree.Add("x");
            }
            else
            {
                tree.Add(root.val.ToString());
                PrintTree(root.left, tree);
                PrintTree(root.right, tree);
            }
        }
        */