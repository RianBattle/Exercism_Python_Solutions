public static class SquareRoot
{
    public static int Root(int number)
    {
        if (number == 1) {
            return 1;
        }
        for (var i = 1; i <= number / 2; i++) {
            if (i * i == number) {
                return i;
            }
        }
        return 0;
    }
}
