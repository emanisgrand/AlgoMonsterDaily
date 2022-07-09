using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoMonsterDaily
{
    class Program
    {
        public static void Main()
        {
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int replacement = int.Parse(Console.ReadLine());
            int imageLength = int.Parse(Console.ReadLine());
            List<List<int>> image = new List<List<int>>();
            for (int i = 0; i < imageLength; i++)
            {
                image.Add(Utils.SplitWords(Console.ReadLine()).Select(int.Parse).ToList());
            }
            List<List<int>> res = Graph.floodFill(r, c, replacement, image);
            foreach (List<int> row in res)
            {
                Console.WriteLine(String.Join(' ', row));
            }
        }
    }
}
