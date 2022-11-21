using DataStructures;
using Algorithms.Sort;

namespace AlgoTests
{
    [TestClass]
    public class MergeSort_Test
    {
        [TestMethod]
        [DataRow("1 2 4", "1 3 5")]
        public void WTFIsGoingOnHere(string l1, string l2)
        {
            var arrA = Helpers.SplitWords(l1);
            var arrB = Helpers.SplitWords(l2);
            Node<int> nodeListA = Helpers.BuildList<int>(arrB, int.Parse);
            Node<int> nodeListB = Helpers.BuildList<int>(arrA, int.Parse);

        }

        [TestMethod]
        [DataRow("1 2 4", "1 3 4", "1 1 2 3 4 4")]
        [DataRow("4 2 4", "3 3 8", "3 3 4 2 4 8")]
        public void MergeSortTest(string l1, string l2, string expected)
        {
            var arrA = Helpers.SplitWords(l1);
            var arrB = Helpers.SplitWords(l2);
            Node<int> listA = Helpers.BuildList<int>(arrA, int.Parse);
            Node<int> listB = Helpers.BuildList<int>(arrB, int.Parse);
            Node<int> res = MergeSort.Merge(listA, listB);
            List<string> resArr = Helpers.FormatList<int>(res);
            
            Console.WriteLine(String.Join(" ", resArr));    
            Assert.AreEqual(String.Join(' ', resArr), expected);
        }
    }   
}
