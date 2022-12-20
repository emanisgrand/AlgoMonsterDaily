using TestHelpers;
using ArraysAndHashing;
using TwoPointers;
using SlidingWindow;
using Stack;
using Graphs;
using DataStructures;
using LinkedLists;
using BinarySearching;

namespace EasyTests
{
    [TestClass]
    public class LinkedLists
    {
        #region MergeLinkedList
        [TestMethod]
        [DataRow(new int[] {1,2,4}, new int[] {1,3,4})]
        public void MergeTwoSortedLinkedLists(int[] l1Data, int[] l2Data)
        {
            ListNode list1 = new ListNode();
            ListNode list2 = new ListNode();
            foreach (int i in l1Data)
            {
                list1.val = i;
                list1.next = new ListNode();
            }
            foreach (int i in l2Data)
            {
                list2.val = i;
                list2.next = new ListNode();
            }

            EasyLinkedList.MergeSortedLists(list1, list2);
        }
        #endregion
        #region Reverse Linked List
        [TestMethod]
        [DataRow(new int[] {1,2,3,4,5})]
        public void ReverseLinkedList(int[] data)
        {
            ListNode head = new ListNode();
            foreach (int i in data)
            {
                head.val = i;
                head.next = new ListNode();
            }

            EasyLinkedList.ReverseListRecursive(head);
        }
        #endregion
    }

    [TestClass]
    public class StackTest
    {
        #region Parenthesis
        [TestMethod]
        [DataRow("()", true)]
        [DataRow("(]", false)]
        [DataRow("()[]{}", true)]
        [DataRow("]", false)]
        public void DetermineValidityOfInputStringParenthesis(string s, bool expected)
        {
            Assert.AreEqual(expected, EasyStack.IsValid(s));
        }
        #endregion
    }
    [TestClass]
    public class SlidingWindow
    {
        #region Max Profit
        [TestMethod]
        [DataRow(new int[] { 7, 1, 5, 3, 6, 4 }, 5)]
        public void FindTheMaximumProfitToBuyAndSellStock(int[] prices, int expected)
        {
            Assert.AreEqual(expected, EasySlidingWindow.MaxProfit(prices));
            Assert.AreEqual(expected, EasySlidingWindow.AltMaxProfit(prices));
        }
        #endregion
    }

    [TestClass]
    public class ArraysAndHashing
    {
        #region Contains Anagrams
        [TestMethod]
        [DataRow("anagram", "nagaram", true)]
        [DataRow("car", "rat", false)]
        [DataRow("farting", "fingart", true)]
        [DataRow("doppleganger", "peeplanggord", true)]
        [DataRow("aacc", "ccac", false)]
        public void ReturnTrueIfStringsAreAnagramsOfEachOther(string s, string t, bool expected)
        {
            Assert.AreEqual(expected, EasyArrays.ContainsAnagrams(s, t));
            Assert.AreEqual(expected, EasyHashing.ContainsAnagrams(s, t));
        }
        #endregion
        #region Contains Duplicates
        [TestMethod]
        [DataRow("1 2 3 1", true)]
        [DataRow("1 2 3 4", false)]
        [DataRow("1 2 3 4 3 6", true)]
        [DataRow("1 2 3 4 5 6", false)]
        [DataRow("1 1", true)]
        [DataRow("1", false)]
        [DataRow("12 1 2 5 61 15 8 5", true)]
        public void UseHasingToReturnTrueIfAnyValueAppearsAtLeastTwice(string data, bool expected)
        {
            var nums = TestHelper.SplitWords(data).Select(int.Parse).ToArray();
            Assert.AreEqual(expected, EasyHashing.ContainsDuplicates(nums));
        }

        [TestMethod]
        [DataRow("1 2 3 1", true)]
        [DataRow("1 2 3 4", false)]
        public void ReturnTrueIfAnyValueAppearsAtLeastTwiceInAnUnsortedArray(string data, bool expected)
        {
            var nums = TestHelper.SplitWords(data).Select(int.Parse).ToArray();
            Assert.AreEqual(expected, EasyArrays.ContainsDuplicates(nums));
        }

