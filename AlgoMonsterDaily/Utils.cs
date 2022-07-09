using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonsterDaily
{
    internal class Utils
    {
        public struct Coordinate
        {
            public int r;
            public int c;

            public Coordinate(int r, int c)
            {
                this.r = r;
                this.c = c;
            }
        }

        public static int Mod(int x, int y)
        {
            while (x >= y)
            {
                x -= y;
            }
            return x;
        }

        public static List<string> SplitWords(string s)
        {
            return string.IsNullOrEmpty(s) ? new List<string>() : s.Trim().Split(' ').ToList();
        }
    }
}
