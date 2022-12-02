using Algorithms.Search;
using System.Data;

namespace AlgoTests
{
    [TestClass]
    public class BinarySearch_Test
    {
        [TestMethod]
        [DataRow("1 4 5 8 12 18 25 59 64", 5, 2)]
        [DataRow("1 4 5 8 12 18 25 59 64", 18, 5)]
        public void VanillaTest(string data, int target, int expected)
        {
            List<int> arr = Helpers.SplitWords(data).Select(int.Parse).ToList();
            Assert.AreEqual(expected, BinarySearch.Vanilla(arr, target));
        }

        [TestMethod]
        [DataRow("false false true true true", 2)]
        [DataRow("false false false false false true true", 5)]
        public void FindFirstTrueInASortedArray(string data, int expected)
        {
            List<bool> arr = Helpers.SplitWords(data).Select(bool.Parse).ToList();
            Assert.AreEqual(expected, BinarySearch.FirstBoundary(arr));
        }

        [TestMethod]
        [DataRow("1 4 5 9", 5, 2)]
        [DataRow("1 4 5 9", 8, 3)]
        [DataRow("3 3 3 3 3 3", 3, 0)]
        public void FirstNotSmaller(string data, int target, int expected)
        {
            List<int> arr = Helpers.SplitWords(data).Select(int.Parse).ToList();
            Assert.AreEqual(expected, BinarySearch.FirstNotSmaller(arr, target));
        }

        [TestMethod]
        [DataRow("1 3 3 5 8", 3, 1)]
        [DataRow("4 6 7 7 7 20", 5, -1)]
        public void FirstInSortedArrayWithDupes(string data, int target, int expected)
        {
            List<int> arr = Helpers.SplitWords(data).Select(int.Parse).ToList();
            Assert.AreEqual(expected, BinarySearch.FirstOcurrence(arr, target));
        }

        [TestMethod]
        [DataRow(1024, 32)]
        [DataRow(2048, 45)]
        [DataRow(8, 2)]
        public void FindSquareRoot(int data, int expected)
        {
            Assert.AreEqual(expected, BinarySearch.SquareRoot(data));
        }
    }    
}
