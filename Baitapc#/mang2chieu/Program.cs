using System;

public class Program
{
    public static void Main(string[] args)
    {
        int[,] matrix = new int[4, 3]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 },
            { 10, 11, 12 }
        };

        // Print matrix (corrected indices)
        for (var j = 0; j < matrix.GetLength(0); j++) // rows
        {
            for (var i = 0; i < matrix.GetLength(1); i++) // columns
            {
                Console.Write(matrix[j, i] + " "); // Corrected: matrix[j, i]
            }
            Console.WriteLine();
        }

        Console.WriteLine("Hello, World!");

        // Sum of all elements
        int sum = 0;
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                sum += matrix[i, j];
            }
        }
        Console.WriteLine("Sum of all elements: " + sum);

        // Sum of diagonal elements (only valid for i == j up to min(rows, columns))
        int sum2 = 0;
        int minDimension = Math.Min(matrix.GetLength(0), matrix.GetLength(1));
        for (var i = 0; i < minDimension; i++)
        {
            sum2 += matrix[i, i]; // Diagonal where i == j
        }
        Console.WriteLine("Sum of diagonal elements: " + sum2);
        int max = matrix[0, 0];
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                }
            }
        }
        Console.WriteLine("Maximum element: " + max);
    }
}