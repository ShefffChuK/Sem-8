// **Задача 59**: Из двумерного массива целых чисел удалить строку и столбец,
//  на пересечении которых расположен наименьший элемент.

Console.Write("Введите количество строк: ");
int rows = int.Parse(Console.ReadLine()!);

Console.Write("Введите количество столбцов: ");
int columns = int.Parse(Console.ReadLine()!);

int[,] array = GetArray(rows, columns, 0, 10);
PrintArray(array);
Console.WriteLine();
Console.WriteLine($"Минимальный элемент находится: {String.Join(" ", GetMinPosition(array))}");
PrintArray(ChangeArray(array, GetMinPosition(array)));


// ----------------Заполнение массива-----------------
int[,] GetArray(int m, int n, int minValue, int maxValue)
{
    int[,] res = new int[m, n];

    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            res[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return res;
}

// -----------------Вывод массива-----------------
void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}
// ------------------Замена элементов массива-------------------

int[] GetMinPosition(int[,] array)
{
    int[] newArray = new int[] { 0, 0 };
    int minEl = array[0, 0];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (minEl > array[i, j])
            {
                minEl = array[i, j];
                newArray[0] = i;
                newArray[1] = j;
            }
        }
    }
    return newArray;
}

int[,] ChangeArray(int[,] array, int[] position)
{
    int[,] newArray = new int[array.GetLength(0) - 1, array.GetLength(1) - 1];
    int row = 0;
    int col = 0;
    {

        for (int i = 0; i < array.GetLength(0); i++)
        {
            if (i == position[0]) continue;
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (j == position[1]) continue;
                newArray[row, col] = array[i, j];
                col++;
            }
            col = 0;
            row++;
        }
        return newArray;
    }
}