using DataStructures;

namespace Algorithms.Sort
{
    public static class MergeSort
    {
        public static Node<int> Merge(Node<int> Alist, Node<int> BList)
        {
            Node<int> dummyList = new Node<int>(0); // follower?
            Node<int> curList = dummyList; // most-wanted holder
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
