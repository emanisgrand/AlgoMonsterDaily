namespace AlgoTests
{
    [TestClass]
    public class TwoPointers_Test
    {
        [TestMethod]
        public void MoveZeroesInPlace()
        {
            List<int> input = new List<int>() { 1, 0, 2, 0, 0, 7 };
            List<int> expected = new List<int>() { 1, 2, 7, 0, 0, 0 };
            int slow = 0;
            for (int fast =0; fast < input.Count; fast++)
            {
                if (input[fast] != 0)
                {
                    int temp = input[fast];
                    input[fast] = 0;
                    input[slow] = temp;
                    slow++;
                }
            }
            CollectionAssert.AreEqual(input, expected);
        }
    }

    
}
