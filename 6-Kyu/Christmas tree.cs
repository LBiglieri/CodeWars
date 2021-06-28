//Create a function that returns a christmas tree of the correct height.

//For example:

//hieght = 5 should return:

//    *
//   ***
//  *****
// *******
//*********
//Height passed is always an integer between 0 and 100.

//Use \n for newlines between each line.

//Pad with spaces so each line is the same length. The last line having only stars, no spaces.

using System;
using System.Text;
public class ChristmasTreeGenerator
{
    public static string ChristmasTree(int height)
    {
        if (height == 0)
            return string.Empty;

        var builder = new StringBuilder(2 * height * height);

        for (int spaces = height - 1, asterisks = 1; spaces >= 0; --spaces, asterisks += 2)
        {
            builder
                .Append(' ', spaces)
                .Append('*', asterisks)
                .Append(' ', spaces)
                .Append('\n');
        }
        return builder.ToString(0, builder.Length - 1);
    }
}