using DataStructures;

namespace LinkedLists
{
    public static class EasyLinkedList
    {
        public static ListNode MergeSortedLists(ListNode list1, ListNode list2)
        {
            // --. if the list itself is null, return that list
            if (list1 == null) return list1;
            if (list2 == null) return list2;
            // 🍒 clears edge cases of inserting into an empty list; init inline
            ListNode dummyNode = new ListNode(), cur = dummyNode;
            // 0. while list 1 and l2 are not null
            while (list1 != null && list2!=null)
            {
                // 1. if l1 value < l2 value
                if (list1.val < list2.val)
                {
                    // 1. point next to smaller value
                    cur.next = list1;
                    // 2. point the winner's next 
                    list1 = list1.next;
                }
                else
                {
                    // 1. point next to other list 
                    cur.next = list2;
                    // 2. update other list's next
                    list2 = list2.next;
                }

                // 2. point current to next.
                cur = cur.next;
            }

            // 1. if list1 not null
            if (list1 != null)
                // current's next is list 1
                cur.next = list1;

            // 2. if list2 not null
            if (list2 != null)
                // current's next is list 2
                cur.next = list2;

            return dummyNode.next;
        }

        public static void ReverseLinkedList()
        {
            
        }

        

        public static void RemoveNthNode()
        {

        }
    }
}