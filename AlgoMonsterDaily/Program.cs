using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoMonsterDaily
{
    class Program
    {
        public static void Main()
        {
            List<string> strs = DFS.SplitWords("1 2 4 x x 5 6 x x x 3 x x");
            int pos = 0;
            TreeNode<int> root = DFS.BuildTree(strs, ref pos, int.Parse);
            Console.WriteLine(DFS.Serialize(BST.InvertBST(root)));
         }
    }
}
