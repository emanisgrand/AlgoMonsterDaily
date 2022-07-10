using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoMonsterDaily
{
    class Program
    {
        public void PrintPreImage(int[,] preImage)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write("{0} ", preImage[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static void Main()
        {
            Program pr = new Program();
            int[,] preImage = { {0, 1, 3, 4, 1 },
                            {3, 8, 8, 3, 3 },
                            {6, 7, 8, 8, 3 },
                            {12, 2, 8, 9, 1 },
                            {12, 3, 1, 3, 2 },
            };
            pr.PrintPreImage(preImage);
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int replacement = int.Parse(Console.ReadLine());
            //int imageLength = int.Parse(Console.ReadLine());
            //List<List<int>> image = new List<List<int>>();
            
            int[,] res = Graph.AryFloodFill(r, c, replacement, preImage);
            pr.PrintPreImage(preImage);
        }
    }
}
