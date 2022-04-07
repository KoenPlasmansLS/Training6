namespace Training6;

struct Point
{
    public int X { get; init; }
    public int Y { get; init; }
}

class Point2
{
    public int X { get; init; }
    public int Y { get; init; }
}

internal class Base
{
    public bool Value { get; init; }
}

internal class Derived : Base
{
    internal Derived()
    {
        // Not allowed with get only properties but allowed with init
        Value = true;
    }
}

internal class InitOnlyDemo
{
    internal void Execute()
    {
        var p = new Point { X = 5, Y = 10 };
        //p.X = 7; => this won't even compile
        //p.Y = 14; => same here

        var p2 = new Point2 { X = 5, Y = 10 };
        //p2.X = 7; => this won't even compile
        //p2.Y = 14; => same here
        Console.WriteLine("Init only means only writeable when initializing the class/struct");

        var d = new Derived { Value = true };
        Console.WriteLine("Init only means only writeable when initializing a derived class");
    }
}