/// <remark>
/// This class Generates prime numbers up to a user specified
/// maximum. The algorithm used is the Sieve of Eratosthenes.
///
/// Eratosthenes of Cyrene, b. c. 276 BC, Cyrene, Libya --
/// d. c. 194, Alexandria. The first man to calculate the
/// circumference of the Earth. Also known for working on
/// calendars with leap years and ran the library at
/// Alexandria.
///
/// The algorithm is quite simple. Given an array of integers
/// starting at 2. Cross out all multiples of 2. Find the
/// next uncrossed integer, and cross out all of its multiples.
/// Repeat until you have passed the square root of the
/// maximum value.
///
/// Written by Robert C. Martin on 9 Dec 1999 in Java
/// Translated to C# by Micah Martin on 12 Jan 2005.
///</remark>

using System;

namespace GeneratePrimesRefactoring
{
    /// <summary>
    /// author: Robert C. Martin
    /// </summary>
    public class PrimeGenerator
    {
        private static bool[] f;
        private static int[] result;

        ///<summary>
        /// Generates an array of prime numbers.
        ///</summary>
        ///
        /// <param name="maxValue">The generation limit.</param>
        public static int[] GeneratePrimeNumbers(int maxValue)
        {
            if (maxValue < 2) return new int[0];

            InitializeArrayOfIntegers(maxValue);
            CrossOutMultiples();
            PutUncrossedIntegersIntoResult();

            return result;
        }

        private static void InitializeArrayOfIntegers(int maxValue)
        {
            // declarations
            f = new bool[maxValue + 1];
            f[0] = f[1] = false; //neither primes nor multiples
            for (int i = 0; i < f.Length; i++)
                f[i] = true;
        }

        private static void CrossOutMultiples()
        {
            int i;
            int j;
            for (i = 2; i < Math.Sqrt(f.Length) + 1; i++)
            {
                if (f[i]) // if i is uncrossed, cross its multiples.
                {
                    for (j = 2 * i; j < f.Length; j += i)
                        f[j] = false; // multiple is not prime
                }
            }
        }

        private static int[] PutUncrossedIntegersIntoResult()
        {
            int i;
            int j;

            // how many primes are there?
            int count = 0;
            for (i = 0; i < f.Length; i++)
            {
                if (f[i])
                    count++; // bump count.
            }

            result = new int[count];
            // move the primes into the result
            for (i = 0, j = 0; i < f.Length; i++)
            {
                if (f[i]) // if prime
                    result[j++] = i;
            }

            return result; // return the primes
        }
    }
}
