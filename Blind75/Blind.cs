using TestHelpers;
using Easy;
using Medium;

namespace EasyTests
{
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

            for (int i = 0; i < ans.Length; i++)
            {
                Assert.AreEqual(expected[i], ans[i]);
                Assert.AreEqual(expected[i], arr[i]);
            }
        }
        #endregion
    }
}
namespace MediumTests
{
    [TestClass]
    public class ArraysAndHashing
    {
        [TestMethod]
        [DataRow("eat tea tan ate nat bat")]
        public void GroupAnagramsTogether(string data)
        {
            var strs = Helpers.SplitWords(data).ToList();
            MediumHashing.GroupAnagramsSorted(strs);
            var res = MediumHashing.GroupAnagramsCounter(strs);

           // Assert.AreEqual(res.Count, 3);
        }

    }
}