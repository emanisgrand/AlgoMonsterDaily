namespace AlgoMonsterDaily
{
    public class TwoPointers
    {
        // global node
        public class Node<T>
        {
            public T val;
            public Node<T> next;

            public Node(T val)
            {
                this.val = val;
            }

            public Node(T val, Node<T> next)
            {
                this.val = val;
                this.next = next;
            }
        }

        public class SameDirection
        {
            // setting up a linked list
            public static Node<T> BuildList<T>(List<string> strs, Func<string, T> f)
            {
                Node<T> node = null;
                for (int i = strs.Count - 1; i >= 0; i--)
                {
                    node = new Node<T>(f(strs[i]), node);
                }
                return node;
            }

            public static int MiddleOfLinkedList(Node<int> head)
            {
                // WRITE YOUR BRILLIANT CODE HERE
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

            // Remove Duplicates

            // Move Zeros

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

            public static string MinWindowMS(string original, string check)
            {
                if (string.IsNullOrEmpty(original) || string.IsNullOrEmpty(check))
                {

                }
                return "";
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
}
