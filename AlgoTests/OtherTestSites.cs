using DataStructures;
using TestHelpers;
namespace GeeksForGeeks.Tests
{
    [TestClass]
    public class GFGPractice
    {
        [TestMethod]
        [DataRow("0 -1 2 -3 1")]
        public void FindTripletsWithZeroSum(string data)
        {
            var arr = TestHelper.SplitWords(data).Select(int.Parse).ToArray();

            var triplets = Triplets.FindTriplets(arr, arr.Length);

            if (triplets.Count == 0) { Console.WriteLine("none exists"); }
        }
    }    
}
namespace Algorithms.Tests
{
    [TestClass]
    public class NeetCodeAdvancedCourse
    {
        #region Kadane's Algorithm
        [TestMethod]
        [DataRow("4 -1 2 -7 3 4", 7)]
        [DataRow("-8 6 17 -4 9 -2 -15 1 -1 7", 28)]
        public void FindNonEmptySubarrayWithLargestSum(string data, int expected)
        {
            var arr = TestHelper.SplitWords(data).Select(int.Parse).ToArray();

            var kadaneWindow = Kadane.KadaneWindow(arr);
            foreach (var item in kadaneWindow)
            {
                Console.WriteLine(item);
            }

            Assert.AreEqual(Kadane.KadaneBruteForce(arr), expected);
            Assert.AreEqual(Kadane.KadaneLinear(arr), expected);
        }
        #endregion
    }
}
namespace Leetcode.Tests
{
    [TestClass]
    public class LRUCacheTest
    {
        [TestMethod]
        [DataRow(2)]
        [DataRow(5)]
        [DataRow(20)]
        [DataRow(2000)]
        public void LRUCache_RandomValues_OverFitting(int capacity)
        {
            var cache = new LRUCache(capacity);
            int outlier = 0;
            for (int i = 1; i < capacity; i++)
            {
                int r = new Random(i % capacity * new Random().Next(99)).Next(99);
                cache.Put(i, r);
                Assert.AreEqual(cache.Get(i), r);
                outlier = i++;
            }

            cache.Put(outlier, outlier + 7);
            Assert.AreEqual(cache.Get(2), -1);
            cache.Put(4, 16);
            cache.Put(5, 25);
            cache.Put(8, 64);
            Assert.AreEqual(cache.Get(20), -1);
        }

        [TestMethod]
        [DataRow(2)]
        [DataRow(5)]
        [DataRow(20)]
        [DataRow(2000)]
        public void LRUCache_OverFitting(int capacity)
        {
            var cache = new LRUCache(capacity);
            int outlier = 0;
            for (int i = 1; i < capacity; i++)
            {
                cache.Put(i, i);
                Assert.AreEqual(cache.Get(i), i);
                outlier = i++;
            }

            cache.Put(outlier, outlier + 7);
            Assert.AreEqual(cache.Get(2), -1);
            cache.Put(4, 16);
            cache.Put(5, 25);
            cache.Put(8, 64);
            Assert.AreEqual(cache.Get(20), -1);
        }

        [TestMethod]
        [DataRow(2)]
        [DataRow(20)]
        [DataRow(2000)]
        public void LRUCache_GetFunctionReturnsKey(int capacity)
        {
            var cache = new LRUCache(capacity);
            int outlier = 0;
            for (int i = 1; i < capacity; i++)
            {
                cache.Put(i, i);
                Assert.AreEqual(cache.Get(i), i);
                outlier = i++;
            }

            cache.Put(outlier, outlier + 7);
            Assert.AreEqual(cache.Get(2), -1);
            cache.Put(4, 8);
            Assert.AreEqual(cache.Get(4), 8);
            Assert.AreEqual(cache.Get(20), -1);
        }

        [TestMethod]
        public void LRUCache_()
        {
            var cache = new LRUCache(2);
            cache.Put(1, 1);
            cache.Put(2, 2);
            Assert.AreEqual(cache.Get(1), 1);
        }

        [TestMethod]
        public void LRUCacheCapacityCanBeSet()
        {
            var cache = new LRUCache(2);
            cache.Put(1, 1);
            cache.Put(2, 2);
            Assert.AreEqual(cache.Get(1), 1);
            cache.Put(3, 3);
            Assert.AreEqual(cache.Get(1), 1);
            Assert.AreEqual(cache.Get(2), -1);
        }

        [TestMethod]
        public void LRUCacheRejectsInputsThatArentInTheCache()
        {
            var cache = new LRUCache(2);
            cache.Put(1, 1);
            cache.Put(2, 2);
            Assert.AreEqual(cache.Get(3), -1);
        }
    }
}