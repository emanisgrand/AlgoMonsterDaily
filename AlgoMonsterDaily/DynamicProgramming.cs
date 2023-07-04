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

		// NO TEST
		public int Tribonacci(int n){
			if (n == 0) return 0;
			if (n<=2) return 1;

			int t0 = 0;
			int t1 = 1;
			int t2 = 1;

			int solution = t0 + t1 + t2;
			
			for (int i=3; i<=n; i++){
				t0=t1;
				t1=t2;
				t2 = solution;
			}

			return solution;
		}
	}
}
