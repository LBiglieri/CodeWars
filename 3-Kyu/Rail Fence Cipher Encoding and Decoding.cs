//Create two functions to encode and then decode a string using the Rail Fence Cipher.This cipher is used to encode a string by placing each character successively in a diagonal along a set of "rails". First start off moving diagonally and down.When you reach the bottom, reverse direction and move diagonally and up until you reach the top rail.Continue until you reach the end of the string. Each "rail" is then read left to right to derive the encoded string.

//For example, the string "WEAREDISCOVEREDFLEEATONCE" could be represented in a three rail system as follows:

//W E       C R       L T       E
//  E   R D   S O   E E   F E   A O   C
//    A       I V       D E       N
//The encoded string would be:

//WECRLTEERDSOEEFEAOCAIVDEN
//Write a function/method that takes 2 arguments, a string and the number of rails, and returns the ENCODED string.

//Write a second function/method that takes 2 arguments, an encoded string and the number of rails, and returns the DECODED string.

//For both encoding and decoding, assume number of rails >= 2 and that passing an empty string will return an empty string.

//Note that the example above excludes the punctuation and spaces just for simplicity.There are, however, tests that include punctuation. Don't filter out punctuation as they are a part of the string.

public class RailFenceCipher
{
    public static string Encode(string s, int n)
    {
        var strArray = new string[n];
        var flag = 0;
        var option = true;
        foreach (var c in s)
        {
            strArray[flag] += c;
            if (option)
            {
                flag++;
                if (flag == n - 1) option = false;
            }
            else
            {
                flag--;
                if (flag == 0) option = true;
            }
        }
        return string.Join("", strArray);
    }

    public static string Decode(string s, int n)
    {
        var charArray = new char[s.Length];
        var index = 0;
        var line = 1;
        var option = true;
        foreach (var c in s)
        {
            charArray[index] = c;
            if (option)
            {
                index += (n - line) * 2;
            }
            else
            {
                index += (line - 1) * 2;
            }

            if (line != 1 && line != n) option = !option;
            if (index < s.Length) continue;
            index = line;
            line++;
            option = line != n;
        }

        return string.Join("", charArray);
    }
}
