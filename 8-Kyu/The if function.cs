//Create a function called _if which takes 3 arguments: a boolean value bool and 2 functions (which do not take any parameters): func1 and func2

//When bool is truth-ish, func1 should be called, otherwise call the func2.

//Example:
//Kata.If(true, () => Console.WriteLine("True"), () => Console.WriteLine("False"));
//// write "True" to console
///

using System;

public class Kata
{
    public static void If(bool condition, Action func1, Action func2)
    {
        switch (condition)
        {
            case true:
                func1();
                Console.WriteLine("True");
                break;
            case false:
                func2();
                Console.WriteLine("False");
                break;
        }
    }

}