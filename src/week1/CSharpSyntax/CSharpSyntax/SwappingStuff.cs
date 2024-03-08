namespace CSharpSyntax;
public class SwappingStuff
{
    [Fact]
    public void CanSwapStuff()
    {
        var x = 10;
        var y = 15;

        // Magic!
        Swappers.Swap(ref x, ref y);

        var x2 = 12.23M;
        var y2 = 18.12M;

        Swappers.Swap(ref x2, ref y2);

        var x3 = "Bailey";
        var y3 = "Spike";

        Swappers.Swap(ref x3, ref y3);

        Assert.Equal(15, x);
        Assert.Equal(10, y);

    }
}

public class Swappers
{
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = b;
        b = a;
        a = temp;
    }

}