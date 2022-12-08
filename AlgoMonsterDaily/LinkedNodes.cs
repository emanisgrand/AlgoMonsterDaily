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

        public static ListNode ReverseListTwoPointer(ListNode head)
        {
            if (head == null || head.next == null) return head;
            
            ListNode left = head; /*👣 || 🐕‍🦺*/
            ListNode middle;
            ListNode right;
            
            /*
            //0. while current pointer is not null
            while (slow != null)
            {
                // 1. temporary pointer storing the next node
                
                // 2. fast next is looking back at slow
                fast.next = slow;  // S<-F
                // 3. slow is looking up at fast
                slow = fast; // S = F
                // 4. fast is looking forward
                fast = fast.next; // F -> N

            }
            */
            return null;
        }

        public static ListNode ReverseListRecursive(ListNode head)
        {
            // Reverse all but the head.

            //0. if head is null return null
            if (head != null) return null;
            // new head = head
            ListNode newHead = head;
            // 1. if head next is not null
            if (head.next != null)
            {
                // 1. newhead = reverseTheList(head.next)
                newHead = ReverseListRecursive(head.next);
                // 2. head.next.next = head reverses the link between next node and head.
                head.next.next = head;
            }
            // 2. head.next is null. if head is first in list, set next ptr to null
            head.next = null;
            // return newHead
            Console.WriteLine(newHead.val);
            return newHead;
        }

        public static void ReverseLinkedList()
        {
            
        }

        

        public static void RemoveNthNode()
        {

        }
    }
}