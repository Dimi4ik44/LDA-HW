using System;

namespace HW4
{
    class Program
    {
        static string[] errorMessageList = { "Incorrect input", "Incorrect selection"};
        static void Main(string[] args)
        {
            //Console.WriteLine("Welcome to matrix solver!");
            //selectOp();
            //int[,] matrix = inputMatrix(inputNumber("Input Lenght Matrix"), inputNumber("Input Height Matrix"));
            //twoDementionArrayPrint(matrix);
            selectOp();

        }
        static void selectOp()
        {
            Console.WriteLine("Select operation");
            Console.WriteLine("Operation list: \n   1: matrix + matrix\n   2: matrix * n\n   3: matrix * matrix\n   4: pow(matrix,n)\n   5: transpon(matrix)");
            int matrixLenght, matrixHeight;
            int[,] matrix1, matrix2;
            switch (inputNumber("Write selection"))
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Selected 'matrix + matrix' operation");
                    matrixLenght = inputNumber("Input Lenght Matrix");
                    matrixHeight = inputNumber("Input Height Matrix");
                    Console.WriteLine("Start init matrix N1");
                    matrix1 = inputMatrix(matrixLenght,matrixHeight);
                    Console.Clear();
                    Console.WriteLine("Start init matrix N2");
                    matrix2 = inputMatrix(matrixLenght, matrixHeight);
                    twoDementionArrayPrint(matrixSum(matrix1,matrix2));
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Selected 'matrix * n' operation");
                    matrixLenght = inputNumber("Input Lenght Matrix");
                    matrixHeight = inputNumber("Input Height Matrix");
                    Console.WriteLine("Start init matrix");
                    matrix1 = inputMatrix(matrixLenght, matrixHeight);
                    Console.Clear();
                    int multiplier = inputNumber("Write multiplier");
                    twoDementionArrayPrint(matrixMultipleN(matrix1, multiplier));
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Selected 'matrix * matrix' operation");
                    matrixLenght = inputNumber("Input Lenght Matrix");
                    matrixHeight = inputNumber("Input Height Matrix");
                    Console.WriteLine("Start init matrix N1");
                    matrix1 = inputMatrix(matrixLenght, matrixHeight);
                    Console.Clear();
                    matrixLenght = inputNumber("Input Lenght Matrix");
                    matrixHeight = inputNumber("Input Height Matrix");
                    Console.WriteLine("Start init matrix N2");
                    matrix2 = inputMatrix(matrixLenght, matrixHeight);
                    twoDementionArrayPrint(matrixMultiple(matrix1, matrix2));
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    sendErrorMessage(errorMessageList[1]);
                    break;
            }
        }

