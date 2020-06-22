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
            int[] nullArray = PrimeGenerator.GeneratePrimeNumbers(0);
            Assert.Equal(nullArray.Length, 0);

            int[] minArray = PrimeGenerator.GeneratePrimeNumbers(2);
            Assert.Equal(minArray.Length, 1);
            Assert.Equal(minArray[0], 2);

            int[] threeArray = PrimeGenerator.GeneratePrimeNumbers(3);
            Assert.Equal(threeArray.Length, 2);
            Assert.Equal(threeArray[0], 2);
            Assert.Equal(threeArray[1], 3);

            int[] centArray = PrimeGenerator.GeneratePrimeNumbers(100);
            Assert.Equal(centArray.Length, 25);
            Assert.Equal(centArray[24], 97);
        }

        [Fact]
        public void TestExhaustive()
        {
            for (int i = 2; i < 500; i++)
                VerifyPrimeList(PrimeGenerator.GeneratePrimeNumbers(i));
        }

        private void VerifyPrimeList(int[] list)
        {
            for (int i = 0; i < list.Length; i++)
                VerifyPrime(list[i]);
        }

        private void VerifyPrime(int n)
        {
            for (int factor = 2; factor < n; factor++)
                Assert.True(n % factor != 0);
        }

    }
}
