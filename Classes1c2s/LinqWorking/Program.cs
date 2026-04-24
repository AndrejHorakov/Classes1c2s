namespace LinqWorking;

public static class Program
{
    public class Point 
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X, Y;

        public override bool Equals(object? obj)
        {
            if (obj is Point other)
            {
                return X == other.X && Y == other.Y;
            }
            return base.Equals(obj);
        }
    }

    public static void Main()
    {
        var list = new List<Point>{ new(0,0), new (0,1)};
        Console.WriteLine(GetNeighborCount(list));
    }

    public static int GetNeighborCount(List<Point> points)
    {
        var adders = new[] { -1, 0, 1 };
        var a1=  points
            .SelectMany(p => adders
                .SelectMany(nx => adders
                    .Select(ny => new Point(p.X + nx, p.Y + ny))));
        var a2 = a1
            .Distinct()
            .Count();
            // .Count(x => !points.Contains(x));
        return a2;
    }
    
    
    
    
    
    
    
    
    
    
    
    
    // public static int[] MoveLeft(int[] array, int step)
    // {
    //     if (array.Length % step == 0)
    //         return array;
    //
    //     step %= array.Length;
    //
    //     return array
    //         .Skip(step)
    //         .Union(array.Take(step))
    //         .ToArray();
    // }
}