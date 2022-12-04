using Algorithms.Search;
using DataStructures;
using TestHelpers;
using System.Data;


namespace AlgoTests
{
    [TestClass]
    public class DepthFirstSearch_Test
    {
        [TestMethod]
        [DataRow("cat")]
        public void PermutationsTest(string letters)
        {
            List<string> res = DFSearch.Permutations(letters);
            res.Sort();
            foreach(string line in res)
            {
                Console.WriteLine(line);
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
            int res = BinarySearchTree.TreeMaxDepth(root);
            Assert.AreEqual(res, expected);            
        }
    }
}