        [TestMethod]
        [DataRow("1 2 3 4 3 6", true)]
        [DataRow("1 2 3 4 5 6", false)]
        [DataRow("1 1", true)]
        [DataRow("1", false)]
        [DataRow("12 1 2 5 61 15 8 5", true)]
        public void SortAnArrayAndReturnTrueIfAnyValueAppearsAtLeastTwice(string data, bool expected)
        {
            var nums = TestHelper.SplitWords(data).Select(int.Parse).ToArray();
            Assert.AreEqual(expected, EasyArrays.ContainsDuplicatesSorted(nums));
        }
        #endregion
        #region TwoSum
        [TestMethod]
        [DataRow("2 7 11 15", 9, "0 1")]
        [DataRow("2 1 5 3", 6, "1 2")]
        [DataRow("2 1 5 3", 12, "0 0")]
        [DataRow("2 1 5 3", 8, "2 3")]
        public void ReturnIndicesOfTwoNumbersInAnArrayThatAddUpToTargetValue(string data, int target, string output)
        {
            var nums = TestHelper.SplitWords(data).Select(int.Parse).ToArray();
            var expected = TestHelper.SplitWords(output).Select(int.Parse).ToArray();

            int[] arr = EasyArrays.TwoSum(nums, target);
            int[] ans = EasyHashing.TwoSum(nums, target);

            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(expected[i], ans[i]);
                Assert.AreEqual(expected[i], arr[i]);
            }
        }
        #endregion
    }

    [TestClass]
    public class TwoPointers
    {
        #region Valid Palindrome
        [TestMethod]
        [DataRow("A man, a plan, a canal: Panama", true)]
        [DataRow("race a car", false)]
        public void DetermineIfIsAValidPalindromOrNot(string s, bool expected)
        {
            Assert.AreEqual(expected, EasyTwoPointers.IsPalindrome(s));
            Assert.AreEqual(expected, EasyTwoPointers.IsPalindromOptimized(s));
        }
        #endregion
    }
}
namespace MediumTests
{

