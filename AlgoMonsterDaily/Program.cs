using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoMonsterDaily
{
    class Program
    {
        public static void Main()
        {
            List<string> strs = DFS.SplitWords("37 19 2 x x 28 23 x x 35 x x 44 x 58 52 x x 67 x x");
            int pos = 0;
            Node<int> root = DFS.BuildTree(strs, ref pos, int.Parse);
            Node<int> result = BST.InsertBST(root, 42);
            Console.WriteLine(DFS.Serialize(result));
         }
    }
}
