//Write a function that accepts a square matrix (N x N 2D array) and returns the determinant of the matrix.

//How to take the determinant of a matrix -- it is simplest to start with the smallest cases:

//A 1x1 matrix |a| has determinant a.

//A 2x2 matrix [ [a, b], [c, d] ] or

//| a  b |
//| c  d |
//has determinant: a* d -b * c.

//The determinant of an n x n sized matrix is calculated by reducing the problem to the calculation of the determinants of n matrices ofn-1 x n-1 size.

//For the 3x3 case, [[a, b, c], [d, e, f], [g, h, i] ] or

//| a b c|  
//|d e f|  
//|g h i|  
//the determinant is: a* det(a_minor) -b * det(b_minor) + c * det(c_minor) where det(a_minor) refers to taking the determinant of the 2x2 matrix created by crossing out the row and column in which the element a occurs:

//| - - -|
//| -e f |
//| -h i |
//Note the alternation of signs.

//The determinant of larger matrices are calculated analogously, e.g. if M is a 4x4 matrix with first row [a, b, c, d], then:

//det(M) = a * det(a_minor) - b * det(b_minor) + c * det(c_minor) - d * det(d_minor)

using System.Collections.Generic;

public class Matrix
{
    public static int Determinant(int[][] matrix)
    {
        if (matrix.Length == 1)
        {
            return matrix[0][0];
        }

        var determinant = 0;
        var sign = 1;

        for (var i = 0; i < matrix.Length; i++)
        {
            determinant += sign * matrix[0][i] * Determinant(SubMatrix(i, matrix));
            sign *= -1;
        }
        return determinant;
    }

    private static int[][] SubMatrix(int columnToRemove, IReadOnlyList<int[]> matrix)
    {
        var subMatrix = new int[matrix.Count - 1][];
        for (var row = 1; row < matrix.Count; row++)
        {
            subMatrix[row - 1] = new int[matrix.Count - 1];
            for (var column = 0; column < columnToRemove; column++)
            {
                subMatrix[row - 1][column] = matrix[row][column];
            }
            for (var column = columnToRemove + 1; column < matrix.Count; column++)
            {
                subMatrix[row - 1][column - 1] = matrix[row][column];
            }
        }
        return subMatrix;
    }
}