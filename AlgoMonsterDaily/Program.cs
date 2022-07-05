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

        public static int Mod(int x, int y)
        {
            while (x >= y)
            {
                x -= y;
            }
            return x;
        }
        public static void Main()
        {
            //List<string> strs = DFS.SplitWords("1 2 4 x 7 x x 5 x x 3 x 6 x x");
            List<int> strs = new List<int>{1, 2, 3, 3, 3, 6, 6, 6, 10, 12, 189};
            int target = 6;
            //TreeNode<int> root = DFS.BuildTree(strs, ref pos, int.Parse);
            var res = Mod(100, 27);
            Console.WriteLine(res);
         }
    }
}
