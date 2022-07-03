namespace AlgoMonsterDaily
{
    public class BST
    {
        public static bool ValidBST(TreeNode<int> root)
        {
            return DFS(root, Int32.MinValue, Int32.MaxValue);
        }
       
        public static bool DFS(TreeNode<int> root, int min, int max)
        {
            // empty nodes always return true
            if (root == null) return true;

            if (!(min <= root.val && root.val <= max)) return false;

            return DFS(root.left, min, root.val) && DFS(root.right, root.val, max); 
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
