using DataStructures;
using Algorithms.Sort;
using TestHelpers;

namespace AlgoTests
{
    [TestClass]
    public class MergeSort_Test
    {
        [TestMethod]
        [DataRow("1 2 4", "1 3 4", "1 1 2 3 4 4")]
        [DataRow("4 2 4", "3 3 8", "3 3 4 2 4 8")]
        [DataRow("1 3 5 8 9", "4 7 9 12 15", "1 3 4 5 7 8 9 9 12 15")]
        public void MergeSortTest(string l1, string l2, string expected)
        {
            var arrA = Helpers.SplitWords(l1);
            var arrB = Helpers.SplitWords(l2);
            
            Node<int> listA = Helpers.BuildList<int>(arrA, int.Parse);
            Node<int> listB = Helpers.BuildList<int>(arrB, int.Parse);
            
            Node<int> res = MergeSort.Merge(listA, listB);
            
            List<string> resArr = Helpers.FormatList<int>(res);
            
            Assert.AreEqual(String.Join(' ', resArr), expected);
        }
    }   
}
