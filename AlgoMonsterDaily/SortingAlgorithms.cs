using DataStructures;

namespace Algorithms.Sort
{
    public static class MergeSort
    {
        public static void WTF(Node<int> nodeList)
        {
            Node<int> referenceFromPointer = new Node<int>(62);
            Node<int> pointer = referenceFromPointer;
            while(nodeList != null)
            {
                if (nodeList.val < referenceFromPointer.val)
                {
                    pointer.next = nodeList;
                    // current value of the linked list is joined with
                    // the node list pointer. the value then changes.
                    nodeList = nodeList.next;
                }
            }
        }

        public static Node<int> Merge(Node<int> Alist, Node<int> BList)
            {
            Node<int> dummyList = new Node<int>(0); // gatherer?
            Node<int> curList = dummyList; // follower?

            while(Alist != null && BList != null)
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
        
}
