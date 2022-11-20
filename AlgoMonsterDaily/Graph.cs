using DataStructures;

namespace AlgoMonsterDaily
{
    internal class Graph
    {
        public static int[,] AryFloodFill(int r, int c, int replacement, int[,] image)
        {
            int numRows = 5;
            int numCols = 5;

            aryBfs(image, new Coordinate(r, c), replacement, numRows, numCols);
            return image;
        }

        private static void aryBfs(int[,] image, Coordinate root, int replacementColor, int numRows, int numCols)
        {
            Queue<Coordinate> queue = new Queue<Coordinate>();
            queue.Enqueue(root);

            bool[,] visited = new bool[numRows, numCols];
            
            int rootColor = image[root.r,root.c];


            image[root.r,root.c] = replacementColor;

            visited[root.r, root.c] = true;

            while (queue.Count > 0)
            {
                Coordinate node = queue.Dequeue();

                List<Coordinate> neighbors = AryGetNeighbors(image, node, rootColor, numRows, numCols);

                foreach (Coordinate neighbor in neighbors)
                {

                    if (visited[neighbor.r, neighbor.c]) continue;

                    image[neighbor.r,neighbor.c] = replacementColor;

                    queue.Enqueue(neighbor);

                    visited[neighbor.r, neighbor.c] = true;

                }
            }
        }
        private static List<Coordinate> AryGetNeighbors(int[,] image, Coordinate node, int rootColor, int numRows, int numCols)
        {
            List<Coordinate> neighbors = new List<Coordinate>();

            int[] deltaRow = { -1, 0, 1, 0 };
            int[] deltaCol = { 0, 1, 0, -1 };

            for (int i = 0; i < deltaRow.Length; i++)
            {

                int neighborRow = node.r + deltaRow[i];
                int neighborCol = node.c + deltaCol[i];

                if (0 <= neighborRow && neighborRow < numRows && 0 <= neighborCol && neighborCol < numCols)
                {
                    if (image[neighborRow,neighborCol] == rootColor)
                    {
                        neighbors.Add(new Coordinate(neighborRow, neighborCol));
                    }
                }
            }
            return neighbors;
        }
        public static List<List<int>> floodFill(int r, int c, int replacement, List<List<int>> image)
        {
            int numRows = image.Count;
            int numCols = image[0].Count;

            bfs(image, new Coordinate(r, c), replacement, numRows, numCols);

            return image;
        }
        private static void bfs(List<List<int>> image, Coordinate root, int replacementColor, int numRows, int numCols)
        {

            Queue<Coordinate> queue = new Queue<Coordinate>();
            queue.Enqueue(root);


            bool[,] visited = new bool[numRows, numCols];


            int rootColor = image[root.r][root.c];


            image[root.r][root.c] = replacementColor;


            visited[root.r, root.c] = true;


            while (queue.Count > 0)
            {
                Coordinate node = queue.Dequeue();

                List<Coordinate> neighbors = getNeighbors(image, node, rootColor, numRows, numCols);

                foreach (Coordinate neighbor in neighbors)
                {

                    if (visited[neighbor.r, neighbor.c]) continue;

                    image[neighbor.r][neighbor.c] = replacementColor;

                    queue.Enqueue(neighbor);

                    visited[neighbor.r, neighbor.c] = true;

                }
            }
        }
        private static List<Coordinate> getNeighbors(List<List<int>> image, Coordinate node, int rootColor, int numRows, int numCols)
        {
            List<Coordinate> neighbors = new List<Coordinate>();

            int[] deltaRow = { -1, 0, 1, 0 };
            int[] deltaCol = { 0, 1, 0, -1 };

            for (int i = 0; i < deltaRow.Length; i++)
            {

                int neighborRow = node.r + deltaRow[i];
                int neighborCol = node.c + deltaCol[i];

                if (0 <= neighborRow && neighborRow < numRows && 0 <= neighborCol && neighborCol < numCols)
                {
                    if (image[neighborRow][neighborCol] == rootColor)
                    {
                        neighbors.Add(new Coordinate(neighborRow, neighborCol));
                    }
                }
            }
            return neighbors;
        }

    }
}
