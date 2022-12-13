using DataStructures;

namespace Graphs
{
    public static class BFSClone
    { // BLIND: ❌ ✅✅
        /// <summary>
        /// Enqueue neighbors of input node to run BFS and make copies.
        /// </summary>
        /// <param name="input">Graph node with neighbors list</param>
        /// <returns>Deep copy of input graph</returns>
        public static GraphNode DeepCopy(GraphNode input)
        {
            if (input == null) return input;

            Queue<GraphNode> q = new Queue<GraphNode>();
            Dictionary<GraphNode, GraphNode> map = new Dictionary<GraphNode, GraphNode>();

            q.Enqueue(input);
            map.Add(input, new GraphNode(input.val));

            while (q.Count > 0)
            {
                GraphNode curNode = q.Dequeue();
                foreach(var neibr in curNode.neighbors)
                {
                    if (!map.ContainsKey(neibr))
                    {
                        map.Add(neibr, new GraphNode(neibr.val));
                        q.Enqueue(neibr);
                    }

                    map[curNode].neighbors.Add(map[neibr]);
                }
            }
            // correct output 
            foreach(var node in map.Values)
            {
                foreach (var neibr in node.neighbors)
                {
                    Console.WriteLine(neibr.val);
                }
            }

            return map[input];
        }
    }
    public static class DFSClone
    {
        // BLIND: ✅ ✅ ✅
        static Dictionary<GraphNode, GraphNode> map = new Dictionary<GraphNode, GraphNode>();/*📦*/
        /// <summary>
        /// Calls dfs for global map to generate deep copy of undirected graph.
        /// </summary>
        /// <param name="input">Undirected graph node with neighbors</param>
        /// <returns>Clone of input</returns>
        public static GraphNode DeepCopy(GraphNode input)
        {
            if (input == null) return null;

            dfs(input);

            foreach (var node in map.Keys)
            {
                foreach (var neighbor in node.neighbors)
                {
                    map[node].neighbors.Add(map[neighbor]);
                }
            }

            // the correct output.
            foreach (var node in map.Keys)
            {
                foreach (var neib in node.neighbors)
                {
                    Console.WriteLine(neib.val);
                }
            }

            return map[input];
        }

        /// <summary>
        /// Creates keys in global map with empty values.
        /// </summary>
        /// <param name="input"></param>
        private static void dfs(GraphNode input)
        {
            if (input == null) return;

            map.Add(input, new GraphNode(input.val));

            foreach(var neighbor in input.neighbors)
            {
                if (!map.ContainsKey(neighbor)) dfs(neighbor);
            }
        }
    }

    public static class NumberOfIslands
    {
        public static int BFS(char[][] grid)
        {
            int numOfIslands = 0;/*🌟*/

            int[] deltaRow = { 1, -1, 0, 0 };/*🧟*/
            int[] deltaCol = { 0, 0, 1, -1 };/*🧟*/

            // 0. start iterating through rows and columns
            for (int r = 0; r < grid.Length; r++)/*👣*/
            {
                for (int c = 0; c < grid[0].Length; c++)/*👣*/
                {
                    // 1. if the row/col is an island
                    if (grid[r][c] == '1')
                    {
                        // 1. increment the number of islands!
                        numOfIslands++;

                        // 2. initialize a Q for the r,c pairs 
                        Queue<int[]> islandCoords = new Queue<int[]>();

                        // 3. enqueue the currently visited r c pair
                        islandCoords.Enqueue(new int[] { r, c });

                        // 4. change the value at that grid to mark it as visited?
                        grid[r][c] = 'X';

                        // 5. while the queue is not empty
                        while (islandCoords.Count > 0)
                        {
                            // 1. take a look at the r,c pair 
                            int[] cur = islandCoords.Dequeue();

                            // 2. loop to scan all 4 sides
                            for (int i = 0; i < 4; i++)
                            {
                                // 1. store each row and col neighbor as we iterate
                                int neibR = cur[0] + deltaRow[i];
                                int neibC = cur[1] + deltaCol[i];
                                // 2. check to make sure that we're in bounds...
                                if (neibR > -1 && neibR < grid.Length
                                 && neibC > -1 && neibC < grid[0].Length
                                 // is not water...
                                 && grid[neibR][neibC] != '0'
                                 // and has not already been visited.
                                 && grid[neibR][neibC] != 'X'
                                )
                                {
                                    // 1. queue up the thoroughly visited cell
                                    islandCoords.Enqueue(new int[] { neibR, neibC });
                                    // 2. mark this cell as visited
                                    grid[neibR][neibC] = 'X';
                                }
                            }
                        }
                    }
                }
            }


            return numOfIslands;
        }
    }
}
