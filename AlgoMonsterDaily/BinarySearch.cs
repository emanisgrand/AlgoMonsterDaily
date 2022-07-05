namespace AlgoMonsterDaily
{
    public class BinarySearch
    {
        public static int VanillaSearch(List<int> arr, int target)
        {
            int left = 0;
            int right = arr.Count - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] == target) return mid;
                if (arr[mid] < target)
                {
                    left = mid + 1;
                } 
                else
                {
                    right = mid - 1;
                }
            }
            return -1;
        }
        public static int FindBoundary(List<bool> arr)
        {
            int left = 0;
            int right = arr.Count - 1;
            int boundaryIndex = -1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (arr[mid])
                {
                    boundaryIndex = mid;
                    right = mid - 1;
                } 
                else
                {
                    left = mid + 1;
                }
            }
            return boundaryIndex;
        }

        #region Sorted Arrays
        public static int FirstNotSmaller(List<int> arr, int target)
        {
            int left = 0;
            int right = arr.Count - 1;
            int boundaryIndex = -1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] >= target)
                {
                    boundaryIndex = mid;
                    right = mid - 1;
                } else
                {
                    left = mid + 1;
                }
            }
            return boundaryIndex;
        }

        public static int FirstOccurrence(List<int> arr, int target)
        {
            int targetIndex = -1;
            int left = 0;
            int right = arr.Count - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] == target)
                {
                    targetIndex = mid;
                    right = mid - 1;
                } else if (arr[mid] < target)
                {
                    left = mid + 1;
                } else
                {
                    right = mid - 1;
                }
            }
            return targetIndex;
        }

        public static int SquareRoot(int n)
        {
            if (n == 0) return 0;
            int left = 1;
            int right = n;
            int res = -1;
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                if (mid <= n / mid)
                {
                    res = mid;
                    left = mid + 1;
                } else
                {
                    right = mid - 1;
                }
            }
            return res;
        }

        #endregion

        #region Implicitly Sorted Array
        // find minimum in rotated sorted array.


        // the peak of a mountain array
        #endregion
    }
}
