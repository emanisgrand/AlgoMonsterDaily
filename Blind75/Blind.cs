using TestHelpers;
using ArraysAndHashing;
using TwoPointers;
using SlidingWindow;
using Stack;
using DataStructures;
using LinkedLists;

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