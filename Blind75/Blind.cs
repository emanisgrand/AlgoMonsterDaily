using TestHelpers;
using ArraysAndHashing;
using TwoPointers;
using PrampPracetice;
using SlidingWindow;
using Graphs;
using Stacking;

namespace EasyTests
{
    [TestClass]
    public class StackTest
    {
        [TestMethod]
        [DataRow("()", true)]
        [DataRow("(]", false)]
        public void DetermineValidityOfInputStringParenthesis(string s, bool expected)
        {
            Assert.AreEqual(expected, EasyStack.IsValid(s));
        }
    }
    [TestClass]
    public class SlidingWindow
    {
        [TestMethod]
        [DataRow(new int[] { 7, 1, 5, 3, 6, 4 }, 5)]
        public void FindTheMaximumProfitToBuyAndSellStock(int[] prices, int expected)
        {
            Assert.AreEqual(expected, EasySlidingWindow.MaxProfit(prices));
        }
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
            var nums = Helpers.SplitWords(data).Select(int.Parse).ToArray();
            Assert.AreEqual(expected, EasyHashing.ContainsDuplicates(nums));
        }

        [TestMethod]
        [DataRow("1 2 3 1", true)]
        [DataRow("1 2 3 4", false)]
        public void ReturnTrueIfAnyValueAppearsAtLeastTwiceInAnUnsortedArray(string data, bool expected)
        {
            var nums = Helpers.SplitWords(data).Select(int.Parse).ToArray();
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
            var nums = Helpers.SplitWords(data).Select(int.Parse).ToArray();
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
            var nums = Helpers.SplitWords(data).Select(int.Parse).ToArray();
            var expected = Helpers.SplitWords(output).Select(int.Parse).ToArray();

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
    public class Graphs
    {
        #region Get Grid
        static IEnumerable<char[][][]> Grid_A
        {
            get
            {
                return new List<char[][][]>
                {
                    new char[][][]
                    {
                         new char[][]
                         {
                         new char[] {'1', '1', '1','1', '0'},
                         new char[] {'1', '1', '0','0', '0'},
                         new char[] {'1', '1', '0','0', '0'},
                         new char[] {'0', '0', '0','0', '0'},
                         } 
                    }
                };
            }
        }

        static IEnumerable<char[][][]> Grid_B
        {
            get
            {
                return new List<char[][][]>
                {
                    new char[][][]
                    {
                         new char[][]
                         {
                         new char[] {'1', '1', '0','0', '0'},
                         new char[] {'1', '1', '0','0', '0'},
                         new char[] {'0', '0', '1','0', '0'},
                         new char[] {'0', '0', '0','1', '1'},
                         }
                    }
                };
            }
        }
        [TestMethod]
        [DynamicData(nameof(Grid_A))]
        public void EnsureGrid_A_IsInitializedCorrectly(char[][] grid)
        {
            Assert.AreEqual('1', grid[0][0]);
            Assert.AreEqual('1', grid[0][1]);
            Assert.AreEqual('1', grid[0][2]);
            Assert.AreEqual('1', grid[0][3]);
            Assert.AreEqual('1', grid[1][1]);
            Assert.AreEqual('1', grid[1][0]);
            Assert.AreEqual('1', grid[2][0]);
            Assert.AreEqual('1', grid[2][1]);

            Assert.AreEqual('0', grid[0][4]);
            Assert.AreEqual('0', grid[1][4]);
            Assert.AreEqual('0', grid[2][4]);
            Assert.AreEqual('0', grid[3][4]);
            Assert.AreEqual('0', grid[3][1]);
            Assert.AreEqual('0', grid[3][2]);
            Assert.AreEqual('0', grid[3][3]);
            Assert.AreEqual('0', grid[1][2]);
            Assert.AreEqual('0', grid[2][2]);
            Assert.AreEqual('0', grid[2][3]);
            Assert.AreEqual('0', grid[1][3]);
            Assert.AreEqual('0', grid[3][0]);
        }
        [TestMethod]
        [DynamicData(nameof(Grid_B))]
        public void EnsureGrid_B_IsInitializedCorrectly(char[][] grid)
        {
            Assert.AreEqual('1', grid[0][0]);
            Assert.AreEqual('1', grid[0][1]);
            Assert.AreEqual('0', grid[0][2]);
            Assert.AreEqual('0', grid[0][3]);
            Assert.AreEqual('1', grid[1][1]);
            Assert.AreEqual('1', grid[1][0]);
            Assert.AreEqual('0', grid[2][0]);
            Assert.AreEqual('0', grid[2][1]);

            Assert.AreEqual('0', grid[0][4]);
            Assert.AreEqual('0', grid[1][4]);
            Assert.AreEqual('0', grid[2][4]);
            Assert.AreEqual('1', grid[3][4]);
            Assert.AreEqual('0', grid[3][1]);
            Assert.AreEqual('0', grid[3][2]);
            Assert.AreEqual('1', grid[3][3]);
            Assert.AreEqual('0', grid[1][2]);
            Assert.AreEqual('1', grid[2][2]);
            Assert.AreEqual('0', grid[2][3]);
            Assert.AreEqual('0', grid[1][3]);
            Assert.AreEqual('0', grid[3][0]);
        }
        #endregion
        [TestMethod]
        [DynamicData(nameof(Grid_B))]
        public void ReturnTheNumberOfIslandsInGrid_B(char[][] grid)
        {
            EnsureGrid_B_IsInitializedCorrectly(grid);
            Assert.AreEqual(3, MediumGraphs.NumberOfIslandsBFS(grid));
        }

        [TestMethod]
        [DynamicData(nameof(Grid_A))]
        public void ReturnTheNumberOfIslandsInGrid_A(char[][] grid)
        {
            EnsureGrid_A_IsInitializedCorrectly(grid);
            Assert.AreEqual(1, MediumGraphs.NumberOfIslandsBFS(grid));
        }
    }

    [TestClass]
    public class ArraysAndHashing
    {
        [TestMethod]
        [DataRow(new int[] {1,1,1,2,2,3}, 2)]
        public void ReturnThe_K_MostFrequentElements(int[] nums, int k)
        {

            // return
            int[] ans = new int[k];
        }
        #region Anagrams
        [TestMethod]
        [DataRow("eat tea tan ate nat bat")]
        public void GroupAnagramsTogether(string data)
        {
            var strs = Helpers.SplitWords(data).ToList();
            MediumHashing.GroupAnagramsSorted(strs);
            var res = MediumHashing.GroupAnagramsCounter(strs);
        }

        [TestMethod]
        [DataRow(new string[] { "eat", "tea", "tan ", "ate", "nat", "bat" })]
        public void GroupAnagramsTestSimulatingLeetcodeEnvironment(string[] data)
        {

            LeetCodeSim leetCodeSim = new LeetCodeSim();
            leetCodeSim.GroupAnagrams(data);
        }
        #endregion
        #region Simple OrderBy Example
        [TestMethod]
        [DataRow(new string[] { "coupon", "sincompoop", "ads", "yada" ,"reddick" })]
        public void SimpleOrderByExample(string[] data)
        {
            var ordered = data.OrderBy(n => n);
            foreach (string s in ordered)
            {
                Console.WriteLine(s);
            }
        }
        #endregion
    }
}

/*
namespace PrampTests
{
    [TestClass]
    public class PrampTesting
    {
        [TestMethod]
        [DataRow(new char[] { 'p', 'e', 'r', 'f', 'e', 'c', 't', ' ', 'm', 'a', 'k', 'e', 's', ' ', 'p', 'r', 'a', 'c', 't', 'i', 'c', 'e', ' ' })]
        public void SentenceReverse(char[] arr)
        {
            Pramp.ReverseWords(arr);
            Console.WriteLine(arr);
        }
    }
}
*/