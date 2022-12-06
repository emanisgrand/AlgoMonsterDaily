using System.ComponentModel;
using System.Text;

namespace Easy
{
    public static class EasyArrays
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
        /// Store strings into sorted character arrays. Compare values of each index. ~O(N log N) time 
        /// </summary>
        /// <param name="s">A string of characters to compare</param>
        /// <param name="t">A string of characters to compare</param>
        /// <returns>True if character array contain the same values. False otherwise.</returns>
        public static bool ContainsAnagrams(string s, string t)
        {
            if (s.Length != t.Length) return false;
            char[] S = s.ToCharArray();// 🗄️
            char[] T = t.ToCharArray();// 🗄️

            Array.Sort(S);
            Array.Sort(T);
            
            for (int i=0; i<s.Length; i++)
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
    public static class EasyHashing
    {
        #region Two Sum
        /// <summary>
        /// Use hashmap to store value:index pairs then retrieve indices based on target:value operation in O(n) time.
        /// </summary>
        /// <param name="nums">Integer array</param>
        /// <param name="target">Target value</param>
        /// <returns>Int array with indices of summed values</returns>
        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();  /*📦*/
            // 0. loop through the nums in the array
            for (int i=0; i<nums.Length; i++)
            {
            int diff = target - nums[i]; /*👻*/
                // 2. check if this key is already in the hashmap, if so return int[] with diff index and current index
                if (map.ContainsKey(diff))
                    return new int[] { map[diff], i };

                // 3. Set the kvp of the current number in the array to its index.
                map[nums[i]] = i;  // ❌
            }

            return new int[] { 0,0 };
        }
        #endregion
        #region Contains Anagrams
        /// <summary>
        /// Create hash maps for each input string. Compare character count for each in O(s+t) || O(n) time.
        /// </summary>
        /// <param name="s">A string of characters to compare</param>
        /// <param name="t">A string of characters to compare</param>
        /// <returns>True if sets contain all matching kvps. False otherwise.</returns>
        public static bool ContainsAnagrams(string s, string t)
        {
            if (s.Length != t.Length) return false;

            Dictionary<char, int> S = new Dictionary<char, int>(); // 📦 
            Dictionary<char, int> T = new Dictionary<char, int>(); // 📦
         
            for (int i=0; i<s.Length; i++)// 👣
            {
                S[s[i]] = 1 + S.GetValueOrDefault(s[i], 0);
                T[t[i]] = 1 + T.GetValueOrDefault(t[i], 0);
            }

            foreach (char c in S.Keys)
            {
                if (S[c] != T.GetValueOrDefault(c, 0)) return false;
            }
            
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

        /// <summary>
        /// Uses inline operation to add the array value to the hash set.
        /// </summary>
        /// <param name="nums">array</param>
        /// <returns>True if set contains value. False otherwise.</returns>
        public static bool ContainsDuplicatesInline(int[] nums)
        {
            HashSet<int> s = new();

            foreach (int i in nums)
            {
                bool added = s.Add(i); // inline operation

                if (!added) return true;
            }
            return false;
        }
        #endregion
    }

/*
using System;

class Solution
{
    public static int IndexEqualsValueSearch(int[] arr)
    {
      int left = 0;
      int right = arr.Length;
      
      while (left <= right)
      {
        int mid = left + (right - left) / 2;
        
        if (arr[mid] == mid)
        {
          return mid;
        }
        if (arr[mid] < mid)
        {
          left = mid+1;
        }else
        {
          right = mid -1;
        }
        
      }
      return -1;
    }

    static void Main(string[] args)
    {
      int[] arr = {-8, 0, 2, 5};
      
      Console.WriteLine(IndexEqualsValueSearch(arr));
      
    }
}     
*/
}

namespace Medium
{
    public static class MediumHashing
    {
        #region Top K Frequent
        /// <summary>
        /// O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k">Amount of values to return.</param>
        public static int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, List<int>> bucket = new Dictionary<int, List<int>>();
            int[] freq = new int[k];
            //or
            int[] freqs = new int[nums.Length + 1];

            foreach (int n in nums)
            {
                bucket[n] = bucket.GetValueOrDefault(n, new List<int>(0));
            }
            
