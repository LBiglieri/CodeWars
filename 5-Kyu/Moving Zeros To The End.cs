//Write an algorithm that takes an array and moves all of the zeros to the end, preserving the order of the other elements.

//Kata.MoveZeroes(new int[] { 1, 2, 0, 1, 0, 1, 0, 3, 0, 1 }) => new int[] { 1, 2, 1, 1, 3, 1, 0, 0, 0, 0 }

using System;
using System.Collections.Generic;
public class Kata
{
    public static int[] MoveZeroes(int[] numbers)
    {
        List<int> movednumbers = new List<int>();
        int zeros = 0;
        foreach (int i in numbers)
        {
            if (i != 0)
                movednumbers.Add(i);
            else
                zeros++;
        }
        for (int i = 0; i < zeros; i++)
        {
            movednumbers.Add(0);
        }

        return movednumbers.ToArray();
    }
}