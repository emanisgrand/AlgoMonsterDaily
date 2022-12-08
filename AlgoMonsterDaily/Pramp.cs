namespace PrampPracetice
{
    public static class Pramp
    {
        #region Cheapest Cost (N-Ary Tree)
        public class Node
        {
            public int cost;
            public Node[] children;
            public Node parent;
        }

        public static int getCheapestCost(Node rootNode)
        {
            // RECURSE

            // 1. check if the current node has any children.
            int n = rootNode.children.Length; // 👻
            // 2. if not, you are at a leaf node, return the node's cost.
            if (n == 0) return rootNode.cost;
            else
            {
                // 1. otherwise start looking for the minCost by looping through the children
                int minCost = Int32.MaxValue;  // 🌟
                for (int i = 0; i < n; i++)
                {
                    // 2. find cheapest cost from among the little children recursively
                    int tempCost = getCheapestCost(rootNode.children[i]);
                    // 3. if the cost returned is less than the current minimum cost, update mincost
                    if (tempCost < minCost)
                        minCost = tempCost;
                }
                // 3. return the minCost plus the cost of the node to the stack.
                return minCost + rootNode.cost;
            }
        }
        #endregion
        #region Reverse Words
        public static char[] ReverseWords(char[] arr)
        {
            // 1. reverse all the characters in arr 
            int start = 0;
            for (int end = 0; end < arr.Length; end++)
            {
                // if we've encountered a space
                // reverse the previous word (between the indices start and end -1)
                if (arr[end] == ' ')
                {
                    mirrorReverse(arr, start, end);
                    start = end + 1;
                }
            }

            // Reverse the last word
            mirrorReverse(arr, start, arr.Length - 1);


            // Reverse the entire string
            mirrorReverse(arr, 0, arr.Length - 1);

            return arr;
        }
        public static void mirrorReverse(char[] arr, int start, int end)
        {
            /*🌡️*/ // store character
            char tmp;
            while (start < end)
            {
                // swap the first and last characters
                tmp = arr[start];
                arr[start] = arr[end];
                arr[end] = tmp;
                start++;
                end--;
            }
        }
        #endregion 
    }
}