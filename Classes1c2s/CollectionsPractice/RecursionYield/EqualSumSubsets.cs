namespace CollectionsPractice.RecursionYield;

public class EqualSumSubsets
{
    private readonly int[] _weight;

    public EqualSumSubsets(int[] weight)
    {
        _weight = weight;
    }

    public void Evaluate(bool[] subset)
    {
        var delta = 0;
        for (var i = 0; i < subset.Length; i++)
        {
            if (subset[i])
                delta += _weight[i];
            else
                delta -= _weight[i];
        }
        foreach (var i in subset)
            Console.Write(i ? 1 : 0);
        Console.Write(" ");
        if  (delta == 0)
            Console.Write("ОК");
        Console.WriteLine();
    }

    public IEnumerable<bool[]> MakeSubsets(bool[] subset, int position)
    {
        if (position == subset.Length)
        {
            yield return subset;
            yield break;
        }
        
        subset[position] = true;
        foreach (var item in MakeSubsets(subset, position + 1))
            yield return item;
        
        subset[position] = false;
        foreach (var item in MakeSubsets(subset, position + 1))
            yield return item;
    }
}