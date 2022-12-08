namespace GeeksForGeeks
{
    public static class Triplets
    {
        public static List<int[]> FindTriplets(int[] arr, int n)
        {
            List<int[]> list = new List<int[]>();
            for (int i = 0; i < n - 2; i++)
            {
                for (int j = i + 1; j < n - 1; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        if (arr[i] + arr[j] + arr[k] == 0)
                        {
                            Console.WriteLine("{0} {1} {2}", arr[i], arr[j], arr[k]);
                            list.Add(new int[] { arr[i], arr[j], arr[k] });
                        }
                    }
                }
            }
            return list;
        }
    }
}

namespace AlgoMonster
{
    public static class BinarySearch
    {
        public static int Vanilla(List<int> arr, int target)
        {
            int left = 0;  // 🐕‍🦺
            int right = arr.Count - 1; // 🐕‍🦺

            while (left <= right)
            {
                int mid = left + (right - left) / 2;  // 👻
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

        public static int FirstBoundary(List<bool> arr)
        {
            int left = 0;  // 🐕‍🦺
            int right = arr.Count - 1; // 🐕‍🦺
            int boundaryIndex = -1;    // 🌟

            while (left <= right)
            {
                int mid = (left + right) / 2;  // 👻
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

        public static int FirstNotSmaller(List<int> arr, int target)
        {
            int left = 0;
            int right = arr.Count - 1;

            int mostWanted = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] >= target)
                {
                    mostWanted = mid;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return mostWanted;
        }

        public static int FirstOcurrence(List<int> arr, int target)
        {
            int left = 0;
            int right = arr.Count - 1;

            int mostWanted = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == target)
                {
                    mostWanted = mid;
                    right = mid - 1;
                }
                else if (arr[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return mostWanted;
        }

        public static int SquareRoot(int n)
        {
            if (n == 0) return 0;

            int left = 1;
            int right = n;
            int sqrt = 0;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (mid == n / mid) return mid;
                else if (mid < n / mid)
                {
                    sqrt = mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return sqrt;
        }
    }
    public static class DFSearch
    {
        private static void dfs(int startIndex, List<string> res, bool[] used, List<char> path, string letters)
        {
            if (startIndex == used.Length)
            {
                res.Add(String.Join("", path));
                return;
            }

            for (int i = 0; i < used.Length; i++)
            {
                if (used[i]) continue;

                path.Add(letters[i]);
                used[i] = true;
                dfs(startIndex + 1, res, used, path, letters);

                path.RemoveAt(path.Count - 1);
                used[i] = false;
            }
        }

        public static List<string> Permutations(string letters)
        {
            List<string> res = new List<string>();
            dfs(0, res, new bool[letters.Length], new List<char>(), letters);
            return res;
        }

    }
}