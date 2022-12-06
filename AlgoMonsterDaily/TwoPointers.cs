namespace TwoPointers
{
    public static class EasyTwoPointers
    {
        #region Valid Palindrome
        public static bool IsPalindrome(string s)
        {
            string low = s.ToLower();
            List<char> sarahPalin = new List<char>();
            foreach (char c in low)
            {
                if (Char.IsLetterOrDigit(c))
                {
                    sarahPalin.Add(c);
                }
            }

            int left = 0;
            int right = sarahPalin.Count - 1;
            while (left < right)
            {
                if (sarahPalin[left] != sarahPalin[right]) return false;
                left++;
                right--;
            }

            return true;
        }

        public static bool IsPalindromOptimized(string s)
        {
            for (int i=0, j = s.Length -1; i < j; i++, j--)
            {
                while (i < j && !Char.IsLetterOrDigit(s[i]))
                {
                    i++;
                }
                while (i < j && !Char.IsLetterOrDigit(s[j]))
                {
                    j--;
                }

                if (Char.ToLower(s[i]) != Char.ToLower(s[j])) return false;
            }

            return true;
        }
        #endregion
    }
}