using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonsterDaily
{
    internal class Graph
    {
        public static int[,] AryFloodFill(int r, int c, int replacement, int[,] image)
        {
            int numRows = 5;
            int numCols = 5;

            aryBfs(image, new Utils.Coordinate(r, c), replacement, numRows, numCols);
            return image;
        }

        private static void aryBfs(int[,] image, Utils.Coordinate root, int replacementColor, int numRows, int numCols)
        {
            Queue<Utils.Coordinate> queue = new Queue<Utils.Coordinate>();
            queue.Enqueue(root);

            bool[,] visited = new bool[numRows, numCols];
            
            int rootColor = image[root.r,root.c];


            image[root.r,root.c] = replacementColor;

            visited[root.r, root.c] = true;

            while (queue.Count > 0)
            {
                Utils.Coordinate node = queue.Dequeue();

                List<Utils.Coordinate> neighbors = AryGetNeighbors(image, node, rootColor, numRows, numCols);

                foreach (Utils.Coordinate neighbor in neighbors)
                {

                    if (visited[neighbor.r, neighbor.c]) continue;

                    image[neighbor.r,neighbor.c] = replacementColor;

                    queue.Enqueue(neighbor);

                    visited[neighbor.r, neighbor.c] = true;

                }
            }
        }
        private static List<Utils.Coordinate> AryGetNeighbors(int[,] image, Utils.Coordinate node, int rootColor, int numRows, int numCols)
        {
            List<Utils.Coordinate> neighbors = new List<Utils.Coordinate>();

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
                        neighbors.Add(new Utils.Coordinate(neighborRow, neighborCol));
                    }
                }
            }
            return neighbors;
        }
        public static List<List<int>> floodFill(int r, int c, int replacement, List<List<int>> image)
        {
            int numRows = image.Count;
            int numCols = image[0].Count;

            bfs(image, new Utils.Coordinate(r, c), replacement, numRows, numCols);

            return image;
        }
        private static void bfs(List<List<int>> image, Utils.Coordinate root, int replacementColor, int numRows, int numCols)
        {

            Queue<Utils.Coordinate> queue = new Queue<Utils.Coordinate>();
            queue.Enqueue(root);


            bool[,] visited = new bool[numRows, numCols];


            int rootColor = image[root.r][root.c];


            image[root.r][root.c] = replacementColor;


            visited[root.r, root.c] = true;


            while (queue.Count > 0)
            {
                Utils.Coordinate node = queue.Dequeue();

                List<Utils.Coordinate> neighbors = getNeighbors(image, node, rootColor, numRows, numCols);

                foreach (Utils.Coordinate neighbor in neighbors)
                {

                    if (visited[neighbor.r, neighbor.c]) continue;

                    image[neighbor.r][neighbor.c] = replacementColor;

                    queue.Enqueue(neighbor);

                    visited[neighbor.r, neighbor.c] = true;

                }
            }
        }
        private static List<Utils.Coordinate> getNeighbors(List<List<int>> image, Utils.Coordinate node, int rootColor, int numRows, int numCols)
        {
            List<Utils.Coordinate> neighbors = new List<Utils.Coordinate>();

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
                        neighbors.Add(new Utils.Coordinate(neighborRow, neighborCol));
                    }
                }
            }
            return neighbors;
        }

    }
}
