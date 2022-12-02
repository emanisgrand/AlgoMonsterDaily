namespace AlgoTests
{
    [TestClass]
    public class GFGTests
    {
        /// <summary>
        /// Given an array of distinct elements. The task is to find triplets in the array whose sum is zero.
        /// </summary>
        [TestMethod]
        [DataRow("0 -1 2 -3 1")]
        public void FindTriplestWithZeroSum(string data)
        {
            var arr = Helpers.SplitWords(data).Select(int.Parse).ToArray();
            Assert.AreEqual(arr[1], -1);
        }
    }    
}
