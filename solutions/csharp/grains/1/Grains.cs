public static class Grains
{
    public static double Square(int n)
    {
        if (n <= 0 || n > 64) {
            throw new ArgumentOutOfRangeException();
        }
        
        return Math.Pow(2, n - 1);
    }

    public static double Total()
    {
        return Enumerable.Range(1, 64).Sum(Square);
    }
}