//I will give you an integer. Give me back a shape that is as long and wide as the integer. The integer will be a whole number between 1 and 50.

//Example
//n = 3, so I expect a 3x3 square back just like below as a string:

//+++
//+++
//+++

using System;

public static class Kata
{
    public static string GenerateShape(int n)
    {
        string pattern = "";
        for (int row = 0; row < n; row++)
        {
            string temp = new String('+', n);
            if (row < n - 1)
                pattern += temp + "\n";
            else
                pattern += temp;
        }
        return pattern;
    }
}