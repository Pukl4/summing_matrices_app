using System;
using System.Collections.Generic;
namespace SummingMatricesApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixRowCount = GetMatrixParameter("rows");
            int matrixColumnCount = GetMatrixParameter("columns");

            Console.WriteLine("Enter elements of the first matrix");
            var firstMatrix = GetMatrix(matrixRowCount, matrixColumnCount);

            Console.WriteLine("Enter elements of the second matrix");
            var secondMatrix = GetMatrix(matrixRowCount, matrixColumnCount);

            var sumResult = GetMatrixSum(matrixRowCount, matrixColumnCount, firstMatrix, secondMatrix);

            Console.WriteLine("Printing  Matrix Sum Result");
            PrintMatrix(sumResult);
        }

        static int GetMatrixParameter(string parameterName)
        {
            while (true)
            {
                Console.Write($"Enter numbers of {parameterName}: ");
                var isSuccess = int.TryParse(Console.ReadLine(), out var matrixParameter);

                if (isSuccess == true)
                {
                    if (matrixParameter <= 0)
                    {
                        Console.WriteLine($"Number of {parameterName} cant be negative or equal to 0.");
                        continue;
                    }

                    return matrixParameter;
                }
            }
        }

        static int[][] GetMatrix(int matrixRowCount, int matrixColumnCount)
        {
            int[][] matrix = new int[matrixRowCount][];

            for (int i = 0; i < matrixRowCount; i++)
            {
                var parsedRowNumbers = new List<int>();
                var isFailedInput = true;

                while (isFailedInput)
                {
                    Console.Write("Enter Row elements, each divided by column: ");
                    var consoleInput = Console.ReadLine();
                    Console.WriteLine();

                    var validatedInput = "";

                    foreach (var character in consoleInput)
                    {
                        if (!char.IsWhiteSpace(character))
                        {
                            validatedInput = validatedInput + character;
                        }
                    }

                    var splitRow = validatedInput.Split(',');
                    if (splitRow.Length != matrixColumnCount)
                    {
                        Console.WriteLine("Entered number of elements doesn't match the parameters ");
                        continue;
                    }

                    for (int j = 0; j < splitRow.Length; j++)
                    {
                        int intNumber;
                        if (!int.TryParse(splitRow[j], out intNumber))
                        {
                            break;
                        }

                        parsedRowNumbers.Add(intNumber);

                        if (j == splitRow.Length - 1)
                        {
                            isFailedInput = false;
                        }
                    }

                    matrix[i] = [.. parsedRowNumbers];
                }
            }

            return matrix;
        }

        static int[][] GetMatrixSum(int matrixRowCount, int matrixColumnCount, int[][] firstMatrix, int[][] secondMatrix)
        {
            int[][] finalMatrix = new int[matrixRowCount][];

            for (int i = 0; i < matrixRowCount; i++)
            {
                var finalMatrixRow = new List<int>();
                for (int j = 0; j < matrixColumnCount; j++)
                {
                    finalMatrixRow.Add(firstMatrix[i][j] + secondMatrix[i][j]);
                }

                finalMatrix[i] = [.. finalMatrixRow];
            }

            return finalMatrix;
        }

        static void PrintMatrix(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.Write("( ");

                var stringRow = string.Empty;
                foreach (var item in row)
                {
                    stringRow = stringRow + $"{item} ";
                }

                Console.Write(stringRow);
                Console.Write(")\n");
            }
        }
    }
}