    [TestClass]
    public class BinarySearchTests
    {
        [TestMethod]
        [DataRow(new int[] {1,2,3,5,6}, 0, 4)]
        public void SearchInRotateSortedArray(int[] nums, int target, int expected)
        {
            Assert.AreEqual(expected, BinarySearch.Rotated(nums, target));
        }
    }
    [TestClass]
    public class GraphTests
    {
        #region Dynamic Grid Data Initialization & Validation
        static IEnumerable<char[][][]> GetGridA
        {
            get
            {
                return new List<char[][][]>
                {
                    new char [][][]
                    {
                        new char[][]
                        {
                            new char[]{'1', '1', '1', '1', '0'},
                            new char[]{'1', '1', '0', '1', '0'},
                            new char[]{'1', '1', '0', '0', '0'},
                            new char[]{'0', '0', '0', '0', '0'}
                        }
                    }
                };
            }
        }
        [TestMethod]
        [DynamicData(nameof(GetGridA))]
        public void Grid_A_ValidationCheck(char[][] input)
        {
            Assert.AreEqual('1', input[0][0]);
            Assert.AreEqual('1', input[0][1]);
            Assert.AreEqual('1', input[0][2]);
            Assert.AreEqual('1', input[0][3]);
            Assert.AreEqual('0', input[0][4]);

            Assert.AreEqual('1', input[1][0]);
            Assert.AreEqual('1', input[1][1]);
            Assert.AreEqual('0', input[1][2]);
            Assert.AreEqual('1', input[1][3]);
            Assert.AreEqual('0', input[1][4]);

            Assert.AreEqual('1', input[2][0]);
            Assert.AreEqual('1', input[2][1]);
            Assert.AreEqual('0', input[2][2]);
            Assert.AreEqual('0', input[2][3]);
            Assert.AreEqual('0', input[2][4]);

            Assert.AreEqual('0', input[3][0]);
            Assert.AreEqual('0', input[3][1]);
            Assert.AreEqual('0', input[3][2]);
            Assert.AreEqual('0', input[3][3]);
            Assert.AreEqual('0', input[3][4]);
        }
        static IEnumerable<char[][][]> GetGridB
        {
            get
            {
                return new List<char[][][]>
                {
                    new char [][][]
                    {
                        new char[][]
                        {
                            new char[]{'1', '1', '0', '0', '0'},
                            new char[]{'1', '1', '0', '0', '0'},
                            new char[]{'0', '0', '1', '0', '0'},
                            new char[]{'0', '0', '0', '1', '1'}
                        }
                    }
                };
            }
        }
        [TestMethod]
        [DynamicData(nameof(GetGridB))]
        public void Grid_B_ValidationCheck(char[][] input)
        {
            Assert.AreEqual('1', input[0][0]);
            Assert.AreEqual('1', input[0][1]);
            Assert.AreEqual('0', input[0][2]);
            Assert.AreEqual('0', input[0][3]);
            Assert.AreEqual('0', input[0][4]);

            Assert.AreEqual('1', input[1][0]);
            Assert.AreEqual('1', input[1][1]);
            Assert.AreEqual('0', input[1][2]);
            Assert.AreEqual('0', input[1][3]);
            Assert.AreEqual('0', input[1][4]);

            Assert.AreEqual('0', input[2][0]);
            Assert.AreEqual('0', input[2][1]);
            Assert.AreEqual('1', input[2][2]);
            Assert.AreEqual('0', input[2][3]);
            Assert.AreEqual('0', input[2][4]);

            Assert.AreEqual('0', input[3][0]);
            Assert.AreEqual('0', input[3][1]);
            Assert.AreEqual('0', input[3][2]);
            Assert.AreEqual('1', input[3][3]);
            Assert.AreEqual('1', input[3][4]);
        }
        #endregion

        [TestMethod]
        [DynamicData(nameof(GetGridA))]
        public void Grid_A_NumberOfIslands(char[][] grid)
        {
            Grid_A_ValidationCheck(grid);
            Assert.AreEqual(1, NumberOfIslands.BFS(grid));
        }
        [TestMethod]
        [DynamicData(nameof(GetGridB))]
        public void Grid_B_NumberOfIslands(char[][] grid)
        {
            Grid_B_ValidationCheck(grid);
            Assert.AreEqual(3, NumberOfIslands.BFS(grid));
        }
      

        [TestMethod]
        public void DFSNodeToReturnDeepCopyOfConnectedUndirectedGraph()
        {
            GraphNode input = BuildGraph();
            DFSClone.DeepCopy(input);
        }
        [TestMethod]
        public void BFSNodeToReturnDeepCopyOfConnectedUndirectedGraph()
        {
            GraphNode input = BuildGraph();
            BFSClone.DeepCopy(input);
        }
        private GraphNode BuildGraph()
        {
            /* Algorithm:
            GraphNode node1 = new GraphNode(1); 
            List<GraphNode> list = new List<GraphNode>();
            list.Add(node2);
            list.Add(node4);
            node1.neighbors = list;
             */
            GraphNode node1 = new GraphNode(1);
            GraphNode node2 = new GraphNode(2);
            GraphNode node3 = new GraphNode(3);
            GraphNode node4 = new GraphNode(4);
            List<GraphNode> list = new List<GraphNode>();
            list.Add(node2);
            list.Add(node4);
            node1.neighbors = list;
            list = new List<GraphNode>();
            list.Add(node1);
            list.Add(node3);
            node2.neighbors = list;
            list = new List<GraphNode>();
            list.Add(node2);
            list.Add(node4);
            node3.neighbors = list;
            list = new List<GraphNode>();
            list.Add(node3);
            list.Add(node1);
            node4.neighbors = list;
            return node1;
        }
    }
}