namespace GenericClassWork.GenericPipeline;

// Шаг 1: Очистка текста (String -> String)
public class TextCleaner : PipelineStep<string, string>
{
    public override string Process(string input)
    {
        return input.Trim().ToLower();
    }
}

// Шаг 2: Анализ длины (String -> Int)
public class WordCounter : PipelineStep<string, int>
{
    public override int Process(string input)
    {
        return input.Split(' ').Length;
    }
}

// Шаг 3: Вердикт (Int -> Boolean)
public class IsLongReview : PipelineStep<int, bool>
{
    public override bool Process(int input)
    {
        return input > 10;
    }
}

public static class TextProcessorExample
{
    public static void Run()
    {
        var pipeline = new TextCleaner() // String -> String
            .Step(new WordCounter()) // String -> Int
            .Step(new IsLongReview()); // Int -> Bool

        var result = pipeline.Process("  Это самый лучший сериал в моей жизни!  ");

        Console.WriteLine($"Это длинный отзыв? {result}");
    }
}