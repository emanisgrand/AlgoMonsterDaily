using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class LinkedLRUCache : Dictionary<int, LinkedListNode<int>>
    {
        uint _capacity;
        LinkedList<int> _list = new LinkedList<int>();
        public LinkedLRUCache(uint capacity):base((int)capacity)
        {
            _capacity = capacity;
        }

        public int Get(int key)
        {
            return this.TryGetValue(key, out var node) ? node.Value : -1;
        }

        public void Put(int key, int value)
        {
            if(this.ContainsKey(key))
            {
                this[key].Value = value;
            }
            else
            {
                if(this.Count == this._capacity)
                {
                    this.Remove(_list.Last.Value); 
                    _list.RemoveLast(); 
                }

                this.Add(key, new LinkedListNode<int>(value));
            }

            Reorder(this[key]);
        }

        public void Reorder(LinkedListNode<int> node)
        {
            if (node.Previous != null) 
                _list.Remove(node);

            if(_list.First != node)
                _list.AddFirst(node);
        }
    }

    public class LRUCache : Dictionary<int, int>
    {
        uint _capacity;
        public LRUCache(uint capacity) : base((int)capacity)
        {
            _capacity = capacity;
        }

        public int Get(int key)
        {
            if (base.TryGetValue(key, out int value))
            {
                return value;
            }
            else
            {
                return -1;
            }
        }

        public void Put(int key, int value)
        {
            if (this.ContainsKey(key))
            {
                this[key] = value;
            }else
            {
                this.Add(key, value);
            }
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
