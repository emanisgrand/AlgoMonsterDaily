using DataStructures;

namespace Algorithms.Search
{
    public static class DFSearch
    {
        public static void dfs(int startIndex, List<string> res, bool[] used, List<char> path, string letters)
        {
            if (startIndex == used.Length)
            {
                res.Add(String.Join("", path));
                return;
            }

            for (int i = 0; i < used.Length; i++)
            {
                // stack iterate condition
                if (used[i]) continue;

                path.Add(letters[i]);
                used[i] = true;
                dfs(startIndex + 1, res, used, path, letters);

                path.RemoveAt(path.Count - 1);
                used[i] = false;
            }
        }

        public static List<string> Permutations(string letters)
        {
            List<string> res = new List<string>();
            dfs(0, res, new bool[letters.Length], new List<char>(), letters);
            return res;
        }
        
    }

    public static class BinarySearchTree
    {
        private static int dfs(TreeNode<int> root)
        {
            if (root == null) return 0;
            return Math.Max(dfs(root.left), dfs(root.right)) + 1;
        }
        public static int TreeMaxDepth(TreeNode<int> root)
        {
            return (root != null) ? dfs(root) - 1 : 0;
        }

        private static bool DFS(TreeNode<int> root, int min, int max)
        {
            if (root == null) return true;
            if (!(min <= root.val && root.val <= max)) return false;

            return DFS(root, min, root.val) && DFS(root, root.val, max);
        }

        public static bool IsValidBST(TreeNode<int> root)
        {
            return DFS(root, Int32.MinValue, Int32.MaxValue);
        }

        public static TreeNode<int> InsertBST(TreeNode<int> bst, int val)
        {
            if (bst == null) return new TreeNode<int>(val);
            int compareVal = bst.val.CompareTo(val);
            if (compareVal < 0) bst.right = InsertBST(bst.right, val);
            else if (compareVal > 0) bst.left = InsertBST(bst.left, val);

            return bst;
        }

        public static TreeNode<int> InvertBST(TreeNode<int> tree)
        {
            if (tree == null) return null;
            return new TreeNode<int>(tree.val, InvertBST(tree.right), InvertBST(tree.left));
        }
    }
}