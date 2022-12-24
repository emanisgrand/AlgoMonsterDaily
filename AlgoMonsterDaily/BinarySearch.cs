using System.Data;

namespace Binary
{
    public static class RotateSorted
    {
        public static int FindMin(int[] nums)
        {
            // something to store the result
            int res = nums[0];
            // left and right pointers
            int left = 0, right = nums.Length - 1;
            
            // while left is <= right
            while (left <= right)
            {
                // check both ends of the array to see if it's in sorted order.
                // if it is, return the minimum of current result value and 
                // value that is on the leftmost side of the array
                if (nums[left] < nums[right]) return Math.Min(res, nums[left]);
                
                // compute the mid pointer now that we'll be doing binary search
                int mid = (left + right) / 2;

                // update result variable with the minimum between current result and current value at mid
                // it could be the pivot point and thus the smallest value.
                res = Math.Min(res, nums[mid]);

                // is mid value part of left sorted portion?
                if (nums[mid] >= nums[left])
                // then update left so we can scan right side
                {
                    left = mid + 1;
                }
                // else
                else
                {
                    // update right so we can scan left side
                    right = mid - 1;
                }
                // return result.
            }
            
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