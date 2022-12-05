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
            // 📦
            Dictionary<int, int> hashMap = new Dictionary<int, int>();
            // 0. loop through the nums in the array
            for (int i=0; i<nums.Length; i++)
            {
                // 1. 👻
                int diff = target - nums[i]; 
                // 2. check if diff value is already in the hashmap, if so return int[] with diff index and current index
                if (hashMap.ContainsKey(diff))
                    return new int[] {hashMap[diff], i};

                // 3. Set the kvp of the current number in the array to its index.
                hashMap[nums[i]] = i;
            }

            return new int[] { hashMap[0], 0 };
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
            // 0. check lengths are equal
            if (s.Length != t.Length) return false;

            Dictionary<char, int> S = new Dictionary<char, int>(); // 📦 
            Dictionary<char, int> T = new Dictionary<char, int>(); // 📦
            // 1. use the length of the string to loop through the keys. 
            for (int i=0; i<s.Length; i++)// 👣
            {
                //1. Set the values of the keys = 1 + Get Value of key str[i] or Default to 0
                S[s[i]] = 1 + S.GetValueOrDefault(s[i], 0);
                T[t[i]] = 1 + T.GetValueOrDefault(t[i], 0);
            }
            // 2. for each character in either string map's Keys . . .
            foreach (char c in S.Keys)
            {
                // 1. check if Map[character] is not equal in OtherMap by Getting Value of c or Default to 0.
                // then return false
                if (S[c] != T.GetValueOrDefault(c, 0)) return false;
            }
            
            // otherwise return true.
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
}

namespace Medium
{
    public static class MediumArrays
    {
        
    }

    public static class MediumHashing
    {
        /// <summary>
        /// Sort a list of strings then groups them in O(N•K•logK) time where N is the number of strings in the array and K is the length of a string.
        /// </summary>
        /// <param name="strs">List of strings</param>
        /// <returns>List of grouped strings.</returns>
        public static List<List<string>> GroupAnagramsSorted(List<string> strs)
        {
            // 🗄️ key:string, value is list of strings
            Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();
            //0. foreach string in strs
            foreach (string s in strs)
            {
                //1. put s to chars array
                char[] chars = s.ToCharArray();
                // sort it 
                Array.Sort(chars);
                //2. generate the key (string) using the sorted array                 
                var key = new string(chars).ToString();
                //3. Try adding the key list pair if it doesn't already exist
                groups.TryAdd(key, new List<string>());
                //4. Add s to the groups[key].
                groups[key].Add(s);
            }

            // return the values of the group as a new List of strings list
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
                foreach (char c in s)
                {
                    //1. increment the count of that character (remember - 'a')
                    count[c - 'a']++;
                }
                //3. going to need a stringbuilder
                StringBuilder sb = new StringBuilder();
                //4. then loop through the alphabet 
                for (int i=0; i<26; i++)
                {
                    //1.append count at the index.
                    sb.Append(count[i]);
                    //2. append a delimiter '#' to ensure no overlapping keys in the event of 1 11 || 11 1 which are not anagrams
                    sb.Append('#');
                }
                //5. generate the key by sending the sb to string.
                var key = sb.ToString();
                //6. tryadd the key otherwise a new arraylist
                groups.TryAdd(key, new());
                //7. Add s to the groups[key].
                groups[key].Add(s);
            }

            // return the values of the group as a new List of strings list
            return new List<List<string>>(groups.Values);
        }
    }

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