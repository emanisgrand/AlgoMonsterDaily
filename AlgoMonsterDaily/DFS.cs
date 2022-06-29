namespace AlgoMonsterDaily
{
    public class DFS
    {
        public static List<string> SplitWords(string s)
        {
            return string.IsNullOrEmpty(s) ? new List<string>() : s.Trim().Split(' ').ToList();
        }

        public static Node<T> BuildTree<T>(List<string> strs, ref int pos, Func<string, T> f)
        {
            string val = strs[pos];
            pos++;
            if (val == "x") return null;
            Node<T> left = BuildTree<T>(strs, ref pos, f);
            Node<T> right = BuildTree<T>(strs, ref pos, f);
            return new Node<T>(f(val), left, right);
        }

        public static Node<int> Deserialize(string root)
        {
            // use this function to create and store the reference to pos.
            int pos = 0;
            return DeserializeDFS(root.Split(" ").ToList(), ref pos);
        }
        // 5 4 3 x x 8 x x 6 x x
        public static Node<int> DeserializeDFS(List<string> nodes, ref int pos)
        {
            string val = nodes[pos];
            pos++;
            
            if (val == "x") return null;
            

            Node<int> cur = new Node<int>(int.Parse(val));
            cur.left = DeserializeDFS(nodes, ref pos);
            cur.right = DeserializeDFS(nodes, ref pos);
            return cur;
        }

        public static Node<int> FindNode(Node<int> root, int target)
        {
            if (root == null) return null;

            if (root.val == target) return root;

            Node<int> leftSearch = FindNode(root.left, target);
            if (leftSearch != null) return leftSearch;
            
            return FindNode(root.right, target);
        }
        public static string Serialize(Node<int> root)
        {
            List<string> res = new List<string>();
            SerializeDFS(root, res);
            return string.Join(" ", res);
        }
        public static void SerializeDFS(Node<int> root, List<string> result)
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

        public static Node<int> Lca(Node<int> root, Node<int> node1, Node<int> node2)
        {
            if (root == null) return null;

            //2 
            if (Object.ReferenceEquals(root, node1) || Object.ReferenceEquals(root, node2))
                return root;
            Node<int> left = Lca(root.left, node1, node2);
            Node<int> right = Lca(root.right, node1, node2);

            //1
            if (left != null && right != null) return root;

            // 4 & 5
            if (left != null) return left;
            if (right != null) return right;

            // 3
            return null;
        }

        public static void FindNode()
        {

        }
        public static void PrintTree<T>(Node<T> root, List<string> tree)
        {
            if (root == null) { 
                tree.Add("x"); 
            } else {
                tree.Add(root.val.ToString());
                PrintTree(root.left, tree);
                PrintTree(root.right, tree);
            }
        }

        public static int TreeMaxDepth(Node<int> root)
        {
            if (root == null) return 0;
            return Math.Max(TreeMaxDepth(root.left), TreeMaxDepth(root.right)) + 1;
        }

        private static int dfs(Node<int> root, int maxSoFar)
        {
            if (root == null) return 0;
            int total = 0;

            if (root.val > maxSoFar)
                total++;

            total += dfs(root.left, Math.Max(maxSoFar, root.val));
            total += dfs(root.right, Math.Max(maxSoFar, root.val));

            return total;
        }
        public static int VisibleTreeNode(Node<int> root)
        {
            return dfs(root, Int32.MinValue);
        }
    }
}
