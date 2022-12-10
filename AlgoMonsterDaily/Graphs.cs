using DataStructures;

namespace Graphs
{
    public static class CloneGraph
    {
        //connected undirected.  deep copy (clone) - new copy same values    
        static Dictionary<GraphNode, GraphNode> map = new Dictionary<GraphNode, GraphNode>();/*📦*/

        public static GraphNode Clone(GraphNode node)
        {
            //1. if null return null;
            if (node == null) return null;
            // run dfs node ?? 
            dfs(node);
            // foreach node in the map's keys
            foreach(var n in map.Keys)
            {
                // foreach neighbor in the node's neighbors
                foreach(var neighbor in n.neighbors)
                {
                    // at key map[node]'s neighbors, add value of map[neighbor's] key.
                    map[n].neighbors.Add(map[neighbor]);
                }
            }
            // return map[root's] value
            return map[node];
        }

        private static void dfs(GraphNode root)
        {
            // if root is null return null
            if (root == null) return;
            // little debug line.
            foreach (var n in root.neighbors)
            {
                Console.WriteLine(n.val);
            }
            // create kvp in map(root), and a new node( root's value.)
            map.Add(root, new GraphNode(root.val));
            // foreach neighbor in the root's neighbors
            foreach (var neighbor in root.neighbors)
            {
                // if the map does not have key(neighbor)
                if (!map.ContainsKey(neighbor))
                {
                    // 🔝run depth(neighbor)
                    dfs(neighbor);
                }
                    
            }
        }
    }
    public static class NumberOfIslands
    {
        public static int NumberOfIslandsBFS(char[][] grid)
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
