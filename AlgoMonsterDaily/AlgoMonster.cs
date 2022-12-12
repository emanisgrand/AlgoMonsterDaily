using DataStructures;

namespace AlgoMonster
{
    public static class MergeSort
    {
        public static ListNode Merge(ListNode Alist, ListNode BList)
        {
            ListNode dummyList = new ListNode(0);
            ListNode curList = dummyList;

            while (Alist != null && BList != null)
            {
                if (Alist.val < BList.val)
                {
                    curList.next = Alist;
                    Alist = Alist.next;
                }
                else
                {
                    curList.next = BList;
                    BList = BList.next;
                }
                curList = curList.next;
            }
            curList.next = Alist != null ? Alist : BList;
            return dummyList.next;
        }
    }
    public static class Graphs
    {
        public static int[,] AryFloodFill(int r, int c, int replacement, int[,] image)
        {
            int numRows = 5;
            int numCols = 5;

            aryBfs(image, new Coordinate(r, c), replacement, numRows, numCols);
            return image;
        }

        private static void aryBfs(int[,] image, Coordinate root, int replacementColor, int numRows, int numCols)
        {
            Queue<Coordinate> queue = new Queue<Coordinate>();
            queue.Enqueue(root);

            bool[,] visited = new bool[numRows, numCols];

            int rootColor = image[root.r, root.c];


            image[root.r, root.c] = replacementColor;

            visited[root.r, root.c] = true;

            while (queue.Count > 0)
            {
                Coordinate node = queue.Dequeue();

                List<Coordinate> neighbors = AryGetNeighbors(image, node, rootColor, numRows, numCols);

                foreach (Coordinate neighbor in neighbors)
                {

                    if (visited[neighbor.r, neighbor.c]) continue;

                    image[neighbor.r, neighbor.c] = replacementColor;

                    queue.Enqueue(neighbor);

                    visited[neighbor.r, neighbor.c] = true;

                }
            }
        }
        private static List<Coordinate> AryGetNeighbors(int[,] image, Coordinate node, int rootColor, int numRows, int numCols)
        {
            List<Coordinate> neighbors = new List<Coordinate>();

            int[] deltaRow = { -1, 0, 1, 0 };
            int[] deltaCol = { 0, 1, 0, -1 };

            for (int i = 0; i < deltaRow.Length; i++)
            {

                int neighborRow = node.r + deltaRow[i];
                int neighborCol = node.c + deltaCol[i];

                if (0 <= neighborRow && neighborRow < numRows && 0 <= neighborCol && neighborCol < numCols)
                {
                    if (image[neighborRow, neighborCol] == rootColor)
                    {
                        neighbors.Add(new Coordinate(neighborRow, neighborCol));
                    }
                }
            }
            return neighbors;
        }
        public static List<List<int>> floodFill(int r, int c, int replacement, List<List<int>> image)
        {
            int numRows = image.Count;
            int numCols = image[0].Count;

            bfs(image, new Coordinate(r, c), replacement, numRows, numCols);

            return image;
        }
        private static void bfs(List<List<int>> image, Coordinate root, int replacementColor, int numRows, int numCols)
        {

            Queue<Coordinate> queue = new Queue<Coordinate>();
            queue.Enqueue(root);


            bool[,] visited = new bool[numRows, numCols];


            int rootColor = image[root.r][root.c];


            image[root.r][root.c] = replacementColor;


            visited[root.r, root.c] = true;


            while (queue.Count > 0)
            {
                Coordinate node = queue.Dequeue();

                List<Coordinate> neighbors = getNeighbors(image, node, rootColor, numRows, numCols);

                foreach (Coordinate neighbor in neighbors)
                {

                    if (visited[neighbor.r, neighbor.c]) continue;

                    image[neighbor.r][neighbor.c] = replacementColor;

                    queue.Enqueue(neighbor);

                    visited[neighbor.r, neighbor.c] = true;

                }
            }
        }
        private static List<Coordinate> getNeighbors(List<List<int>> image, Coordinate node, int rootColor, int numRows, int numCols)
        {
            List<Coordinate> neighbors = new List<Coordinate>();

            int[] deltaRow = { -1, 0, 1, 0 };
            int[] deltaCol = { 0, 1, 0, -1 };

            for (int i = 0; i < deltaRow.Length; i++)
            {

                int neighborRow = node.r + deltaRow[i];
                int neighborCol = node.c + deltaCol[i];

                if (0 <= neighborRow && neighborRow < numRows && 0 <= neighborCol && neighborCol < numCols)
                {
                    if (image[neighborRow][neighborCol] == rootColor)
                    {
                        neighbors.Add(new Coordinate(neighborRow, neighborCol));
                    }
                }
            }
            return neighbors;
        }

    }
    public class TwoPointers
    {
        #region Same Direction
        public static int MiddleOfLinkedList(ListNode head)
        {
            int slowptr = 0;
            int fastptr = 0;
            while (head.next != null)
            {
                fastptr++;
            }
            if (fastptr % 2 == 0)
                slowptr = fastptr / 2;
            slowptr = fastptr / 2 + 1;
            return slowptr;
        }
        #endregion

