namespace BinarySearching
{
    public static class BinarySearch
    {
        /// <summary>
        /// TODO: Write summary
        /// </summary>
        /// <param name="nums">possibly rotated array of integers</param>
        /// <param name="target">value to determine </param>
        /// <returns></returns>
        public static int Rotated(int[] nums, int target)
        {
            // 0. initialize pointers
            int left = 0, right = nums.Length - 1;

            // 1. while left <= right because in this case left/right can be ==
            while (left < right)
            {
                // 1. initialize mid
                int mid = (left + right) / 2;

                // 2. return mid if it's target
                if (nums[mid] == target) return mid; //✅
                // 3. check if on left side of sorted array
                else if (nums[mid] >= nums[left])
                {
                    // 1. condition for erasing left
                    if (nums[left] <= target && target <= nums[mid])
                    {
                        // 1. update right
                        right = mid - 1;
                    }
                    else
                    {
                        // 2. update left
                        left = mid + 1;
                    }
                }
                else //4. right sorted portion
                {
                    // 1. condition for erasing unused portion
                    if (nums[mid] <= target && target <= nums[right])
                    {
                        // 1. update left
                        left = mid + 1; 
                    }
                    else
                    {
                        // 2. update right
                        right = mid - 1;
                    }
                }
            }
            // return -1 
            return -1;
        }
    }
}