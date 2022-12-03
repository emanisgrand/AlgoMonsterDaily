﻿namespace Easy
{
    public static class Arrays
    {
        #region Two Sum
        /// <summary>
        /// Sum up all values in the array O(n²) time.
        /// </summary>
        /// <param name="nums">Array of integer values</param>
        /// <param name="target">Target value of the two int sum.</param>
        /// <returns>Integer array with the index of two summed values if found. Otherwise two zeros </returns>
        public static int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                        return new int[] { i, j };
                }
            }

            return new int[] { 0, 0 };
        }
        #endregion
        #region Contains Anagrams
        /// <summary>
        /// Store strings into sorted character arrays. Compare values of each index. O(N log N) time 
        /// </summary>
        /// <param name="s">A string of characters to compare</param>
        /// <param name="t">A string of characters to compare</param>
        /// <returns>True if character array contain the same values. False otherwise.</returns>
        public static bool ContainsAnagrams(string s, string t)
        {
            var S = s.ToCharArray();
            var T = t.ToCharArray();

            Array.Sort(S);
            Array.Sort(T);

            for (int i=0; i<S.Length; i++)
            {
                if (S[i] != T[i]) return false;
            }

            return true;
        }
        #endregion
        #region Contains Duplicates
        /// <summary>
        /// Checks for duplicates in O(n²) time
        /// </summary>
        /// <param name="arr">An unsorted array of values.</param>
        /// <returns>True if the array contains duplicates. False otherwise.</returns>
        public static bool ContainsDuplicates(int[] arr)
        {
            for (int i = 0; i < arr.Length-1; i++)
            {
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        return true;
                    }                    
                }
            }
            return false;
        }

        /// <summary>
        /// Sort an array then check for adjacent duplicates in O(nlogn) time
        /// </summary>
        /// <param name="arr">An unsorted array of values</param>
        /// <returns>True if the array contains duplicates. False otherwise.</returns>
        public static bool ContainsDuplicatesSorted(int[] arr)
        {
            Array.Sort(arr);
            int left = 0;
            for (int right=1; right<arr.Length; right++)
            {
                if (arr[left] == arr[right]) return true; 
                else
                    left++;
            }
            return false;
        }
        #endregion
    }

    public static class Hashing
    {
        /// <summary>
        /// Use hashmap to store value:index pairs then retrieve indices based on target:value operation in O(n) time.
        /// </summary>
        /// <param name="nums">Integer array</param>
        /// <param name="target">Target value</param>
        /// <returns>Int array with indices of summed values</returns>
        public static int[] TwoSum(int[] nums, int target)
        {
            // every previous element to the current element is stored in this map
            Dictionary<int, int> hashMap = new Dictionary<int, int>();

            for (int i=0; i<nums.Length; i++)
            {
                int diff = target - nums[i];
                // check if diff value is already in the hashmap
                // if so, return the index of diff and the current index.
                if (hashMap.ContainsKey(diff))
                    return new int[] {hashMap[diff], i};

                // the current key nums[i] should be set to the current value, index i;
                hashMap[nums[i]] = i;
            }

            return new int[] { 0, 0 };
        }
        #region Contains Anagrams
        /// <summary>
        /// Create hash sets for each input string. Compare character count for each in O(s+t) || O(n) time.
        /// </summary>
        /// <param name="s">A string of characters to compare</param>
        /// <param name="t">A string of characters to compare</param>
        /// <returns>True if sets contain all matching kvps. False otherwise.</returns>
        public static bool ContainsAnagrams(string s, string t)
        {
            if (s.Length != t.Length) return false;
            
            Dictionary<char, int> S = new Dictionary<char, int>(); // 📦
            Dictionary<char, int> T = new Dictionary<char, int>(); // 📦
            
            // use the length of the string to loop through the values. 
            for (int i=0; i<s.Length; i++)  // 👣
            {
                // if the key does not exist in the map, return 0.
                S[s[i]] = 1 + S.GetValueOrDefault(s[i], 0);
                T[t[i]] = 1 + T.GetValueOrDefault(t[i], 0);
            }
            // for each character in the string map . . .
            foreach(char c in S.Keys)
            {
                // check if the character (or some default) can be retrieved from the other string map. 
                if (S[c] != T.GetValueOrDefault(c, 0)) return false;
            }
            // retur true
            return true;
        }
        #endregion
        #region Contains Duplicates
        /// <summary>
        /// Create a set and check for duplicates in that set in O(n) time and space.
        /// </summary>
        /// <param name="arr">An unsorted array of values</param>
        /// <returns>True if the array value has been added to the set. False otherwise.</returns>
        public static bool ContainsDuplicates(int[] arr)
        {
            HashSet<int> set = new HashSet<int>();

            foreach (int n in arr)
            {
                if (set.Contains(n)) return true;
                else 
                    set.Add(n);
            }
            return false;
        }
        #endregion
    }
}

namespace Medium
{
    public static class Arrays
    {

    }

    public static class Hashing
    {

    }
}