        #region Opposite Direction
        public static bool IsPalindrome(string s)
        {
            int left = 0;
            int right = s.Length;

            while (left < right)
            {
                while (left < right && !Char.IsLetterOrDigit(s[left]))
                {
                    left++;
                }
                while (left < right && !Char.IsLetterOrDigit(s[right]))
                {
                    right--;
                }
                // ignore case:
                if (Char.ToLower(s[left]) != Char.ToLower(s[right])) { return false; }

                left++;
                right--;
            }
            return true;
        }
        #endregion
    }
    public class Hashing
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int cur = nums[i];
                int x = target - cur;
                if (map.ContainsKey(x))
                {
                    return new int[] { map[x], i };
                }
                map.Add(cur, i);
            }

            return null;
        }
    }
    public class SlidingWindow
    {
        public static int LongestSubstring(string s)
        {
            // simplified inductive reasoning. 
            int n = s.Length;
            int longest = 0;
            int right = 0; // k       }   
            int left = 0;  // k`+1    }
            List<char> window = new List<char>();
            while (right < n)
            {
                if (!window.Contains(s[right]))
                {
                    window.Add(s[left]);
                    right++;
                }
                else
                {
                    window.Remove(s[left]);
                    left++;
                }
                longest = Math.Max(longest, right - left); //TODO: why right - left?
            }
            return longest;
        }

        public static List<int> FindAllAnagrams(string original, string check)
        {
            int oLength = original.Length;
            int cLength = check.Length;
            List<int> res = new List<int>();
            if (oLength < cLength) { return res; }
            // stores the frequency of each character in the check string
            int[] charCheck = new int[26];
            int[] window = new int[26];
            // first window
            for (int i = 0; i < cLength; i++)
            {
                // converting the character to its number in an alphabet array.
                // that gives the index in an array of 26 
                charCheck[check.ElementAt(i) - 'a']++;
                window[original.ElementAt(i) - 'a']++;
            }
            // compare the two sets. 
            if (Enumerable.SequenceEqual(window, charCheck)) // first instance of a match
                res.Add(0);


            for (int i = cLength; i < oLength; i++)
            {   // moving the window. 
                window[original.ElementAt(i - cLength) - 'a']--;
                window[original.ElementAt(i) - 'a']++;
                // compare the alphas
                if (Enumerable.SequenceEqual(window, charCheck))
                    // i is clength. i - clength + 1 is the first letter of the anagram.
                    // add the index of that letter to the result. todo: confirm
                    res.Add(i - cLength + 1);
            }
            return res;
        }

        public static string GetMinimumWindow(string original, string check)
        {
            // char counter in t
            var charCheck = new Dictionary<char, int>();

            foreach (var c in check)
            {
                if (!charCheck.ContainsKey(c))
                {
                    charCheck[c] = 0;
                }
                charCheck[c]++;
            }

            var l = 0;
            var window = new Dictionary<char, int>();

            var coveredL = -1; // left index in s
            var coveredR = -1; // right index in s 
            var coveredLen = Int32.MaxValue;

            string result = "";

            for (var r = 0; r < original.Length; r++)
            {
                var c = original[r];
                if (!window.ContainsKey(c))
                {
                    window[c] = 0;
                }
                window[c]++;

                // covered, try minimizing result
                while (charCheck.All(kvp => window.ContainsKey(kvp.Key) && window[kvp.Key] >= kvp.Value))
                {
                    if ((r - l + 1) <= coveredLen)
                    {
                        result = string.Join("", original.Substring(l, r - l + 1));
                        coveredL = l;
                        coveredR = r;
                        coveredLen = r - l + 1;
                    }

                    window[original[l]] -= 1;
                    l++;
                }
            }

            return coveredL == -1 ? "" : result;
        }
    }
    public class DepthFirstSearch
    {
        public IList<int> InorderTraversal(TreeNode<int> root)
        {
            IList<int> list = new List<int>();
            return list;
        }
        public static int TreeMaxDepth(TreeNode<int> root)
        {
            if (root == null) return 0;
            return Math.Max(TreeMaxDepth(root.left), TreeMaxDepth(root.right)) + 1;
        }
        public static int VisibleTreeNode(TreeNode<int> root)
        {
            return dfs(root, Int32.MinValue);
        }
        private static int dfs(TreeNode<int> root, int maxSoFar)
        {
            if (root == null) return 0;
            int visible = 0;

            if (root.val > maxSoFar)
                visible++;

            visible += dfs(root.left, Math.Max(maxSoFar, root.val));
            visible += dfs(root.right, Math.Max(maxSoFar, root.val));

            return visible;
        }

        public static int TreeHeight(TreeNode<int> tree)
        {
            if (tree == null) return 0;

            int leftHeight = TreeHeight(tree.left);
            int rightHeight = TreeHeight(tree.right);

            if (leftHeight == -1 || rightHeight == -1)
                return -1;
            // calculate difference of heigt of subtree
            if (Math.Abs(leftHeight - rightHeight) > 1)
                return -1;

            // similar to TreeMaxDepth
            return Math.Max(leftHeight, rightHeight) + 1;

        }
        public static bool IsBalanced(TreeNode<int> tree)
        {
            return TreeHeight(tree) != -1;
        }

        public static TreeNode<int> Deserialize(string root)
        {
            // use this function to create and store the reference to pos.
            int pos = 0;
            return DeserializeDFS(root.Split(" ").ToList(), ref pos);
        }

        public static TreeNode<int> DeserializeDFS(List<string> nodes, ref int pos)
        {
            string val = nodes[pos];
            pos++;

            if (val == "x") return null;


            TreeNode<int> cur = new TreeNode<int>(int.Parse(val));
            cur.left = DeserializeDFS(nodes, ref pos);
            cur.right = DeserializeDFS(nodes, ref pos);
            return cur;
        }
        public static string Serialize(TreeNode<int> root)
        {
            List<string> res = new List<string>();
            SerializeDFS(root, res);
            return string.Join(" ", res);
        }
        public static void SerializeDFS(TreeNode<int> root, List<string> result)
        {
            if (root == null)
            {
                result.Add("x");
                return;
            }
            result.Add(root.val.ToString());
            SerializeDFS(root.left, result);
            SerializeDFS(root.right, result);
        }
        // Lowest Common Ancestor
        public static TreeNode<int> Lca(TreeNode<int> root, TreeNode<int> node1, TreeNode<int> node2)
        {
            if (root == null) return null;

            //2 
            if (Object.ReferenceEquals(root, node1) || Object.ReferenceEquals(root, node2))
                return root;
            TreeNode<int> left = Lca(root.left, node1, node2);
            TreeNode<int> right = Lca(root.right, node1, node2);

            //1
            if (left != null && right != null) return root;

            // 4 & 5
            if (left != null) return left;
            if (right != null) return right;

            // 3
            return null;
        }

        public static TreeNode<int> FindNode(TreeNode<int> root, int target)
        {
            if (root == null) return null;

            if (root.val == target) return root;

            TreeNode<int> leftSearch = FindNode(root.left, target);
            if (leftSearch != null) return leftSearch;

            return FindNode(root.right, target);
        }
        public static void PrintTree<T>(TreeNode<T> root, List<string> tree)
        {
            if (root == null)
            {
                tree.Add("x");
            }
            else
            {
                tree.Add(root.val.ToString());
                PrintTree(root.left, tree);
                PrintTree(root.right, tree);
            }
        }

    }
}