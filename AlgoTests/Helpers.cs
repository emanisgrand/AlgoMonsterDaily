using DataStructures;

namespace AlgoTests
{
    internal class Helpers
    {
        // helpers
        public static List<string> SplitWords(string s)
        {
            return string.IsNullOrEmpty(s) ? new List<string>() : s.Trim().Split(' ').ToList();
        }

        public static TreeNode<T> BuildTree<T>(List<string> strs, ref int pos, Func<string, T> f)
        {
            string val = strs[pos];
            pos++;
            if (val == "x") return null;
            TreeNode<T> left = BuildTree<T>(strs, ref pos, f);
            TreeNode<T> right = BuildTree<T>(strs, ref pos, f);
            return new TreeNode<T>(f(val), left, right);
        }
    }
}