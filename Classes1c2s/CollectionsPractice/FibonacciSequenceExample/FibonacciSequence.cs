namespace CollectionsPractice.FibonacciSequenceExample;

public class FibonacciSequence
{
    public static IEnumerable<int> Fibonacci
    {
        get
        {
            yield return 1;
            yield return 1;
            var currentValue = 1;
            var previousValue = 1;
            while (true)
            {
                var temp = currentValue;
                currentValue += previousValue;
                previousValue = temp;
                yield return currentValue;
            }
        }
    }
}