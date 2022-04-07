namespace Training6;

internal class C1
{
    public C2 C2 { get; set; } = new C2();
}

internal class C2
{
    public string Test { get; set; } = "test";
}

internal static class ExtendedPropertiesDemo
{
    internal static void Execute()
    {
        var c1 = new C1();
        var price = ComputePrice(c1, 5.0M);
        Console.WriteLine($"Calculated price:{price}");
        var c1a = new C1();
        c1a.C2.Test = "tester";
        var price2 = ComputePrice(c1a, 5.0M);
        Console.WriteLine($"Calculated price:{price2}");
        var c1b = new C1();
        c1b.C2.Test = "somethingelse";
        var price3 = ComputePrice(c1b, 5.0M);
        Console.WriteLine($"Calculated price:{price3}");
    }

    private static decimal ComputePrice(C1 c1, decimal price) =>

    c1 switch
    {
        { C2: { Test: "test" } } => 1.23M * price,
        { C2.Test: "tester" } => 0,
        _ => price
    };
}