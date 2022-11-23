using System.Collections;

namespace DataStructures
{
    public class ArrList
    {
        ArrayList _arrayList = new ArrayList();
        
        public void ArrayListsAreCool()
        {
            _arrayList.Clear();
            _arrayList.Sort();
            _arrayList.Add("asdsa");
            _arrayList.Add(123132);
            _arrayList.Add(123132f);
        }
    }
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
        public Node<T> next;

        public Node(T val)
        {
            this.val = val;
        }

        public Node(T val, Node<T> next) : this(val)
        {
            this.next = next;
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
            if (!this.ContainsKey(key))
            {
                return -1;
            }
            Reorder(this[key]);

            return this[key].Value[1];
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
}