namespace AlgoMonsterDaily
{
    public class DFS
    {   
        public static TreeNode<T> BuildTree<T>(List<string> strs, ref int pos, Func<string, T> f)
        {
            string val = strs[pos];
            pos++;
            if (val == "x") return null;
            TreeNode<T> left = BuildTree<T>(strs, ref pos, f);
            TreeNode<T> right = BuildTree<T>(strs, ref pos, f);
            return new TreeNode<T>(f(val), left, right);
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
            if (root == null) { 
                tree.Add("x"); 
            } else {
                tree.Add(root.val.ToString());
                PrintTree(root.left, tree);
                PrintTree(root.right, tree);
            }
        }
    }
}
