using System.Data;

namespace Binary
{
    public static class RotateSorted
    {
        public static int FindMin(int[] nums)
        {
            return 0;
        }

        /// <summary>
        /// Compare target with left and right values of pivot
        /// </summary>
        /// <param name="nums">possibly rotated array of integers</param>
        /// <param name="target">value to determine </param>
        /// <returns></returns>
        public static int Search(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target) return mid;

                if (nums[left] <= nums[mid])
                {
                    if (nums[left] <= target && target <= nums[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                } 
                else
                {
                    if (nums[mid] <= target && target <= nums[right])
                    {
                        left = mid + 1;
                    } 
                    else
                    {
                        right = mid - 1;
                    }
                }
            }
            return -1;
        }
        public static int BruteForceSearch(int[] nums, int target)
        {
            int ans = -1;
            int counter = 0;
            foreach(int num in nums)
            {
                if (num == target)
                {
                    ans = counter;
                }
                counter++;
            }
            return ans;
        }
    }
}