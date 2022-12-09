namespace SlidingWindow
{
    public static class EasySlidingWindow
    {
        #region Best Time To Buy & Sell Stock
        /// <summary>
        /// Track operations on input values and compare maximum.
        /// </summary>
        /// <param name="prices">array of integers</param>
        /// <returns>Integer: maximum profit possible</returns>
        public static int MaxProfit(int[] prices)
        {
            int left = 0, right = 1; /*🐕‍🦺*/ /*👣*/
            int maxProfit = 0; /*🌟*/
            
            while (right < prices.Length)
            {
                if (prices[right] < prices[left])
                {
                    left = right;
                }
                else
                {
                    int profit = prices[right] - prices[left];
                    maxProfit = Math.Max(profit, maxProfit);
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
        public static int AltMaxProfit(int[] prices)
        {
            if (prices.Length == 0 || prices == null) ;
            
            int[] intarr = new int[prices.Length];
            
            int diff = -prices[0];
            
            for (int i=1; i<prices.Length; i++)
            {
                intarr[i] = Math.Max(prices[i] + diff, intarr[i - 1]);
                diff = Math.Max(-prices[i], diff);
            }
            return intarr[prices.Length - 1];
        }
        #endregion
    }
}