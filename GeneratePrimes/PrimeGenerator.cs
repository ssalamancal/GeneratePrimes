///<remark>
/// This class Generates prime numbers up to a user specified
/// maximum. The algorithm used is the Sieve of Eratosthenes.
/// Given an array of integers starting at 2:
/// Find the first uncrossed integer, and cross out all its
/// multiples. Repeat until there are no more multiples
/// in the array.
///</remark>
using System;

namespace GeneratePrimesRefactoring
{
    /// <summary>
    /// author: Robert C. Martin
    /// </summary>
    public class PrimeGenerator
    {
        private static bool[] crossedOut;
        private static int[] result;

        ///<summary>
        /// Generates an array of prime numbers.
        ///</summary>
        ///
        /// <param name="maxValue">The generation limit.</param>
        public static int[] GeneratePrimeNumbers(int maxValue)
        {
            if (maxValue < 2) return new int[0];

            UncrossIntegersUpTo(maxValue);
            CrossOutMultiples();
            PutUncrossedIntegersIntoResult();

            return result;
        }

        private static void UncrossIntegersUpTo(int maxValue)
        {
            crossedOut = new bool[maxValue + 1];
            for (var i = 2; i < crossedOut.Length; i++)
                crossedOut[i] = false;
        }

        private static void CrossOutMultiples()
        {
            var limit = DetermineIterationLimit();
            for (var i = 2; i <= limit; i++)
            {
                if (NotCrossed(i))
                    CrossOutputMultipleOf(i);
            }
        }

        private static double DetermineIterationLimit()
        {
            // Every multiple in the array has a prime factor that
            // is less than or equal to the root of the array size,
            // so we don't have to cross off multiples of numbers
            // larger than that root.
            double iterationLimit = Math.Sqrt(crossedOut.Length);
            return (int)iterationLimit;
        }

        private static void CrossOutputMultipleOf(int i)
        {
            for (var multiple = 2 * i; multiple < crossedOut.Length; multiple += i)
                crossedOut[multiple] = true;
        }

        private static void PutUncrossedIntegersIntoResult()
        {
            result = new int[NumberOfUncrossedIntegers()];

            for (int j = 0, i = 2; i < crossedOut.Length; i++)
            {
                if (NotCrossed(i))
                    result[j++] = i;
            }
        }

        private static int NumberOfUncrossedIntegers()
        {
            int count = 0;
            for (int i = 2; i < crossedOut.Length; i++)
            {
                if (NotCrossed(i))
                    count++; // bump count.
            }
            return count;
        }
        private static bool NotCrossed(int i)
        {
            return crossedOut[i] == false;
        }
    }
}
