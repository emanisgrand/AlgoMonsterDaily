﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class LRUCache : Dictionary<int, LinkedListNode<int[]>>
    {
        int _capacity;
        LinkedList<int[]> _list = new LinkedList<int[]>();
        public LRUCache(int capacity):base(capacity)
        {
            _capacity = capacity;
        }

        public int Get(int key)
        {
            return this.TryGetValue(key, out var node) ? node.Value[1] : -1;
        }

        public void Put(int key, int value)
        {
            if(this.ContainsKey(key))
            {
                this[key].Value[1] = value;
            }
            else
            {
                if(this.Count == this._capacity)
                {
                    //Evict by using key
                    this.Remove(_list.Last.Value[0]); 
                    _list.RemoveLast(); 
                }

                this.Add(key, new LinkedListNode< int[]> (new int []{key, value} ) );
            }

            Reorder(this[key]);
        }

        public void Reorder(LinkedListNode<int[]> node)
        {
            if (node.Previous != null)
                _list.Remove(node);

            if(_list.First != node)
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
    
}
