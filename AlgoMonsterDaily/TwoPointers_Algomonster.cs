using DataStructures;

namespace Algorithms.TwoPointers
{
    public class SameDirection
    {
        public static int MiddleOfLinkedList(Node<int> head)
        {
            int slowptr = 0;
            int fastptr = 0;
            while (head.next != null)
            {
                fastptr++;
            }
            if (fastptr % 2 == 0)
                slowptr = fastptr / 2;
            slowptr = fastptr / 2 + 1;
            return slowptr;
        }
    }

    public class Nervous
    {
        public int[] twosum(int[] nums, int target)
        {
            // 4 7 2 9 6 18   target 15

            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i=0; i<nums.Length; i++)
            {
                int cur = nums[i];
                int x = target - cur;
                if (map.ContainsKey(x))
                {
                    return new int[] { map[x], i };
                }
                map.Add(cur, i);
            }

            return null;                
        }
    }

    public class OppositeDirection
    {
        public static bool IsPalindrome(string s)
        {
            int left = 0;
            int right = s.Length;

            while (left < right)
            {
                while (left < right && !Char.IsLetterOrDigit(s[left]))
                {
                    left++;
                }
                while (left < right && !Char.IsLetterOrDigit(s[right]))
                {
                    right--;
                }
                // ignore case:
                if (Char.ToLower(s[left]) != Char.ToLower(s[right])) { return false; }

                left++;
                right--;
            }
            return true;
        }
    }

    public class SlidingWindow
    {
        public static int LongestSubstringWithoutRepeatingCharacters(string s)
        {
            // simplified inductive reasoning. 
            int n = s.Length;
            int longest = 0;
            int right = 0; // k       }   
            int left = 0;  // k`+1    }
            List<char> window = new List<char>();
            while (right < n)
            {
                if (!window.Contains(s[right]))
                {
                    window.Add(s[left]);
                    right++;
                }
                else
                {
                    window.Remove(s[left]);
                    left++;
                }
                longest = Math.Max(longest, right - left); //TODO: why right - left?
            }
            return longest;
        }

        public static List<int> FindAllAnagrams(string original, string check)
        {
            int oLength = original.Length;
            int cLength = check.Length;
            List<int> res = new List<int>();
            if (oLength < cLength) { return res; }
            // stores the frequency of each character in the check string
            int[] charCheck = new int[26];
            int[] window = new int[26];
            // first window
            for (int i=0; i<cLength; i++)
            {
                // converting the character to its number in an alphabet array.
                // that gives the index in an array of 26 
                charCheck[check.ElementAt(i) - 'a']++;
                window[original.ElementAt(i) -'a']++;
            }
            // compare the two sets. 
            if (Enumerable.SequenceEqual(window, charCheck)) // first instance of a match
                res.Add(0); 


            for(int i=cLength; i<oLength; i++)
            {   // moving the window. 
                window[original.ElementAt(i - cLength) - 'a']--;
                window[original.ElementAt(i) - 'a']++;
                // compare the alphas
                if (Enumerable.SequenceEqual(window, charCheck))
                    // i is clength. i - clength + 1 is the first letter of the anagram.
                    // add the index of that letter to the result. todo: confirm
                    res.Add(i - cLength + 1);
            }
            return res;
        }

        public static string GetMinimumWindow(string original, string check)
        {
            // char counter in t
            var charCheck = new Dictionary<char, int>();

            foreach (var c in check)
            {
                if (!charCheck.ContainsKey(c))
                {
                    charCheck[c] = 0;
                }
                charCheck[c]++;
            }

            var l = 0;
            var window = new Dictionary<char, int>();

            var coveredL = -1; // left index in s
            var coveredR = -1; // right index in s 
            var coveredLen = Int32.MaxValue;

            string result = "";
                
            for (var r = 0; r < original.Length; r++)
            {
                var c = original[r];
                if (!window.ContainsKey(c))
                {
                    window[c] = 0;
                }
                window[c]++;

                // covered, try minimizing result
                while (charCheck.All(kvp => window.ContainsKey(kvp.Key) && window[kvp.Key] >= kvp.Value))
                {
                    if ((r - l + 1) <= coveredLen)
                    {
                        result = string.Join("", original.Substring(l, r - l + 1));                            
                        coveredL = l;
                        coveredR = r;
                        coveredLen = r - l + 1;
                    }
                        
                    window[original[l]]-=1;
                    l++;
                }
            }

            return coveredL == -1 ? "" : result;
        }
    }
}
