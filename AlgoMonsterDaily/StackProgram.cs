namespace Stack
{
    public static class EasyStack
    {
        /// <summary>
        /// Compares string characters to closing symbol
        /// </summary>
        /// <param name="s">parenthetical input</param>
        /// <returns>bool: T if all parenthesis match. F otherwise.</returns>
        public static bool IsValid(string s)
        {
            Dictionary<char, char> symbols = new Dictionary<char, char>(); /*📦*/
            symbols.Add('{', '}');
            symbols.Add('[', ']');
            symbols.Add('(', ')');

            Stack<char> stack = new Stack<char>();/*🗄️*/

            // 0. foreach char in string
            foreach (char c in s)
            {
                //1. check if c is any kind of closing symbol
                if (c == ']' || c == ')' || c == '}')
                {
                    // 1. for false condition, check if stack !empty AND if c is not the 
                    // closing symbol for what is about to get popped. 
                    if (stack.Count > 0 && symbols[stack.Peek()] != c || stack.Count == 0)
                    {
                        return false;
                    }
                    // 2. pop the last value off the stack
                    stack.Pop();
                }
                else
                {
                    // 2.  else push c because it's an open parenthesis
                    stack.Push(c);
                }
            }
            // at this point, the stack will either have been completely
            // popped because all open and closing symbols matched
            // or not in which case, it's not valid.
            return stack.Count == 0;
        }
        // possible optimized solution exists.
    }
}
