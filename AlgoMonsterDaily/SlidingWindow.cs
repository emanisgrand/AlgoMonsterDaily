namespace SlidingWindow
{
    public static class EasySlidingWindow
    {   
        /// <summary>
        /// Track operations on input values and compare maximum.
        /// </summary>
        /// <param name="prices">array of integers</param>
        /// <returns>Integer: maximum profit possible</returns>
        #region Best Time To Buy & Sell Stock
        public static int MaxProfit(int[] prices)
        {
            int left = 0, right = 1; /*🐕‍🦺*/ /*👣*/
            int maxProfit = 0; /*🌟*/
            
            while (right < prices.Length)
            {
                if (prices[left] < prices[right])
                {
                    int profit = prices[right] - prices[left];
                    maxProfit = Math.Max(profit, maxProfit);
                }
                else
                {
                    left = right;
                }
                right++;
            }
            return maxProfit;
        }

        /// <summary>
        /// Compare and track result of each price + highest negative price 
        /// </summary>
        /// <param name="prices">input values</param>
        /// <returns>int: highest price tracked </returns>
        public static int OptimalMaxProfit(int[] prices)
        { // 7, 1, 5, 3, 6, 4 
            // 0. check if input is null or length of array is 0
            // if so return 0
            if (prices == null || prices.Length == 0) return 0; /*✅*/

            // 1. contain result in new int, same length of prices array 
            // increased space complexity solution inbound
            int[] res = new int[prices.Length]; /*📦 ✅*/  //[0 1 2 3 4 5 ]
            // 2. hold the most recent value in the array, but negative tho./*👻*/
            int diff = -prices[0]; /*✅*/  // -7
            // 3. loop starting from first buy day, to end of input 
            for (int i=1; i<prices.Length; i++) /*✅*/  
            {
                // 1. Set the value from the container where the ptr is 
                // = the Max(value from container at the ptr - 1,
                // AND the value from input at the ptr + the 👻) (the negative value)
                //                                                     i-1  i                 i-1 i
                res[i] = Math.Max(res[i - 1], prices[i] + diff);  // res[0 -6 3 3 5 5 ], prices[7 1 4 3 6 4]
                // 2. Update the 👻 with the Max(👻, and the negative value of the prices where the ptr is)
                diff = Math.Max(diff, -prices[i]);  // -1, -1, -1, -1, -1
            }
            // return the value of 📦 at the length of price list - 1.
            // this will be the highest value stored in the array which reflects the max profit.
            return res[prices.Length - 1];
        }
        #endregion
    }
}