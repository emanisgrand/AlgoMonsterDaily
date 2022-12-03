namespace Algorithms
{
    public static class Kadane
    {
        #region Brute Force
        /// <summary>
        /// Sums up values in the array and keeps track of highest value stored in O(n²) time.
        /// </summary>
        /// <param name="arr">numbers array</param>
        /// <returns>Maximum sum of subarray</returns>
        public static int KadaneBruteForce(int[] arr) 
        {
            // 🌟
            int maxSum = arr[0];

            for (int i=0; i < arr.Length; i++)
            {
                // 👻
                int curSum = 0;

                for (int j = i; j < arr.Length; j++) // 🐕‍🦺 
                {
                    // sum up the current value of this iteration
                    curSum += arr[j];
                    // the maximum sum should always be the the highest value between the current sum and the current maximum sum.
                    maxSum = Math.Max(maxSum, curSum);
                }
            }
            return maxSum;
        }
        #endregion
        #region Linear
        /// <summary>
        /// Find non empty subarray with the largest sum in O(n) time.
        /// </summary>
        /// <param name="arr">numbers</param>
        /// <returns>max sum</returns>
        public static int KadaneLinear(int[] arr) 
        {
            //🌟
            int maxSum = arr[0];
            //👻
            int curSum = 0;
            // Begin operating on every value within the array:
            foreach (int n in arr)
            {
                // the current sum holder should not be negative while still keeping the value from the array
                curSum = Math.Max(curSum, 0);
                // sum up the current value being operated on. 
                curSum += n;
                // update the maximum sum to be the highest number between the current sum and the maximum sum.
                maxSum = Math.Max(curSum, maxSum);
            }
            return maxSum;
        }
        #endregion
        #region Sliding Window
        public static int[] KadaneWindow(int[] nums) 
        {
            // 🌟   
            int maxSum = nums[0];
            // 👻
            int curSum = 0;
            // 🧟 🧟
            int maxLeft = 0, maxRight = 0;
            // 🐕‍🦺
            int left = 0;
            // loop through the array, instantiating the faster pointer. 
            for (int right = 0; right < nums.Length; right++)
            {
                // check and
                if (curSum < 0)
                //      ensure current sum is never negative. 
                {
                    curSum = 0;
                    //      bring the pointers up to the same place
                    left = right;
                }
                // sum up the current sum with the end of the subarray index
                curSum += nums[right]; 
                // if the current sum is greater than the max sum
                if (curSum  > maxSum)
                // update the max sum to be the current sum
                {
                    maxSum = curSum;
                    // the maximum for left and right should be whatever the current left and right are.
                    maxLeft = left;
                    maxRight = right;
                }
            }
            return new int[] { maxLeft, maxRight };
        }
        #endregion
    }
}