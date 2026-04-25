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
        var threadCnt = Environment.ProcessorCount; // Обычно 8, 12 или 16
        
        sw.Restart();
        // параллельно запускаем chunk-и
        var chunkSize = size / threadCnt;
        Thread[] threads = new Thread[threadCnt];
        for (int i = 0; i < threadCnt; i++)
        {
            var start = chunkSize * i;
            var end = i == threadCnt - 1 ? size : start + chunkSize;
            var thread = new Thread(() => Multiply(start, end));
            thread.Start();
            threads[i] = thread;
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }
        // Ждем завершения всех потоков 
        // .Join();
        sw.Stop();

        Console.WriteLine($"Параллельно ({threadCnt} потоков): {sw.ElapsedMilliseconds} мс");
    }

    static void Multiply(int start, int end)
    {
        for (int i = start; i < end; i++)
        {
            result[i] = Math.Sqrt(Math.Pow(vectorA[i], 2) * Math.Pow(vectorB[i], 2));
        }
    }
}