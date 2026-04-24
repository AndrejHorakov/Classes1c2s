namespace GenericClassWork.SeriesExample;

public interface ITitleStep {
    IGenreStep WithTitle(string title);
}

public interface IGenreStep {
    ISeriesFinalStep OfGenre(string genre);
}

public interface ISeriesFinalStep {
    Series Release();
}