namespace Stacking
{
    public static class EasyStack
    {
        /// <summary>
        /// Compares string characters to closing symbol, 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsValid(string s)
        {
            /*📦*/
            /*🗄️*/

            // 0. foreach char in string
            
            {
                //1. check if c is any kind of closing symbol
            
                {
                    // 1. for false condition, check if stack !empty AND if c is not the 
                    // closing symbol for what i sabout to get popped. otherwise it's out of order.
                    // and you can return false.
               
                    // OR the stack is not zero. for some reason?  (so far optional.)
                    {
               
                    }
                    // 2. pop the last value off the stack
               
                }
               
                {
                // 2.  else push c because it's an open parenthesis
               
                }
            }
            // at this point, the stack will have been completely popped because all open and closing symbols matched
            // or not in which case, it's not valid.
            return false;
        }
    }
}
