﻿// Задача 53: Задайте двумерный массив. Напишите программу, которая меняет местами первую и последнюю строку массива.

Console.Write("Введите количество строк: ");
int rows = int.Parse(Console.ReadLine()!);

Console.Write("Введите количество столбцов: ");
int columns = int.Parse(Console.ReadLine()!);

int[,] array = GetArray(rows,columns, 0, 10);
PrintArray(array);
Console.WriteLine();
PrintArray(ChangeArray(array));
// ----------------Заполнение массива-----------------
int[,] GetArray(int m, int n, int minValue, int maxValue)
{
    int[,] res = new int[m,n];

    for (int i = 0; i < m; i++)
    {
        for(int j = 0; j < n; j++){
            res[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return res;
}

// -----------------Вывод массива-----------------
void PrintArray(int[,] array){
    for(int i = 0; i < array.GetLength(0); i++){
        for(int j = 0; j < array.GetLength(1); j++){
            Console.Write($"{array[i,j]} ");
        }
        Console.WriteLine();
    }
}
// ------------------Замена элементов массива-------------------

int[,] ChangeArray(int[,] array)
{
    for(int j = 0; j < array.GetLength(1); j++)
    {
    int temp = array[0,j];
    array[0,j] = array[array.GetLength(0)-1, j];
    array[array.GetLength(0)-1, j] = temp;
    }
    return array;
}
