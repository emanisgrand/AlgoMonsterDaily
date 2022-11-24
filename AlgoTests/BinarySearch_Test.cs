using Algorithms.Search;
using System.Data;
using System.Collections.Generic;

namespace AlgoTests
{
    [TestClass]
    public class BinarySearch_Test
    {
        [TestMethod]
        [DataRow("false false true true true", 2)]
        [DataRow("false false false false false true true", 5)]
        public void FindFirstTrueInASortedArray(string data, int expected)
        {
            List<bool> arr = Helpers.SplitWords(data).Select(bool.Parse).ToList();
            Assert.AreEqual(expected, BinarySearch.FirstBoundary(arr));
        }
    }    
}
