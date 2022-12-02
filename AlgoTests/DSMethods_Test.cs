using System.Collections;
using System.Data;

namespace AlgoTests
{
    [TestClass]
    public class DSMethods_Test
    {
        [TestMethod]
        public void ArrListMethods(ArrayList arrList)
        {

        }

        [TestMethod]
        [DataRow()]
        public void CharArrMethods(char[] letters)
        {
            letters[0] = 'a';
            int characterArrayLength = letters.Length;
            
            letters.CopyTo(new string[3], 0);
            letters.CopyTo(new char[3], 0);

            int[] charToIntArr = new int[1];
            letters.CopyTo(charToIntArr, 0);

            Assert.AreEqual(charToIntArr[0], 'a');
        }

        [TestMethod]
        public void StringMethods(string letters)
        {
            
        }
    }
}
