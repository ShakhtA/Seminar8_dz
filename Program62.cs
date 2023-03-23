// Заполните спирально массив 4 на 4. (Не совсем понял, как необходимо реализовать ввод элементов.)

//=================БЛОК ОПИСАНИЙ=========================
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

int[,] CreateArray(int size)
{
    int[,] arr = new int[size,size];
    FillArray(arr, "Ошибка ввода!");
    return arr;
}

void PrintArray(int[,] arr)
{
    for(int i = 0; i < arr.GetLength(0); i++)
        {
            for(int j = 0; j < arr.GetLength(1); j++)
                Console.Write($"{arr[i,j]:d2} ");
            Console.WriteLine();
        }
    Console.WriteLine();
}

void FillArray(int[,] arr, string errorMessage)
{
    Console.WriteLine("Введите значение элементов: ");
    for (int i = 0; i < arr.GetLength(0); i++)
        for (int j = 0; j < arr.GetLength(1); j++)
        {   
            Console.Write($"[{i},{j}] - ");
            while (true)
            {
                bool isCorrect = int.TryParse(Console.ReadLine(), out arr[i,j]);
                if (isCorrect) break;
                Console.WriteLine(errorMessage);
            }
        }
}

//======================================================================= 

Console.Clear();
int sizeArray = InputSizeArray("Введите размер массива - ", "Ошибка ввода!");
int[,] array = CreateArray(sizeArray);
PrintArray(array);
