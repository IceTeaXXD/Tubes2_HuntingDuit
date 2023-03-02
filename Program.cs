using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Read the text file
        string[] lines = File.ReadAllLines("test/maze1.txt");

        // Create a 2D matrix to store the data
        char[,] matrix = new char[lines.Length, lines[0].Split(' ').Length];

        // Fill the matrix with data from the text file
        for (int i = 0; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(' ');
            for (int j = 0; j < values.Length; j++)
            {
                matrix[i, j] = values[j][0];
            }
        }

        // Print the matrix to the console
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}