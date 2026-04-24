namespace Multithreading.ExamplesToImplement;

using System;
using System.Threading;

class GardenSimulation
{
    // Общий ресурс для обоих потоков
    static int rows = 10;
    static int cols = 20;
    static char[,] garden = new char[rows, cols];

    public static void Main()
    {
        // 1. Инициализация сада "сорняками"
        for (int i = 0; i < rows; i++)
        for (int j = 0; j < cols; j++)
            garden[i, j] = '.';

        // 2. Создание потоков-садовников
        Thread gardener1 = new Thread(Gardener1Action);
        Thread gardener2 = new Thread(Gardener2Action);

        // 3. Запуск работы
        gardener1.Start();
        gardener2.Start();

        // 4. Ожидаем завершения обоих
        gardener1.Join();
        gardener2.Join();

        // 5. Вывод итогового результата
        PrintGarden();
    }

    static void Gardener1Action()
    {
        
    }

    static void Gardener2Action()
    {
       
    }

    static void PrintGarden()
    {
        Console.WriteLine("Результат работы садовников:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(garden[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}