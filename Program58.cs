// Задайте две матрицы. Напишите программу,
// которая будет находить произведение двух матриц.

//=================БЛОК ОПИСАНИЙ==============================

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
            arr[i,j] =  new Random().Next(-9, 10);
    return arr;
}

void PrintArray(string nameMessage, int[,] arr)
{
    Console.WriteLine(nameMessage);
    for(int i = 0; i < arr.GetLength(0); i++)
        {
            for(int j = 0; j < arr.GetLength(1); j++)
                Console.Write("{0,5}", arr[i,j]);
            Console.WriteLine();
        }
    Console.WriteLine();
}

int[,] MultiplicationArrays(int[,] arr1, int[,] arr2)
{
    if (arr1.GetLength(1) != arr2.GetLength(0))
    {
        Console.WriteLine("Ошибка! Умножение невозможно! \nКоличество столбцов первой матрицы не равно количеству строк второй матрицы.");
    }
    int[,] resultArr = new int[arr1.GetLength(0),arr2.GetLength(1)];
    for (int i = 0; i < arr1.GetLength(0); i++)
        for (int j = 0; j < arr2.GetLength(1); j++)
            resultArr[i,j] = SumElements(i, j, arr1, arr2);
    return resultArr;
}

int SumElements(int row, int column, int[,] arr1, int[,] arr2)
{
    int sum = 0;
    for (int k = 0; k < arr1.GetLength(1); k++)
        sum = sum + arr1[row,k] * arr2[k,column];
    return sum;
}
//===========================================================

Console.Clear();
int rows1 = InputSizeArray("Введите количество строк первой матрицы - ", "Ошибка ввода!");
int columns1 = InputSizeArray("Введите количество столбцов первой матрицы - ", "Ошибка ввода!");
int rows2 = InputSizeArray("Введите количество строк второй матрицы - ", "Ошибка ввода!");
int columns2 = InputSizeArray("Введите количество столбцов второй матрицы - ", "Ошибка ввода!");

int[,] array1 = CreateArray(rows1, columns1);
int[,] array2 = CreateArray(rows2, columns2);

PrintArray("Матрица А:", array1);
PrintArray("Матрица B:", array2);

int[,] resultArray =  MultiplicationArrays(array1, array2);
PrintArray("Рузультирующая матрица: ", resultArray);

