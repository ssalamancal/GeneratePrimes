﻿/// <remark>
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
        private static bool[] isCrossed;
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
            isCrossed = new bool[maxValue + 1];
            for (var i = 2; i < isCrossed.Length; i++)
                isCrossed[i] = false;
        }

        private static void CrossOutMultiples()
        {
            var maxPrimeFactor = CalcMaxPrimeFactor();
            for (var i = 2; i < maxPrimeFactor + 1; i++)
            {
                if (NotCrossed(i))
                    CrossOutputMultipleOf(i);
            }
        }

        private static double CalcMaxPrimeFactor()
        {
            // We cross out all multiples of p, where p is prime.
            // Thus, all crossed out multiples have p and q for
            // factors. If p > sqrt of the size of the array, then
            // q will never be greater than 1. Thus p is the
            // largest prime factor in the array and is also
            // the iteration limit.

            double maxPrimeFactor = Math.Sqrt(isCrossed.Length) + 1;
            return (int)maxPrimeFactor;
        }

        private static bool NotCrossed(int i)
        {
            return isCrossed[i] == false;
        }

        private static void CrossOutputMultipleOf(int i)
        {
            for (var multiple = 2 * i; multiple < isCrossed.Length; multiple += i)
                isCrossed[multiple] = true; 
        }

        private static void PutUncrossedIntegersIntoResult()
        {
            result = new int [NumberOfUncrossedIntegers()];

           for (int j = 0, i = 2; i < isCrossed.Length; i++)
            {
                if (NotCrossed(i))
                    result[j++] = i;
            }
        }

        private static int NumberOfUncrossedIntegers()
        {
            int count = 0;
            for (int i = 2; i < isCrossed.Length; i++)
            {
                if (NotCrossed(i))
                    count++; // bump count.
            }
            return count;
        }
    }
}
