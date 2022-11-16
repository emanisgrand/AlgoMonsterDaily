using DataStructures;

namespace Algorithms.BST
{
    public class BinarySearchTree
    {
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
            else if (compareVal > 0) bst.left =  InsertBST(bst.left, val);

            return bst;
        } 
        
        public static TreeNode<int> InvertBST(TreeNode<int> tree)
        {
            if (tree == null) return null;
            return new TreeNode<int>(tree.val, InvertBST(tree.right), InvertBST(tree.left));
        }
    }
}
