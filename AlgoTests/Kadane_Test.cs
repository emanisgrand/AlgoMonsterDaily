using Algorithms;
using Algorithms.Search;
using System.Data;

namespace AlgoTests
{
    [TestClass]
    public class Kadane_Test
    {
        [TestMethod]
        [DataRow("4 -1 2 -7 3 4", 7)]
        [DataRow("-8 6 17 -4 9 -2 -15 1 -1 7", 28)]
        public void FindNonEmptySubarrayWithLargestSum(string data, int expected)
        {
            var arr = Helpers.SplitWords(data).Select(int.Parse).ToArray();
            
            var kadaneWindow = Kadane.KadaneWindow(arr);
            foreach (var item in kadaneWindow)
            {
                Console.WriteLine(item);
            }

            Assert.AreEqual(Kadane.KadaneBruteForce(arr), expected);
            Assert.AreEqual(Kadane.KadaneLinear(arr), expected);
        }
    }

    // Given an integer array nums, find the 
    // subarray
    // which has the largest sum and return its sum.

}
