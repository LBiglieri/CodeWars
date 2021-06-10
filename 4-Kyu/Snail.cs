//Snail Sort
//Given an n x n array, return the array elements arranged from outermost elements to the middle element, traveling clockwise.

//array = [[1,2,3],
//         [4,5,6],
//         [7,8,9]]
//snail(array) #=> [1,2,3,6,9,8,7,4,5]

//array = [[1, 2, 3],
//         [8,9,4],
//         [7,6,5]]
//snail(array) #=> [1,2,3,4,5,6,7,8,9]
//This image will illustrate things more clearly:


//NOTE: The idea is not sort the elements from the lowest value to the highest; the idea is to traverse the 2-d array in a clockwise snailshell pattern.

//NOTE 2: The 0x0(empty matrix) is represented as en empty array inside an array [[]].

using System;
using System.Collections.Generic;

public class SnailSolution
{
    public static int[] Snail(int[][] array)
    {
        if (array.Length == 0 || array[0].Length == 0)
        {
            return Array.Empty<int>();
        }
        var result = new List<int>();
        var init = 0;
        var arrayLength = array.Length - 1;

        while (init <= arrayLength)
        {
            // Recorremos fila superior
            for (var i = init; i < arrayLength; i++)
            {
                result.Add(array[init][i]);
            }
            // Recorremos la última columna
            for (var i = init; i < arrayLength; i++)
            {
                result.Add(array[i][arrayLength]);
            }
            // Recorremos la última fila
            for (var i = arrayLength; i >= init; i--)
            {
                result.Add(array[arrayLength][i]);
            }
            // Recorremos la columna izquierda (sin primera y última celda)
            for (var i = arrayLength - 1; i > init; i--)
            {
                result.Add(array[i][init]);
            }

            // Tomamos el siguiente anillo
            ++init;
            --arrayLength;
        }
        return result.ToArray();
    }
}