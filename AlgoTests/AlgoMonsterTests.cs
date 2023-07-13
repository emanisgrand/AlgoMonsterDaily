using AlgoMonster;
using TestHelpers;
using System.Data;
using DataStructures;
using System.Security.Cryptography.X509Certificates;
using AlgoMonsterDaily;

namespace DynamicProgramming{

    [TestClass]
    public class DynamicProgrammingTests{
        [TestMethod]
        [DataRow("1 2 3 1", 4)]
				[DataRow("7 4 9 5 6 2 1", 23)]
        [DataRow("1", 1)]
				public void HouseRobberTest(string data, int expected){
						
            AlgoMonsterDaily.DynamicProgrammingClass dpClass = new AlgoMonsterDaily.DynamicProgrammingClass();

            List<int> nums= data.Split(' ').Select(int.Parse).ToList();
            
						int actual = dpClass.AdvRobber(nums);

						Assert.AreEqual(expected, actual);
				}

        [TestMethod]
        [DataRow(12, 233)]
        public void MinCostCliminbStairsTest(int n, int expected){
            AlgoMonsterDaily.DynamicProgrammingClass dpClass = new AlgoMonsterDaily.DynamicProgrammingClass();
            
            int[] dpList = new int[n+1]; 
            
            int resultOf = dpClass.MinCostClimbingStairs(dpList);

            //Assert.AreEqual(expected, resultOf);
        }
    
        [TestMethod]
        [DataRow(12, 233)]
        public void ClimbStairsTest(int data, int expected){
            AlgoMonsterDaily.DynamicProgrammingClass dpClass = new AlgoMonsterDaily.DynamicProgrammingClass();
            
            int resultOf = dpClass.ClimbingStairs(data);
            
            Assert.AreEqual(resultOf, expected);
        }
    }
}
namespace BinarySearch
{
    [TestClass]
    public class SortedArrays
    {
        [TestMethod]
        [DataRow("1 4 5 8 12 18 25 59 64", 5, 2)]
        [DataRow("1 4 5 8 12 18 25 59 64", 18, 5)]
        public void VanillaBinarySearchTest(string data, int target, int expected)
        {
            List<int> arr = data.Split(' ').Select(int.Parse).ToList();
            Assert.AreEqual(expected, AlgoMonster.BinarySearch.Vanilla(arr, target));
        }

        [TestMethod]
        [DataRow("false false true true true", 2)]
        [DataRow("false false false false false true true", 5)]
        public void FindFirstTrueElement(string data, int expected)
        {
            List<bool> arr = data.Split(' ').Select(bool.Parse).ToList();
            Assert.AreEqual(expected, AlgoMonster.BinarySearch.FirstBoundary(arr));
        }

        [TestMethod]
        [DataRow("1 4 5 9", 5, 2)]
        [DataRow("1 4 5 9", 8, 3)]
        [DataRow("3 3 3 3 3 3", 3, 0)]
        public void FirstNotSmaller(string data, int target, int expected)
        {
            List<int> arr = data.Split(' ').Select(int.Parse).ToList();
            Assert.AreEqual(expected, AlgoMonster.BinarySearch.FirstNotSmaller(arr, target));
        }

        [TestMethod]
        [DataRow("1 3 3 5 8", 3, 1)]
        [DataRow("4 6 7 7 7 20", 5, -1)]
        public void FirstOcurrenceInAnArrayWithDuplicates(string data, int target, int expected)
        {
            List<int> arr = data.Split(' ').Select(int.Parse).ToList();
            Assert.AreEqual(expected, AlgoMonster.BinarySearch.FirstOcurrence(arr, target));
        }

        [TestMethod]
        [DataRow(1024, 32)]
        [DataRow(2048, 45)]
        [DataRow(8, 2)]
        public void FindSquareRoot(int data, int expected)
        {
            Assert.AreEqual(expected, AlgoMonster.BinarySearch.SquareRoot(data));
        }
    }    
}
namespace TwoPointers
{
    [TestClass]
    public class SameDirection
    {
        [TestMethod]
        [DataRow(new int[] { 1, 0, 2, 0, 0, 7 }, new int[] { 1, 2, 7, 0, 0, 0 })]
        public void MoveZeroesInPlace(int[] input, int[] expected)
        {
            int slow = 0;
            for (int fast = 0; fast < input.Length; fast++)
            {
                if (input[fast] != 0)
                {
                    int temp = input[fast];
                    input[fast] = 0;
                    input[slow] = temp;
                    slow++;
                }
            }
            CollectionAssert.AreEqual(input, expected);
        }
    }
}
namespace DepthFirstSearch
{
    [TestClass]
    public class DepthFirstSearch_Test
    {
        [TestMethod]
        [DataRow("cat")]
        public void PermutationsTest(string letters)
        {
            List<string> res = DFSearch.Permutations(letters);
            res.Sort();
            foreach (string line in res)
            {
                Console.WriteLine(line);
            }
        }

        [TestMethod]
        [DataRow("5 4 3 x x 8 x x 6 x x", 2)]
        [DataRow("6 x 9 x 11 x 7 x x", 3)]
        [DataRow("1 x x", 0)]
        [DataRow("x", 0)]
        public void MaxDepthOfABinaryTree(string inputString, int expected)
        {
            var strs = TestHelper.SplitWords(inputString);
            int pos = 0;
            TreeNode<int> root = TestHelper.BuildTree(strs, ref pos, int.Parse);
            int res = BinarySearchTree.TreeMaxDepth(root);
            Assert.AreEqual(res, expected);
        }
    }
}
namespace CompanyOAs
{
    [TestClass]
    public class AmazonOA
    {
        #region Merge Sort
        [TestMethod]
        [DataRow("1 2 4", "1 3 4", "1 1 2 3 4 4")]
        [DataRow("4 2 4", "3 3 8", "3 3 4 2 4 8")]
        [DataRow("1 3 5 8 9", "4 7 9 12 15", "1 3 4 5 7 8 9 9 12 15")]
        public void MergeSortTest(string l1, string l2, string expected)
        {
            var arrA = l1.Split().ToList();
            var arrB = TestHelper.SplitWords(l2);

            ListNode listA = TestHelper.BuildList(arrA, int.Parse);
            ListNode listB = TestHelper.BuildList(arrB, int.Parse);

            ListNode res = MergeSort.Merge(listA, listB);

            List<string> resArr = TestHelper.FormatList<int>(res);

            Assert.AreEqual(String.Join(' ', resArr), expected);
        }
        #endregion
    }
}