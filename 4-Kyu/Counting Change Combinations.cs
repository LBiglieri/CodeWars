//Write a function that counts how many different ways you can make change for an amount of money, given an array of coin denominations.
//For example, there are 3 ways to give change for 4 if you have coins with denomination 1 and 2:

//1 + 1 + 1 + 1, 1 + 1 + 2, 2 + 2.
//The order of coins does not matter:

//1 + 1 + 2 == 2 + 1 + 1
//Also, assume that you have an infinite amount of coins.

//Your function should take an amount to change and an array of unique denominations for the coins:

//  CountCombinations(4, new[] { 1, 2 }) // => 3
//  CountCombinations(10, new[] { 5, 2, 3 }) // => 4
//  CountCombinations(11, new[] { 5, 7 }) //  => 0

using System;
public static class Kata
{
    public static int CountCombinations(int money, int[] coins)
    {
        return GetCombinations(money, coins, 0);
    }

    public static int GetCombinations(int money, int[] coins, int index)
    {
        if (money == 0) return 1;
        if (money < 0 || coins.Length == index) return 0;

        int withFirstCoin = GetCombinations(money - coins[index], coins, index);
        int withoutFirstCoin = GetCombinations(money, coins, index + 1);

        return withFirstCoin + withoutFirstCoin;
    }
}