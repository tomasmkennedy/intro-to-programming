namespace CSharpSyntax.Extensions;

public static class Utils
{


    public static bool IsEven(this int number)
    {

        return number % 2 == 0;
    }

    public static DateTime DaysFromToday(this int days)
    {
        return DateTime.Now.AddDays(days);
    }
}
