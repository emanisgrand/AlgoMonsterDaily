using DataStructures;

namespace Algorithms.Sort
{
    public static class MergeSort
    {
        public static Node<int>WTF(Node<int> inputNode)
        {
            Node<int> StartingNode = new Node<int>(new Random().Next(99));
            Node<int> linkedToStartingNode = StartingNode; // accumulator?

            Node<int> PassingNode = new Node<int>(new Random().Next(99));
            PassingNode.next = new Node<int>(new Random().Next(99));
            PassingNode.next.next = new Node<int>(new Random().Next(99));

            Node<int> RandomNode = new Node<int>(new Random().Next(99));
            RandomNode.next = new Node<int>(new Random().Next(99));
            RandomNode.next.next = new Node<int>(new Random().Next(99));

            while (inputNode != null)
            {
                if (RandomNode.val < PassingNode.val)
                {
                    linkedToStartingNode.next = RandomNode; // adds all nodes in this node to StartingNode
                    
                    RandomNode = RandomNode.next; // move values forward.
                }
                else
                {   
                    linkedToStartingNode.next = PassingNode;

                    PassingNode = PassingNode.next;
                }

                inputNode = inputNode.next;
                
                linkedToStartingNode = linkedToStartingNode.next; // move the linked node's values forward
            }

            return linkedToStartingNode.next; // accumulated. 
        }

        public static Node<int> MergeRoles(Node<int> Walker1, Node<int> Walker2)
        {
            Node<int> Gatherer = new Node<int>(0);
            Node<int> MostWanted = Gatherer;

            while(Walker1 != null && Walker2 != null)
            {
                if (Walker1.val < Walker2.val)
                {
                    MostWanted.next = Walker1;
                    Walker1 = Walker1.next;
                }
                else
                {
                    MostWanted.next = Walker2;
                    Walker2 = Walker2.next;
                }
                MostWanted = MostWanted.next;
            }
            MostWanted.next = Walker1 != null ? Walker1 : Walker2;
            return Gatherer.next;
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
