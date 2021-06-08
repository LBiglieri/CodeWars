//Write a function that takes in a string of one or more words, and returns the same string, but with all five or more letter words reversed (like the name of this kata).

//Strings passed in will consist of only letters and spaces.
//Spaces will be included only when more than one word is present.
//Examples:

//spinWords("Hey fellow warriors") => "Hey wollef sroirraw"
//spinWords("This is a test") => "This is a test"
//spinWords("This is another test") => "This is rehtona test"


using System;
using System.Linq;
using System.Text;


public class Kata
{
    public static string SpinWords(string sentence)
    {
        StringBuilder sbsentence = new StringBuilder();
        string[] words = sentence.Split(' ');
        for (int i = 0; i < words.Count(); i++)
        {
            if (words[i].Length >= 5)
            {
                if (i != (words.Count() - 1))
                    sbsentence.Append(new String(words[i].Reverse().ToArray()) + " ");
                else
                    sbsentence.Append(new String(words[i].Reverse().ToArray()));
            }
            else
            {
                if (i != (words.Count() - 1))
                    sbsentence.Append(words[i] + " ");
                else
                    sbsentence.Append(words[i]);
            }
        }
        return sbsentence.ToString();
    }
}