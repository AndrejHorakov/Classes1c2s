namespace GenericClassWork.GenericPipeline;

public abstract class PipelineStep<TIn, TOut>
{
    // Метод, который выполняет основную работу
    public abstract TOut Process(TIn input);

    // Метод для "склеивания" с другим шагом
    public PipelineStep<TIn, TNextOut> Step<TNextOut>(PipelineStep<TOut, TNextOut> nextStep)
    {
        return new WrapperStep<TIn, TOut, TNextOut>(this, nextStep);
    }
}

// Вспомогательный класс-обертка, чтобы соединить два шага в один
public class WrapperStep<TIn, TMid, TOut> : PipelineStep<TIn, TOut>
{
    private readonly PipelineStep<TIn, TMid> _first;
    private readonly PipelineStep<TMid, TOut> _second;

    public WrapperStep(PipelineStep<TIn, TMid> first, PipelineStep<TMid, TOut> second)
    {
        _first = first;
        _second = second;
    }

    public override TOut Process(TIn input)
    {
        TMid midRes = _first.Process(input); // Результат первого — вход для второго
        return _second.Process(midRes);
    }
}