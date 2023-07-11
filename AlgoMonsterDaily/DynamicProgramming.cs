using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonsterDaily {
		public class DynamicProgrammingClass {
				public int HouseRobber(List<int> nums){
						int rob1= 0;
						int rob2= 0;

						foreach (var num in nums){
								var temp = Math.Max(num + rob1, rob2);
								rob1 = rob2;
								rob2 = temp;
						}

						return rob2;
				}

				public int MinCostClimbingStairs(int[] cost){
						int n = cost.Length;
						int[] dp = new int[n+1];
						
						dp[0] = 0;
						dp[1] = 0;

						for (int i=2; i<=n; i++) {
								int option1 = dp[i-1] + cost[i-1];
								int option2 = dp[i-2] + cost[i-2];

								dp[i] = Math.Min(option1, option2);
						}
						
						return dp[n];
				}

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

				public int AdvancedClimingStairs(int n){
						if (n<=2 ){ return n; }

						int prev1 = 1;
						int prev2 = 2;

						int distinctWays = 0;

						for (int i=3; i<=n; i++){
								distinctWays = prev1 + prev2;

								prev1 = prev2;
								prev2 = distinctWays;
						}

						return distinctWays;
				}
		}
}
