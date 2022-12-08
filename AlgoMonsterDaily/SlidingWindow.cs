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
            // left = buy, right = sell
            int left = 0, right = 1;
            /*🐕‍🦺*/       /*👣*/
            int maxProfit = 0;/*🌟*/

            // 0. while stepper is < the length of the array
            while (right < prices.Length)
            {
                // 1. check if the value at 🐕‍🦺 ptr < value at 👣 ptr
                if (prices[left] < prices[right])
                {
                    // 1. track profit = prices of value at 🐕‍🦺 - value at 👣
                    int profit = prices[right] - prices[left];
                    // 2. update maxProfit to be Max(maxProfit, and currentProfit)
                    maxProfit = Math.Max(maxProfit, profit);
                }
                // 2. else minimum sell day found. close the window
                else
                {
                    left = right;
                }
                // 3. increment 👣
                right++;
            }
            // maxProfit has been fully updated
            return maxProfit;
        }
        #endregion
        // TODO: Possible optimal solution exists.
    }
}