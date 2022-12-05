using Algorithms.Search;
using TestHelpers;

namespace AlgoTests
{
    [TestClass]
    public class GFG_Test
    {
        /// <summary>
        /// Given an array of distinct elements. The task is to find triplets in the array whose sum is zero.
        /// </summary>
        [TestMethod]
        [DataRow("0 -1 2 -3 1")]
        public void FindTripletsWithZeroSum(string data)
        {
            var arr = Helpers.SplitWords(data).Select(int.Parse).ToArray();

            var triplets = GFG.FindTriplets(arr, arr.Length);

            if (triplets.Count == 0) { Console.WriteLine("none exists"); }
        }
    }    
}
