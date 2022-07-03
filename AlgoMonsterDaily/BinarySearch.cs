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
    }
}
