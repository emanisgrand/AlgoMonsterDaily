using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoMonsterDaily
{
    class Program
    {
        public IList<int> InorderTraversal(TreeNode<int> root)
        {
            IList<int> list = new List<int>();
            return list;
        }
        public static void Main()
        {
            //List<string> strs = DFS.SplitWords("1 2 4 x 7 x x 5 x x 3 x 6 x x");
            List<bool> strs = new List<bool>{false, true, false, true, true};
            int target = 12;
            //TreeNode<int> root = DFS.BuildTree(strs, ref pos, int.Parse);
            var res = BinarySearch.FindBoundary(strs);
            Console.WriteLine(res);
         }
    }
}
