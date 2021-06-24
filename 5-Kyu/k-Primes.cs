//A natural number is called k-prime if it has exactly k prime factors, counted with multiplicity. For example:

//k = 2-- > 4, 6, 9, 10, 14, 15, 21, 22, ...
//k = 3-- > 8, 12, 18, 20, 27, 28, 30, ...
//k = 5-- > 32, 48, 72, 80, 108, 112, ...
//A natural number is thus prime if and only if it is 1-prime.

//Task:
//Complete the function count_Kprimes (or countKprimes, count-K-primes, kPrimes) which is given parameters k, start, end(or nd) and returns an array (or a list or a string depending on the language - see "Solution" and "Sample Tests") of the k-primes between start (inclusive) and end(inclusive).

//Example:
//countKprimes(5, 500, 600)-- > [500, 520, 552, 567, 588, 592, 594]
//Notes:

//The first function would have been better named: findKprimes or kPrimes :-)
//In C some helper functions are given (see declarations in 'Solution').
//For Go: nil slice is expected when there are no k-primes between start and end.
//Second Task: puzzle(not for Shell)
//    Given a positive integer s, find the total number of solutions of the equation a + b + c = s, where a is 1-prime, b is 3-prime, and c is 7-prime.

//Call this function puzzle(s).

//Examples:
//puzzle(138)-- > 1  because[2 + 8 + 128] is the only solution
//puzzle(143)  --> 2  because[3 + 12 + 128] and[7 + 8 + 128] are the solutions

using System;
using System.Collections.Generic;

public class KPrimes
{
    private static Dictionary<long, int> dicCountPrimos = new Dictionary<long, int>() { { 2, 1 }, { 3, 1 } };

    public static long[] CountKprimes(int k, long inicio, long final)
    {
        List<long> listaPrimos = new List<long>();
        for (long i = inicio; i <= final; i++)
        {
            if (primosCount(i) == k)
                listaPrimos.Add(i);
        }

        return listaPrimos.ToArray();
    }
    public static int Puzzle(int s)
    {
        int resultado = 0;

        long[] primos1 = CountKprimes(1, 2, s);
        long[] primos3 = CountKprimes(3, 2, s);
        long[] primos7 = CountKprimes(7, 2, s);

        foreach (long primo1 in primos1)
            foreach (long primo3 in primos3)
                foreach (long primo7 in primos7)
                {
                    if (primo1 + primo3 + primo7 == s)
                        resultado++;
                }

        return resultado;
    }

    private static int primosCount(long value)
    {
        if (value <= 1) return 0;
        if (dicCountPrimos.ContainsKey(value)) return dicCountPrimos[value];

        int resultado = 0;
        for (long i = 2; i <= Math.Sqrt(value); i++)
        {
            if (value % i == 0)
            {
                resultado = primosCount(i) + primosCount(value / i);
                dicCountPrimos.Add(value, resultado);
                return resultado;
            }
        }

        dicCountPrimos.Add(value, 1);
        return 1;
    }
}