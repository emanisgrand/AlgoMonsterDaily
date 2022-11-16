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
        private static int dfs(TreeNode<int> root)
        {
            if (root == null) return 0;
            return Math.Max(dfs(root.left), dfs(root.right)) + 1;
        }

        public static int TreeMaxDepth(TreeNode<int> root)
        {
            return (root != null) ? dfs(root) - 1 : 0;
        }
    }
}
