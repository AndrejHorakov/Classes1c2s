namespace Multithreading.ExamplesToImplement;

class AdvancedGarden
{
    static int rows = 12;
    static int cols = 26;
    static char[,] garden = new char[rows, cols];
    
    // Объект-заглушка для синхронизации и данных, и консоли
    static readonly object _locker = new object();

    public static void Main()
    {
        Console.CursorVisible = false;
        Console.Clear();;

        // Рисуем пустой сад
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write('.');
                garden[i, j] = '.';
            }
            Console.WriteLine();
        }

        Thread g1 = new Thread(Gardener1);
        Thread g2 = new Thread(Gardener2);

        g1.Start();
        g2.Start();

        g1.Join();
        g2.Join();

        Console.SetCursorPosition(0, rows + 1);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Работа завершена. Нажмите любую клавишу...");
        Console.ReadKey();
    }

    static void Gardener1()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                UpdateCell(i, j, '1', ConsoleColor.Green);
                Thread.Sleep(20); // Замедление для наглядности
            }
        }
    }

    static void Gardener2()
    {
        for (int j = cols - 1; j >= 0; j--)
        {
            for (int i = rows - 1; i >= 0; i--)
            {
                UpdateCell(i, j, '2', ConsoleColor.Yellow);
                Thread.Sleep(20);
            }
        }
    }

    static void UpdateCell(int r, int c, char mark, ConsoleColor color)
    {
        // Блокируем доступ, чтобы проверка и отрисовка были единой операцией
        lock (_locker)
        {
            if (garden[r, c] == '.')
            {
                garden[r, c] = mark;

                // Критическая секция для консоли
                Console.SetCursorPosition(c, r);
                Console.ForegroundColor = color;
                Console.Write(mark);
            }
        }
    }
}