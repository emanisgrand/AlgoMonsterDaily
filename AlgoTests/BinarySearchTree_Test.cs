using Algorithms.Search;
using System.Data;

namespace AlgoTests
{
    [TestClass]
    public class BinarySearchTree_Test
    {
        [TestMethod]
        [DataRow("6 4 3 x x 5 x x 8 x x", true)]
        [DataRow("6 4 3 x x 8 x x 8 x x", false)]
        public void TestValidBST(string inputString, bool expected)
        { 
            var strs = Helpers.SplitWords(inputString);
            int pos = 0;
            var root = Helpers.BuildTree(strs, ref pos, int.Parse);
            // Test is currently broken.
            Assert.AreNotEqual(1, 1);
        }
    }    
}
