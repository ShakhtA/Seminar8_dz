// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
// Напишите программу, которая будет построчно выводить массив,
// добавляя индексы каждого элемента.

//================БЛОК ОПИСАНИЙ=============================
int InputSizeArray(string inputMessage, string errorMessage)
{
    int number = 0;
    while(true)
    {
        Console.Write(inputMessage);
        if (int.TryParse(Console.ReadLine(), out number) && number > 0)
            return number;
        Console.WriteLine(errorMessage);
        Console.WriteLine();
    }
}

int[,,] CreateArray(int rows, int columns, int width)    // Метод создает и заполняет массив.
{
    int[,,] arr = new int[rows,columns,width];
    for (int i = 0; i < rows; i++)
        for (int j = 0; j < columns; j++)
            for (int k = 0; k < width; k++)
            {
                int num;
                while (true)                                    // Блок проверяет новое число на наличие его в массиве
                {                                               // и отсекает однозначные числа из диапазона [-99...99].
                    bool f = false;
                    num = new Random().Next(-99, 100);   
                    
                    foreach (int el in arr)
                        if (el == num || (num > -10 && num < 10))
                            f = true;     
                    if (!f) break;    
                }
                arr[i,j,k] = num;

            }
    return arr;
}


void PrintArray(int[,,] arr)
{
    Console.WriteLine($"Массив расзмером {arr.GetLength(0)}x{arr.GetLength(1)}x{arr.GetLength(2)}");
    Console.Write("\n");
    for(int i = 0; i < arr.GetLength(0); i++)
    {
        for(int j = 0; j < arr.GetLength(1); j++)
        {
            for(int k = 0; k < arr.GetLength(2); k++)
                Console.Write($"[{i},{j},{k}] = {arr[i,j,k],3} ");
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

//=========================================================================

Console.Clear();
int rows = InputSizeArray("Введите количество строк массива - ", "Ошибка ввода!");
int columns = InputSizeArray("Введите количество столбцов массива - ", "Ошибка ввода!");
int width = InputSizeArray("Введите глубину массива - ", "Ошибка ввода!");
int[,,] array = CreateArray(rows, columns, width);
Console.WriteLine();
PrintArray(array);



