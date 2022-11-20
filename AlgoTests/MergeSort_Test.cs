using DataStructures;
using Algorithms.Sort;

namespace AlgoTests
{
    [TestClass]
    public class MergeSort_Test
    {
        [TestMethod]
        [DataRow("1 2 4")]
        public void WTFIsGoingOnHere(string l1)
        {
            var arrA = Helpers.SplitWords(l1);
            
            Node<int> listA = Helpers.BuildList<int>(arrA, int.Parse);
            
            MergeSort.WTF(listA);
        }

        [TestMethod]
        [DataRow("1 2 4", "1 3 4", "1 1 2 3 4 4")]
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
