using System.Diagnostics;

namespace Multithreading.ExamplesToImplement;

class VectorMultiplication
{
    static int size = 3_000_000;
    static double[] vectorA = new double[size];
    static double[] vectorB = new double[size];
    static double[] result = new double[size];

    public static void Main()
    {
        // Подготовка данных
        Random rng = new Random();
        for (int i = 0; i < size; i++)
        {
            vectorA[i] = rng.NextDouble();
            vectorB[i] = rng.NextDouble();
        }

        // --- 1. Последовательное выполнение ---
        Stopwatch sw = Stopwatch.StartNew();
        Multiply(0, size);
        sw.Stop();
        Console.WriteLine($"Последовательно: {sw.ElapsedMilliseconds} мс");

        // --- 2. Параллельное выполнение ---
        Array.Clear(result, 0, result.Length); // Очистка результата
        // Environment.ProcessorCount; // Обычно 8, 12 или 16
        
        sw.Restart();
        // параллельно запускаем chunk-и

        // Ждем завершения всех потоков 
        sw.Stop();

        Console.WriteLine($"Параллельно ({0} потоков): {sw.ElapsedMilliseconds} мс");
    }

    static void Multiply(int start, int end)
    {
        //c_i = a_i X b_i 
        throw new NotImplementedException();
    }
}