using Algorithms.DFS;
using DataStructures;
using System.Data;

namespace AlgoTests
{
    [TestClass]
    public class AlgorithmsTest_DFS
    {
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
