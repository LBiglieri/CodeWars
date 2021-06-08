//Complete the solution so that the function will break up camel casing, using a space between words.

//Example
//"camelCasing"  =>  "camel Casing"
//"identifier"   =>  "identifier"
//""             =>  ""

using System.Text;
public class Kata
{
    public static string BreakCamelCase(string str)
    {
        if (string.IsNullOrEmpty(str))
            return str;

        StringBuilder sb = new StringBuilder();

        foreach (var c in str)
        {
            if (char.IsUpper(c))
                sb.Append(' ');

            sb.Append(c);
        }

        return sb.ToString();
    }
}