            return freq;
        }
        #endregion
        #region Anagrams
        /// <summary>
        /// Sort a list of strings then groups them in O(N•K•logK) time where N is the number of strings in the array and K is the length of a string.
        /// </summary>
        /// <param name="strs">List of strings</param>
        /// <returns>List of grouped strings.</returns>
        public static List<List<string>> GroupAnagramsSorted(List<string> strs)
        {
            /*📦*/ 
            Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();
            foreach (string s in strs)
            {
                /*char[] chars = s.ToCharArray();
                Array.Sort(chars);*/                
                /*string key = new string(chars);*/
                string key = new string(s.OrderBy(x => x).ToArray());
                groups.TryAdd(key, new List<string>());
                groups[key].Add(s);
            }
            return new List<List<string>>(groups.Values);
        }

        /// <summary>
        /// Create KVP groupings based on string chars in O(N•K + N•A) time complexity where N is size of the string array, K length of a string, A is counter array
        /// </summary>
        /// <param name="strs"></param>
        /// <returns>Grouped string list.</returns>
        public static List<List<string>> GroupAnagramsCounter(List<string> strs)
        {
            Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();
            //0. foreach string in strs:   
            foreach (string s in strs)
            {
                //1. declare a count array of size 26
                char[] count = new char[26];
                //2. foreach character in string
                foreach(char c in s)
                {
                    //1. increment the count of that character (remember - 'a')
                    count[c - 'a']++;
                }
                //3. going to need a stringbuilder
                StringBuilder sb = new StringBuilder();
                //4. Generate a key by making one out of the char array using StringBuilder
                for(int i=0; i<26; i++)
                {
                    //1.append count at the index.
                    sb.Append(count[i]);
                    //2. append a delimiter '#' to ensure no overlapping keys in the event of 1 11 || 11 1 which are not anagrams
                    sb.Append('#');
                }
                //5. generate the key by sending the sb to string.
                var key = sb.ToString();
                //6. tryadd the key otherwise a new arraylist
                groups.TryAdd(key, new List<string>());
                //7. Add s to the groups[key].
                groups[key].Add(s);
            }

            // return the values of the group as a new List of strings list
            return new List<List<string>>(groups.Values);
        }
    }
    #endregion
    public class LeetCodeSim
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();

            foreach (string s in strs)
            {
                string key = new string(s.OrderBy(x => x).ToArray());

                groups.TryAdd(key, new List<string>());

                groups[key].Add(s);
            }

            return new List<IList<string>>(groups.Values);
        }
    }
}

namespace PrampPracetice
{ 
    public static class Pramp
    {
        #region Cheapest Cost (N-Ary Tree)
        public class Node
        {
            public int cost;
            public Node[] children;
            public Node parent;
        }

        public static int getCheapestCost(Node rootNode)
        {
            // RECURSE

            // 1. check if the current node has any children.
            int n = rootNode.children.Length; // 👻
            // 2. if not, you are at a leaf node, return the node's cost.
            if (n == 0) return rootNode.cost;
            else
            {
                // 1. otherwise start looking for the minCost by looping through the children
                int minCost = Int32.MaxValue;  // 🌟
                for (int i = 0; i < n; i++)
                {
                    // 2. find cheapest cost from among the little children recursively
                    int tempCost = getCheapestCost(rootNode.children[i]);
                    // 3. if the cost returned is less than the current minimum cost, update mincost
                    if (tempCost < minCost)
                        minCost = tempCost;
                }
                // 3. return the minCost plus the cost of the node to the stack.
                return minCost + rootNode.cost;
            }
        }
        #endregion
        public static char[] ReverseWords(char[] arr)
        {
            // 1. reverse all the characters in arr 
            int start = 0;
            for (int end=0; end<arr.Length; end++)
            {
                // if we've encountered a space
                // reverse the previous word (between the indices start and end -1)
                if (arr[end] == ' ')
                {
                    mirrorReverse(arr, start, end);
                    start = end + 1;
                }
            }

            // Reverse the last word
            mirrorReverse(arr, start, arr.Length - 1);


            // Reverse the entire string
            mirrorReverse(arr, 0, arr.Length - 1);
            
            return arr;
        }

        public static void mirrorReverse(char[] arr, int start, int end)
        {
            /*🌡️*/ // store character
            char tmp; 
            while (start < end)
            {
                // swap the first and last characters
                tmp = arr[start];
                arr[start] = arr[end];
                arr[end] = tmp;
                start++;
                end--;
            }
        }
    }
}
