using DataStructures;
using Algorithms.Search;
using System.Data;

namespace AlgoTests
{
    [TestClass]
    public class AlgorithmsTest_BST
    {
        [TestMethod]
        [DataRow("6 4 3 x x 5 x x 8 x x", true)]
        [DataRow("6 4 3 x x 8 x x 8 x x", false)]
        public void TestValidBST(string inputString, bool expected)
        { 
            // initialize tree
            var strs = Helpers.SplitWords(inputString);
            int pos = 0;
            var root = Helpers.BuildTree(strs, ref pos, int.Parse);
            
            Assert.AreEqual(BinarySearchTree.IsValidBST(root), expected);
        }
    }    
}
