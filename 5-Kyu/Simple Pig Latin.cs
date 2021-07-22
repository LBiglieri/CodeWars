//Move the first letter of each word to the end of it, then add "ay" to the end of the word. Leave punctuation marks untouched.

//Examples
//Kata.PigIt("Pig latin is cool"); // igPay atinlay siay oolcay
//Kata.PigIt("Hello world !");     // elloHay orldway !

using System.Collections.Generic;
using System.Linq;

public class Kata
{
    public static string PigIt(string str)
    {
        List<string> stringList = new List<string>();
        string pigWord = null;
        List<string> words = new List<string>();

        words.AddRange(str.Split());
        foreach (var word in words)
        {
            if (char.IsPunctuation(word[word.Length - 1]) && word.Length > 2)
            {
                stringList.Add(word.Substring(1, word.Length - 2) + word[0] + "ay" + word[word.Length - 1]);
                continue;
            }
            if (char.IsPunctuation(word[word.Length - 1]) && word.Length < 2)
            {
                stringList.Add(word);
                continue;
            }
            stringList.Add(word.Substring(1) + word[0] + "ay");
        }

        foreach (var word in stringList)
        {
            pigWord += word + ' ';
        }

        return pigWord.Trim();
    }
}