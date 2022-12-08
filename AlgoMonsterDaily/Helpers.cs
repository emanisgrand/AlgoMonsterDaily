using DataStructures;

namespace TestHelpers
{
    public static class TestHelper
    {
        #region String
        public static List<string> SplitWords(string s)
        {
            return string.IsNullOrEmpty(s) ? new List<string>() : s.Trim().Split(' ').ToList();
        }

        public static List<string> FormatList<T>(Node<T> node)
        {
            List<string> strList = new List<string>();
            while (node != null)
            {
                strList.Add(node.val.ToString());
                node = node.next;
            }
            return strList;
        }
        #endregion
        #region Linked List 
        public static Node<T> BuildList<T>(List<string> strs, Func<string, T> f)
        {
            Node<T> node = null;
            for (int i = strs.Count -1; i >= 0; i--)
            {
                node = new Node<T>(f(strs[i]), node);
            }
            return node;
        }
        #endregion
        #region Graph 
        public static TreeNode<T> BuildTree<T>(List<string> strs, ref int pos, Func<string, T> f)
        {
            string val = strs[pos];
            pos++;
            if (val == "x") return null;
            TreeNode<T> left = BuildTree<T>(strs, ref pos, f);
            TreeNode<T> right = BuildTree<T>(strs, ref pos, f);
            return new TreeNode<T>(f(val), left, right);
        }
        #endregion
    }
}