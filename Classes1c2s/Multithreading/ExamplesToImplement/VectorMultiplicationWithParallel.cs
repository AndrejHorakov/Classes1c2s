namespace Multithreading.ExamplesToImplement;

public class VectorMultiplicationWithParallel
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
        
        // Вместо ручного деления на чанки и создания Thread[]:
        Parallel.For(0, size, i => 
        {
            // Система сама решит, сколько потоков создать 
            // и какие индексы 'i' какому ядру отдать.
            result[i] = Math.Sqrt(Math.Pow(vectorA[i], 2) * Math.Pow(vectorB[i], 2));
        });
        // Есть ещё Parallel.ForEach(array, elem => { Process(elem)});
    }
}