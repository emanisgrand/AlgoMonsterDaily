using DataStructures;
using System.Data;

namespace AlgoTests
{
    [TestClass]
    public class LRUCache_Leetcode_Test
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
            
            cache.Put(outlier, outlier+7);
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
