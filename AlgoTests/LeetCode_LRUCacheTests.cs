using AlgoMonsterDaily;
using Algorithms.TwoPointers;
using DataStructures;
using System.Data;

namespace AlgoTests
{
    [TestClass]
    public class LeetCode_LRUCacheTests
    {
        [TestMethod]
        [DataRow(2)]
        [DataRow(20)]
        [DataRow(2000)]
        public void LinkedLRUCache_GetFunctionReturnsKey(int capacity)
        {
            var cache = new LinkedLRUCache((uint)capacity);
            int outlier = 0;
            for (int i = 1; i < capacity; i++)
            {
                cache.Put(i, i);
                Assert.AreEqual(cache.Get(i), i);
                outlier = i++;
            }
            
            cache.Put(outlier, outlier);
            Assert.AreEqual(cache.Get(outlier), outlier);
            Assert.AreEqual(cache.Get(0), -1);
            Assert.AreEqual(cache.Get(20), -1);
        }

        [TestMethod]
        public void LinkedLRUCache_()
        {
            var cache = new LinkedLRUCache(2);
            cache.Put(1, 1);
            cache.Put(2, 2);
            Assert.AreEqual(cache.Get(1), 1);
        }
        [TestMethod]
        public void LinkedLRUCacheCapacityCanBeSet()
        {
            var cache = new LinkedLRUCache(2);
            cache.Put(1, 1);
            cache.Put(2, 2);
            Assert.AreEqual(cache.Get(1), 1);
            cache.Put(3, 3);
            Assert.AreEqual(cache.Get(1), -1);
            Assert.AreEqual(cache.Get(3), 3);
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
