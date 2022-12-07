namespace SlidingWindow
{
    public static class EasySlidingWindow
    {
        #region Best Time To Buy & Sell Stock
        public static int MaxProfit(int[] prices)
        {
            // left = buy, right = sell
            int left = 0, right = 1;
            /*🐕‍🦺*/       /*👣*/
            int maxProfit = 0;/*🌟*/

            // 0. while walker is < the length of the array
            while (right < prices.Length)
            {
                // 1. check if the prices 🐕‍🦺 < 👣
                if (prices[left] < prices[right])
                {
                    // 1. track profit: prices 🐕‍🦺 - 👣
                    int profit = prices[right] - prices[left];
                    // 2. update maxProfit to be Max(maxProfit, and currentProfit)
                    maxProfit = Math.Max(maxProfit, profit);
                }
                // 2. else left = right
                else
                {
                    left = right;
                }
                // 3. increment 👣
                right++;
            }
            return maxProfit;
        }
        #endregion
    }
    public static class MediumSlidingWindow
    {
    }
}