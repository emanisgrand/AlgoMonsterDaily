using System.Security.Cryptography.X509Certificates;

namespace DataStructures
{
    public struct Coordinate
    {
        public int r;
        public int c;

        public Coordinate(int r, int c)
        {
            this.r = r;
            this.c = c;
        }
    }
    public class Node<T>
    {
        public T val;

        public Node(T val)
        {
            this.val = val;
        }
    }
    public class GraphNode<T>
    {
        public T val;
        public List<GraphNode<T>> neighbors;
        public GraphNode(T val)
        {
            this.val = val;
        }
        public GraphNode(T val, List<GraphNode<T>> neighbors) : this(val)
        {
            this.neighbors = neighbors;
        }
    }

    public class GraphNode
    {
        public int val;
        public List<GraphNode> neighbors;

        public GraphNode(int _val)
        {
            val = _val;
            neighbors = new List<GraphNode>();
        }

        public GraphNode(int _val, List<GraphNode> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val)
        {

        }
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public class LRUCache : Dictionary<int, LinkedListNode<int[]>>
    {
        int _capacity;
        LinkedList<int[]> _list = new LinkedList<int[]>();

        public LRUCache(int capacity) : base(capacity)
        {
            _capacity = capacity;
        }

        public int Get(int key)
        {
            if (!this.ContainsKey(key))
            {
                return -1;
            }
            Reorder(this[key]);

            return this[key].Value[1];
        }

        public void Put(int key, int value)
        {
            if (this.ContainsKey(key))
            {
                this[key].Value[1] = value;
            }
            else
            {
                if (this.Count == this._capacity)
                {
                    //Evict by using key
                    this.Remove(_list.Last.Value[0]);
                    _list.RemoveLast();
                }

                this.Add(key, new LinkedListNode<int[]>(new int[] { key, value }));
            }

            Reorder(this[key]);
        }

        public void Reorder(LinkedListNode<int[]> node)
        {
            if (node.Previous != null)
                _list.Remove(node);

            if (_list.First != node)
                _list.AddFirst(node);
        }
    }
    public class TreeNode<T>
    {
        public T val;
        public TreeNode<T> left;
        public TreeNode<T> right;

        public TreeNode(T value)
        {
            this.val = value;
        }

        public TreeNode(T value, TreeNode<T> left, TreeNode<T> right) : this(value)
        {
            this.left = left;
            this.right = right;
        }
    }

    public static class BinarySearchTree
    {
        private static int dfs(TreeNode<int> root)
        {
            if (root == null) return 0;
            return Math.Max(dfs(root.left), dfs(root.right)) + 1;
        }
        public static int TreeMaxDepth(TreeNode<int> root)
        {
            return (root != null) ? dfs(root) - 1 : 0;
        }

        private static bool DFS(TreeNode<int> root, int min, int max)
        {
            if (root == null) return true;
            if (!(min <= root.val && root.val <= max)) return false;

            return DFS(root, min, root.val) && DFS(root, root.val, max);
        }

        public static bool IsValidBST(TreeNode<int> root)
        {
            return DFS(root, Int32.MinValue, Int32.MaxValue);
        }

        public static TreeNode<int> InsertBST(TreeNode<int> bst, int val)
        {
            if (bst == null) return new TreeNode<int>(val);
            int compareVal = bst.val.CompareTo(val);
            if (compareVal < 0) bst.right = InsertBST(bst.right, val);
            else if (compareVal > 0) bst.left = InsertBST(bst.left, val);

            return bst;
        }

        public static TreeNode<int> InvertBST(TreeNode<int> tree)
        {
            if (tree == null) return null;
            return new TreeNode<int>(tree.val, InvertBST(tree.right), InvertBST(tree.left));
        }
    }
}