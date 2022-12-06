namespace Graphs
{
    public static class MediumGraphs
    {
        public static int NumberOfIslandsBFS(char[][] grid)
        {
            int numOfIslands = 0; /*🌟*/

            int[] deltaRow = { 1, -1, 0, 0 }; /*🧟*/
            int[] deltaCol = { 0, 0, 1, -1 }; /*🧟*/

            // 0. start iterating through rows and columns
            for (int row=0; row< grid.Length; row++)  /*👣*/
            {
                for (int col =0; col < grid[0].Length; col++) /*👣*/
                {
                    // 1. if the row/col is an island
                    if (grid[row][col] == '1')
                    {
                        // 1. increment the number of islands!
                        numOfIslands++;

                        // 2. initialize a Q for the r,c pairs 
                        Queue<int[]> queue = new Queue<int[]>();
                        
                        // 3. enqueue the currently visited r c pair
                        queue.Enqueue(new int[] {row, col });

                        // 4. change the value at that grid to mark it as visited?
                        grid[row][col] = 'N';

                        // 5. while the queue is not empty
                        while (queue.Count > 0)
                        {
                            // 1. take a look at the r,c pair 
                            int[] rc = queue.Dequeue();

                            // 2. loop to scan all 4 sides
                            for (int i=0; i<4; i++)
                            {
                                // 1. store each row and col neighbor
                                int newRow = rc[0] + deltaRow[i],
                                    newCol = rc[1] + deltaCol[i];

                                // 2. check to make sure that we're in bounds...
                                if (
                                    newRow > -1 && newRow < grid.Length 
                                    && newCol > -1 && newCol < grid[0].Length
                                    // is not water...
                                    && grid[newRow][newCol] != '0'
                                    // and has not already been visited.
                                    && grid[newRow][newCol] != 'N' 
                                    )
                                {
                                    // 1. queue up the thoroughly visited cell
                                    queue.Enqueue(new int[] { newRow, newCol });
                                    // 2. mark this cell as visited
                                    grid[newRow][newCol] = 'N';
                                }
                            }
                        }
                    }
                }
            }


            return numOfIslands;
        }
    }

    public static class AdvancedGraphs
    {

    }
}
