using System;

namespace MatrixProgram;

class MatrixProgram
{
    static int[,] MatrixInput()
    {
        Console.WriteLine("Nhap so dong: ");
        int rowsize = int.Parse(Console.ReadLine());
        Console.WriteLine("Nhap so cot: ");
        int colsize = int.Parse(Console.ReadLine());
        int[,] matrix = new int[rowsize, colsize];
        Console.WriteLine("Nhap cac phan tu cua ma tran: ");
        for (int i = 0; i < colsize; i++)
        {
            for (int j = 0; j < rowsize; j++)
            {
                Console.Write($"matrix[{i},{j}] = ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }
        return matrix;
    }

    static void MatrixOutput(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    static int[,] MatrixAdd(int[,] matrixA, int[,] matrixB)
    {
        if (matrixA.GetLength(0) == matrixB.GetLength(0) && matrixA.GetLength(1) == matrixB.GetLength(1))
        {
            int[,] matrixC = new int[matrixA.GetLength(0), matrixA.GetLength(1)];
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    matrixC[i, j] = matrixA[i, j] + matrixB[i, j];
                }
            }

            return matrixC;
        }
        Console.WriteLine("Ma tran A va B khong hop le");
        return null;
    }

    static int[,] MatrixMult(int[,] matrixA, int[,] matrixB)
    {
        if (matrixA.GetLength(1) == matrixB.GetLength(0))
        {
            int[,] matrixC = new int[matrixA.GetLength(0), matrixB.GetLength(1)];
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixB.GetLength(1); j++)
                {
                    for (int k = 0; k < matrixA.GetLength(1); k++)
                    {
                        matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return matrixC;
        }
        Console.WriteLine("Ma tran A va B khong hop le");
        return null;
    }

    static int[,] MatrixTranspose(int[,] matrix)
    {
        int[,] matrixTranspose = new int[matrix.GetLength(1), matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrixTranspose[j, i] = matrix[i, j];
            }
        }
        return matrixTranspose;
    }

    static void MatrixMaxMin(int[,] matrix)
    {
        if (matrix == null)
        {
            Console.WriteLine("Ma tran khong hop le");
            return;
        }
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        if (rows == 1 || cols == 1)
        {
            Console.WriteLine("Ma tran khong rong");
            return;
        }
        int max = matrix [0, 0];
        int min = matrix [0, 0];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                }
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                }
            }
        }
        Console.WriteLine($"Gia tri lon nhat: {max}");
        Console.WriteLine($"Gia tri nho nhat: {min}");
        return;
    }


    static void Main(string[] args)
    {
        Console.WriteLine("Chuong trinh ma tran");
        Console.WriteLine("1. Nhap ma tran");
        Console.WriteLine("2. Cong 2 ma tran");
        Console.WriteLine("3. Nhan 2 ma tran");
        Console.WriteLine("4. Chuyen vi ma tran");
        Console.WriteLine("5. Tim gia tri lon nhat va nho nhat");
        Console.WriteLine("6. Tim dinh thuc cua ma tran vuong");
        
        Console.WriteLine("Nhap chuc nang cua chuong trinh: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
            {
                int[,] matrixA = MatrixInput();
                MatrixOutput(matrixA);
                break;
            }
            case 2:
            {
                int[,] matrixA = MatrixInput();
                int[,] matrixB = MatrixInput();
                int[,] matrixC = MatrixAdd(matrixA, matrixB);
                MatrixOutput(matrixC);
                break;
            }
            case 3:
            {
                int[,] matrixA = MatrixInput();
                int[,] matrixB = MatrixInput();
                int[,] matrixC = MatrixMult(matrixA, matrixB);
                MatrixOutput(matrixC);
                break;
            }
            case 4:
            {
                int[,] matrixA = MatrixInput();
                int[,] matrixTranspose = MatrixTranspose(matrixA);
                MatrixOutput(matrixTranspose);
                break;  
            }
            case 5:
            {
                int[,] matrixA = MatrixInput();
                MatrixMaxMin(matrixA);
                break; 
            }
            case 6:
            {
                Console.WriteLine("Chuong trinh chua hoan thien");
                break; 
            }
        }
        
    }
    
}