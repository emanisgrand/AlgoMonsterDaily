using Algorithms.DFS;
using DataStructures;
using System.Data;

namespace AlgoTests
{
    [TestClass]


    public class AlgorithmsTest_DFS
    {
        [TestMethod]
        [DataRow("cat")]
        public void PermutationsTest(string letters)
        {
            List<string> res = new List<string>();
            dfs(0, res, new bool[letters.Length], new List<char>(), letters);
        }

        public static void dfs(int startIndex, List<string> res, bool[] used, List<char> path, string letters)
        {
            if (startIndex == used.Length)
            {
                res.Add(String.Join("", path));
                return;
            }

            for (int i=0; i<used.Length; i++)
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

        [TestMethod]
        [DataRow("5 4 3 x x 8 x x 6 x x", 2)]
        [DataRow("6 x 9 x 11 x 7 x x", 3)]
        [DataRow("1 x x", 0)]
        [DataRow("x", 0)]
        public void MaxDepthOfABinaryTree(string inputString, int expected)
        {
            var strs = Helpers.SplitWords(inputString);
            int pos = 0;
            TreeNode<int> root = Helpers.BuildTree(strs, ref pos, int.Parse);
            int res = DepthFirstSearch.TreeMaxDepth(root);
            Assert.AreEqual(res, expected);            
        }
    }
}
