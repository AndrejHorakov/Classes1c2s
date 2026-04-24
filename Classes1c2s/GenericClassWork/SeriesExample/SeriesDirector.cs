namespace GenericClassWork.SeriesExample;

public class SeriesDirector : ITitleStep, IGenreStep, ISeriesFinalStep
{
    private readonly Series _series = new Series();

    private SeriesDirector()
    {
    }

    // Единственная точка входа
    public static ITitleStep StartProduction()
    {
        return new SeriesDirector();
    }

    public IGenreStep WithTitle(string title)
    {
        _series.Title = title;
        return this; // Возвращаем себя, но "под маской" следующего шага
    }

    public ISeriesFinalStep OfGenre(string genre)
    {
        _series.Genre = genre;
        return this;
    }

    public Series Release()
    {
        Console.WriteLine($"Премьера! Сериал '{_series.Title}' в жанре {_series.Genre}");
        return _series;
    }
}

public static class SeriesExample
{
    public static void Run()
    {
        var myShow = SeriesDirector.StartProduction()
            .WithTitle("Во все тяжкие")
            .OfGenre("Драма")
            .Release();
        // Ошибка компиляции:
        // SeriesDirector.StartProduction().Release(); // Нельзя выпустить без названия
        // SeriesDirector.StartProduction().OfGenre("Комедия"); // Сначала нужно название
    }
}