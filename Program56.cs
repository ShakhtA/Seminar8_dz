// Задайте прямоугольный двумерный массив. Напишите программу,
// которая будет находить строку с наименьшей суммой элементов.

//===================БЛОК ОПИСАНИЙ===============================

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

int CountSum(int[,] arr)
{
    int minSum = 0;
    int indexMinSum = 0;
    for (int i = 0; i < arr.GetLength(0); i++)
    {   
         int sum = 0;
        for (int j = 0; j < arr.GetLength(1); j++)
            sum += arr[i,j];
        Console.Write($"{sum} ");
        if (i == 0) minSum = sum;
        if (sum < minSum)
           {
               minSum = sum;
               indexMinSum = i;
           } 

    }
    return indexMinSum;
}

void PrintResult(int index)
{
    Console.WriteLine($"В заданном массиве строка с наименьшей суммой элементов - {index + 1}-я");
    Console.WriteLine();
}

//==============================================================

Console.Clear();
int rows = InputSizeArray("Введите количество строк массива - ", "Ошибка ввода!");
int columns = InputSizeArray("Введите количество столбцов массива - ", "Ошибка ввода!");
int[,] array = CreateArray(rows, columns);
PrintArray(array);
int minIndex = CountSum(array);
PrintResult(minIndex);




