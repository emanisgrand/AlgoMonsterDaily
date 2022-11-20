using System.Data;

namespace AlgoTests
{
    [TestClass]
    public class LeetCodeTests
    {
        [TestMethod]
        [DataRow(2.0000, 10, 1024)]
        [DataRow(2.1000, 3, 9.261000000000001)]
        [DataRow(2.0000, -2, 0.25)]
        public void Recursive_FastPower_XToThePowerOfN(double x, int n, double expected)
        {
            if (n < 0)
            {
                n = -n;
                x = 1 / x;
            }

            var ans = FastPower(x, n);
            Assert.AreEqual(ans, expected);
        }

        private double FastPower(double x, int n)
        {
            if (n==0)
            {
                return 1.0;
            }

            var half = FastPower(x, n/2);
            if (n % 2 == 0)
            {
                return half * half;
            }   else
            {
                return half * half * x;
            }
            
        }


        [TestMethod]
        [DataRow(2.0000, 10, 1024)]
        [DataRow(2.1000, 3, 9.261000000000001)]
        [DataRow(2.0000, -2, 0.25)]
        public void BruteForce_XToThePowerOfN(double x, int n, double expected)
        {
            if (n < 0)
            {
                x = 1 / x;
                n = -n;
            }
            // accumulator
            double ans = 1;
            
            for (int i =0; i<n; i++)
                ans = ans * x;

            Assert.AreEqual(expected, ans);
        }
    }
}