        static int inputNumber(string message = "", int type = 0)
        {
            //
            int number;
            switch (type)
            {
                case -1: //negative numbers include 0
                    if (message != "")
                    {
                        Console.WriteLine(message);
                    }
                    while (!(Int32.TryParse(Console.ReadLine(), out number)) || number > 0)
                    {
                        sendErrorMessage(errorMessageList[0]);
                    }
                    return number;
                case -2: //negative numbers without 0
                    if (message != "")
                    {
                        Console.WriteLine(message);
                    }
                    while (!(Int32.TryParse(Console.ReadLine(), out number)) || number >= 0)
                    {
                        sendErrorMessage(errorMessageList[0]);
                    }
                    return number;
                case 1: //positive numbers include 0
                    if (message != "")
                    {
                        Console.WriteLine(message);
                    }
                    while (!(Int32.TryParse(Console.ReadLine(), out number)) || number < 0)
                    {
                        sendErrorMessage(errorMessageList[0]);
                    }
                    return number;
                case 2: //positive numbers without 0
                    if (message != "")
                    {
                        Console.WriteLine(message);
                    }
                    while (!(Int32.TryParse(Console.ReadLine(), out number)) || number <= 0)
                    {
                        sendErrorMessage(errorMessageList[0]);
                    }
                    return number;
                default: //all numbers
                    if (message != "")
                    {
                        Console.WriteLine(message);
                    }
                    while (!(Int32.TryParse(Console.ReadLine(), out number)))
                    {
                        sendErrorMessage(errorMessageList[0]);
                    }
                    return number;
            }
        }
        static int[,] inputMatrix(int sizeX,int sizeY)
        {
            int[,] matrix = new int[sizeY, sizeX];

            int lenghtDimen0, lenghtDimen1;
            lenghtDimen0 = matrix.GetLength(0); //рядки 
            lenghtDimen1 = matrix.GetLength(1); //стовбці

            for (int i = 0; i < lenghtDimen0; i++)
            {
                for (int k = 0; k < lenghtDimen1; k++)
                {
                    matrix[i, k] = inputNumber("Write next value:");
                }
            }

            return matrix;
        }
        static void twoDementionArrayPrint(int[,] array)
        {
            int lenghtDimen0, lenghtDimen1;
            lenghtDimen0 = array.GetLength(0);
            lenghtDimen1 = array.GetLength(1);
            string sep = "";
            for (int i = 0; i < lenghtDimen1 * 6 + 1; i++)
            {
                sep += "-";
            }
            for (int i = 0; i < lenghtDimen0; i++)
            {
                Console.WriteLine(sep);
                for (int k = 0; k < lenghtDimen1; k++)
                {
                    Console.Write($"|  {array[i, k]}  ");
                }
                Console.Write("|\n");
            }
            Console.WriteLine(sep);
        }
        static int[,] matrixSum(int[,] matrix1, int[,] matrix2)
        {
            int matrix1LenghtDimen0, matrix1LenghtDimen1;
            matrix1LenghtDimen0 = matrix1.GetLength(0);
            matrix1LenghtDimen1 = matrix1.GetLength(1);

            int[,] result = new int[matrix1LenghtDimen0, matrix1LenghtDimen1];

            for (int i = 0; i < matrix1LenghtDimen0; i++)
            {
                for (int k = 0; k < matrix1LenghtDimen1; k++)
                {
                    result[i, k] = matrix1[i, k] + matrix2[i, k];
                }
            }
            return result;
        }
        static int[,] matrixMultipleN(int[,] matrix,int multiplier)
        {

            int lenghtDimen0, lenghtDimen1;
            lenghtDimen0 = matrix.GetLength(0);
            lenghtDimen1 = matrix.GetLength(1);

            for (int i = 0; i < lenghtDimen0; i++)
            {
                for (int k = 0; k < lenghtDimen1; k++)
                {
                    matrix[i, k] *= multiplier;
                }
            }

            return matrix;
        }
        static int[,] matrixMultiple(int[,] matrix1, int[,] matrix2)
        {
            int matrix1LenghtDimen0, matrix1LenghtDimen1;
            matrix1LenghtDimen0 = matrix1.GetLength(0);
            matrix1LenghtDimen1 = matrix1.GetLength(1);

            int matrix2LenghtDimen0, matrix2LenghtDimen1;
            matrix2LenghtDimen0 = matrix2.GetLength(0);
            matrix2LenghtDimen1 = matrix2.GetLength(1);

            int[,] result = new int[matrix1LenghtDimen0,matrix2LenghtDimen1];

            if (matrix1LenghtDimen1 == matrix2LenghtDimen0)
            {
                for (int i = 0; i < matrix1LenghtDimen0; i++)
                {
                    for (int l = 0; l < matrix2LenghtDimen1; l++)
                    {
                        int resultMul = 0;
                        for (int k = 0; k < matrix1LenghtDimen1; k++)
                        {
                            resultMul += matrix1[i, k] * matrix2[k, l];
                        }
                        result[i, l] = resultMul;
                    }
                }
                
            }
            else
            {
                Console.WriteLine("Isnt real");
                result = new int[0, 0];
            }


            return result;
        }

        static void sendErrorMessage(string error)
        {
            Console.WriteLine($"Error: {error}");
        }
    }
}
