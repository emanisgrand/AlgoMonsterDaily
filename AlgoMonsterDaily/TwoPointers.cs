namespace TwoPointers
{
    public static class EasyTwoPointers
    {
        #region Valid Palindrome
        /// <summary>
        /// Brute Force: Iteratively compare elements at either side of input
        /// </summary>
        /// <param name="s">String</param>
        /// <returns>bool: F if elements don't match. T otherwise.</returns>
        public static bool IsPalindrome(string s)
        {
            string low = s.ToLower(); /*📦*/
            List<char> sarahPalin = new List<char>(); /*🍒*/
            // 1. foreach character in the char array (from input)
            foreach (char c in low)
            {
                // 1. Gather only all alphanumerics 
                if (Char.IsLetterOrDigit(c))
                {
                    sarahPalin.Add(c);
                }
            }
            int left = 0; /*🧟*/
            int right = sarahPalin.Count - 1; /*🧟*/
            // 2. while left < right 
            while (left < right)
            {
                // 1. If gathered element at left ptr != element at right ptr, return false.
                if (sarahPalin[left] != sarahPalin[right]) return false;
                // 2. increment left
                left++;
                // 3. decrement right
                right--; 
            }
            // Elements at both sides of the input match
            return true;
        }
        /// <summary>
        /// In place: Iteratively compare elements at either side of the input
        /// </summary>
        /// <param name="s">String</param>
        /// <returns></returns>
        public static bool IsPalindromOptimized(string s)
        {
            // 0. initialize 👣s to loop through length of input; increment / decrement 
            for (int i=0, j = s.Length -1; i < j; i++, j--)
            {
                // 1. while left is less than right ∧ value at left is not alphanumeric (skip symbols)
                while (i < j && !Char.IsLetterOrDigit(s[i]))
                {
                    // 1. increment left.
                    i++;
                }

                // 2. while left is less than right ∧ value at right is not alphanumeric (skip symbols)
                while (i < j && !Char.IsLetterOrDigit(s[j]))
                {
                    // 1. decrement right
                    j--;
                }

                // 3. if value at left ptr != value at right ptr, return false.
                if (Char.ToLower(s[i]) != Char.ToLower(s[j])) return false;
            }
            // All elements at both sides of the input have matched.
            return true;
        }
        #endregion
    }
}