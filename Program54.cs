// Задайте двумерный массив. Напишите программу,
// которая упорядочит по убыванию элементы каждой строки двумерного массива.

//============================БЛОК ОПИСАНИЙ==================

int InputSizeArray(string inputMessage, string errorMessage)
{
    int number = 0;
    while(true)
    {
        Console.Write(inputMessage);
        if (int.TryParse(Console.ReadLine(), out number) && number > 0)
            return number;
        Console.WriteLine(errorMessage);
    }
}

int[,] CreateArray(int rows, int columns)
{
    int[,] arr = new int[rows, columns];
    for (int i = 0; i < arr.GetLength(0); i++)
        for (int j = 0; j < arr.GetLength(1); j++)
            arr[i,j] =  new Random().Next(-99, 100);
    return arr;
}

void PrintArray(int[,] arr)
{
    for(int i = 0; i < arr.GetLength(0); i++)
        {
            for(int j = 0; j < arr.GetLength(1); j++)
                Console.Write($"{arr[i,j]} ");
            Console.WriteLine();
        }
    Console.WriteLine();
}

void ChangeArray(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        int[] massiv = new int[arr.GetLength(1)];
        for (int j = 0; j < arr.GetLength(1); j++)
            massiv[j] = arr[i,j];
        SortArray(massiv);
        for (int j = 0; j < arr.GetLength(1); j++)
            arr[i,j] = massiv[j];
    }
}


void SortArray(int[] arr)
{
    for (int k = 0; k < arr.GetLength(0) - 1; k++)
        {
            for (int l = 0; l < arr.GetLength(0) - 1; l++)
                if (arr[l] < arr[l + 1])
                {
                    int temp = arr[l];
                    arr[l] = arr[l + 1];
                    arr[l + 1] = temp;
                }
        }
}


//============================================================

Console.Clear();
int rows = InputSizeArray("Введите количество строк массива - ", "Ошибка ввода!");
int columns = InputSizeArray("Введите количество столбцов массива - ", "Ошибка ввода!");
int[,] array = CreateArray(rows, columns);
PrintArray(array);

ChangeArray(array);
Console.WriteLine();

PrintArray(array);
