namespace SlidingWindow
{
    public static class EasySlidingWindow
    {
        #region Best Time To Buy & Sell Stock
        public static int MaxProfit(int[] prices)
        {

            // left = buy, right = sell
            int left=0,  right=1;
            int maxProfit = 0;

            while (right < prices.Length)
            {
                if (prices[left] < prices[right])
                {
                    int profit = prices[right] - prices[left];
                    maxProfit = Math.Max(maxProfit, profit);
                }
                else
                {
                    left = right;
                }
                right++;
                    
            }
            return maxProfit;
        }
        #endregion
    }
}