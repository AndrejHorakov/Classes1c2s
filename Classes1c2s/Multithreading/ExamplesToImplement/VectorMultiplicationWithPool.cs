namespace Multithreading.ExamplesToImplement;

public class VectorMultiplicationWithPool
{
    static int size = 3_000_000;
    static double[] vectorA = new double[size];
    static double[] vectorB = new double[size];
    static double[] result = new double[size];
    
    public static void Main()
    {
        Random rng = new Random();
        for (int i = 0; i < size; i++)
        {
            vectorA[i] = rng.NextDouble();
            vectorB[i] = rng.NextDouble();
        }

        int cores = Environment.ProcessorCount;
        int chunkSize = size / cores;
        CountdownEvent latch = new CountdownEvent(cores); // Используем его вместо Join

        for (int i = 0; i < cores; i++)
        {
            int start = i * chunkSize;
            int end = (i == cores - 1) ? size : start + chunkSize;

            // Прямая очередь в Пул Потоков
            ThreadPool.QueueUserWorkItem(_ => 
            {
                for (int j = start; j < end; j++)
                    result[j] = vectorA[j] * vectorB[j];
        
                latch.Signal(); // Сообщаем, что чанк готов
            });
        }

        latch.Wait(); // Вот теперь мы ждем Пул Потоков
        Console.WriteLine("ThreadPool завершил работу.");
    }
}