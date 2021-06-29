//I bet you won't ever catch a Lift (a.k.a. elevator) again without thinking of this Kata !

//Synopsis
//A multi-floor building has a Lift in it.

//People are queued on different floors waiting for the Lift.

//Some people want to go up. Some people want to go down.

//The floor they want to go to is represented by a number (i.e. when they enter the Lift this is the button they will press)

//Rules

//Lift Rules
//The Lift only goes up or down!
//Each floor has both UP and DOWN Lift-call buttons (except top and ground floors which have only DOWN and UP respectively)
//The Lift never changes direction until there are no more people wanting to get on/off in the direction it is already travelling
//When empty the Lift tries to be smart. For example,
//If it was going up then it may continue up to collect the highest floor person wanting to go down
//If it was going down then it may continue down to collect the lowest floor person wanting to go up
//The Lift has a maximum capacity of people
//When called, the Lift will stop at a floor even if it is full, although unless somebody gets off nobody else can get on!
//If the lift is empty, and no people are waiting, then it will return to the ground floor

//People Rules
//People are in "queues" that represent their order of arrival to wait for the Lift
//All people can press the UP/DOWN Lift-call buttons
//Only people going the same direction as the Lift may enter it
//Entry is according to the "queue" order, but those unable to enter do not block those behind them that can
//The year is 1214. One night, Pope Innocent III awakens to find the the archangel Gabriel floating before him. Gabriel thunders to the pope:

//Gather all of the learned men in Pisa, especially Leonardo Fibonacci. In order for the crusades in the holy lands to be successful, these men must calculate the millionth number in Fibonacci's recurrence. Fail to do this, and your armies will never reclaim the holy land. It is His will.

//The angel then vanishes in an explosion of white light.

//Pope Innocent III sits in his bed in awe. How much is a million? he thinks to himself. He never was very good at math.

//He tries writing the number down, but because everyone in Europe is still using Roman numerals at this moment in history, he cannot represent this number.If he only knew about the invention of zero, it might make this sort of thing easier.

//He decides to go back to bed.He consoles himself, The Lord would never challenge me thus; this must have been some deceit by the devil. A pretty horrendous nightmare, to be sure.

//Pope Innocent III's armies would go on to conquer Constantinople (now Istanbul), but they would never reclaim the holy land as he desired.

//In this kata you will have to calculate fib(n) where:

//fib(0) := 0
//fib(1) := 1
//fin(n + 2) := fib(n + 1) + fib(n)
//Write an algorithm that can handle n up to 2000000.

//Your algorithm must output the exact integer answer, to full precision. Also, it must correctly handle negative numbers as input.

//HINT I: Can you rearrange the equation fib(n + 2) = fib(n + 1) + fib(n) to find fib(n) if you already know fib(n + 1) and fib(n + 2)? Use this to reason what value fib has to have for negative values.

//HINT II: See https://mitpress.mit.edu/sites/default/files/sicp/full-text/book/book-Z-H-11.html#%_sec_1.2.4


using System;
using System.Numerics;

public class Fibonacci
{
    public static BigInteger fib(int n)
    {
        if (n == 0) return BigInteger.Zero;

        var mat = new BigInteger[,]
        {
               { 1, 1 },
               { 1, 0 }
        };
        var result = power(mat, Math.Abs(n) - 1);
        var fn = result[0, 0];
        if (n < 0 && n % 2 == 0)
            fn = -fn;
        return fn;
    }

    private static BigInteger[,] power(BigInteger[,] m, int n)
    {
        //Valor inicial de m
        BigInteger[,] mat = {
                { 1, 1 },
                { 1, 0 }
            };

        if (n == 1 || n == 0) return mat;

        power(m, n / 2);

        BigInteger[,] temp = {
                {m[0,0],m[0,1]},
                {m[1,0],m[1,1]}
            };

        // m = m*m
        m[0, 0] = temp[0, 0] * temp[0, 0] + temp[0, 1] * temp[1, 0];
        m[0, 1] = temp[0, 0] * temp[0, 1] + temp[0, 1] * temp[1, 1];
        m[1, 0] = temp[1, 0] * temp[0, 0] + temp[1, 1] * temp[1, 0];
        m[1, 1] = temp[1, 0] * temp[0, 1] + temp[1, 1] * temp[1, 1];

        if (n % 2 == 1)
        {
            BigInteger[,] temp2 = {
                    {m[0,0],m[0,1]},
                    {m[1,0],m[1,1]}
                };

            //m = m*
            m[0, 0] = temp2[0, 0] * mat[0, 0] + temp2[0, 1] * mat[1, 0];
            m[0, 1] = temp2[0, 0] * mat[0, 1] + temp2[0, 1] * mat[1, 1];
            m[1, 0] = temp2[1, 0] * mat[0, 0] + temp2[1, 1] * mat[1, 0];
            m[1, 1] = temp2[1, 0] * mat[0, 1] + temp2[1, 1] * mat[1, 1];
        }

        return m;
    }
}