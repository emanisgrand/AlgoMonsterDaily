using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoMonsterDaily
{
    public class BST
    {
        public static bool ValidBST(Node<int> root)
        {
            return DFS(root, Int32.MinValue, Int32.MaxValue);
        }
       
        public static bool DFS(Node<int> root, int min, int max)
        {
            // empty nodes always return true
            if (root == null) return true;
            if (!(min <= root.val && root.val <= max)) return false;

            return DFS(root.left, min, root.val) && DFS(root.right, root.val, max); 
        }

        public static Node<int> InsertBST(Node<int> bst, int val)
        {
            if (bst == null) return new Node<int>(val);
            int compareVal = bst.val.CompareTo(val);
            if (compareVal < 0) bst.right = InsertBST(bst.right, val);
            else if (compareVal > 0) bst.left =  InsertBST(bst.left, val);

            return bst;
        }        
    }


    class Program
    {
        public static void Main()
        {
            List<string> strs = DFS.SplitWords("37 19 2 x x 28 23 x x 35 x x 44 x 58 52 x x 67 x x");
            int pos = 0;
            Node<int> root = DFS.BuildTree(strs, ref pos, int.Parse);
            Node<int> result = BST.InsertBST(root, 42);
            Console.WriteLine(DFS.Serialize(result));
         }
    }
}
