using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class LRUCache
    {
        int capacity;
        Dictionary<int, int> cache;

        public LRUCache(int capacity)
        {
            if (capacity < 0) { throw new ArgumentOutOfRangeException(); }
            this.capacity = capacity;
            this.cache = new Dictionary<int, int>();
        }

        public int Get(int key)
        {
            return -1;
        }

        public void Put(int key, int value)
        {
            
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
    
}
