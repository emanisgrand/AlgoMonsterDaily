using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoMonsterDaily {
		public enum Optimization { Runtime =0, Memory =1}

		public class DynamicProgrammingClass {
				public int AdvRobber(List<int> nums){
						int n = nums.Count;
						if (n== 0){ 
								return 0;
						} else if (n==1) { 
								return nums[0];
						}
						
						return Math.Max(nums[0], Math.Max(
								HouseRobber(nums, 0, n-1), 
								HouseRobber(nums, 0, n)		
						));
				}

				public int HouseRobber(List<int> nums, int start, int end, Optimization optmz = Optimization.Runtime){
						
						int n = nums.Count;

						switch (optmz){

							case Optimization.Runtime:
								int rob1 = 0, rob2 = 0;

								for(int i=start; i< end; i++){
										int temp = Math.Max(nums[i] + rob1, rob2);
										rob1 = rob2;
										rob2 = temp;
								}

								return rob2;

							case Optimization.Memory:				
								if (n>1){
										var max0 = nums[0];
										var max1 = Math.Max(max0, nums[1]);

										for (var i=2; i<n; i++){
												var temp = Math.Max(max1, max0+nums[i]);
												max0 = max1;
												max1 = temp;
										}
										return max1;
								}else if (n==1){
										return nums[0];
								} else {
										return 0;
								}				
						}
						return 0;
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
