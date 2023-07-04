using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonsterDaily {
		public class DynamicProgrammingClass {
				public int ClimbingStairs(int n){
						if (n <=2 ){
								return n;
						}

						int[] distinctWays = new int [n+1];

						distinctWays[1] = 1;
						distinctWays[2] = 2;

						for (int i=3; i<=n; i++){
								distinctWays[i] = distinctWays[i-1] + distinctWays[i-2];
						}

						return distinctWays[n];
				}
		}
}
