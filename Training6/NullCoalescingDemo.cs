namespace Training6;

internal static class NullCoalescingDemo
{
    internal static void Execute()
    {
        string? str1 = null;
        string? str2 = null;
        string str3 = "developers";

        str1 ??= str2 ??= str3; // str1 ??= (str2 ??= str3)

        Console.WriteLine($"Value of str1:{str1}");
        Console.WriteLine($"Value of str2:{str2}");
        Console.WriteLine($"Value of str3:{str3}");
    }
}