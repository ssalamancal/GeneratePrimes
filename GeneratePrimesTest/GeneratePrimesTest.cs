using System;
using Xunit;
using GeneratePrimesRefactoring;

namespace GeneratePrimesTest
{
    public class GeneratePrimesTest
    {
        [Fact]
        public void TestPrimes()
        {
            int[] nullArray = GeneratePrimes.GeneratePrimeNumbers(0);
            Assert.Equal(nullArray.Length, 0);
            int[] minArray = GeneratePrimes.GeneratePrimeNumbers(2);
            Assert.Equal(minArray.Length, 1);
            Assert.Equal(minArray[0], 2);
            int[] threeArray = GeneratePrimes.GeneratePrimeNumbers(3);
            Assert.Equal(threeArray.Length, 2);
            Assert.Equal(threeArray[0], 2);
            Assert.Equal(threeArray[1], 3);
            int[] centArray = GeneratePrimes.GeneratePrimeNumbers(100);
            Assert.Equal(centArray.Length, 25);
            Assert.Equal(centArray[24], 97);
        }
    }
}