using System.Diagnostics.CodeAnalysis;

namespace Training6;

internal static class NullableReferenceDemo
{
    internal static void Execute()
    {
        string message = null;

        try
        {
            //warning in .NET 4.8 : dereference = null
            Console.WriteLine($"The length of the message is {message.Length}");
        }
        catch (NullReferenceException ex)
        { }

        var originalMessage = message;
        message = "Hello, World!";

        //No warning. Analysis determined "message" is not null
        Console.WriteLine($"The length of the message is {message.Length}");

        try
        {
            //warning in .NET 4.8 AND .NET 6!
            Console.WriteLine(originalMessage.Length);
        }
        catch (NullReferenceException ex)
        { }


        var strNullableImplicit = ""; //string? is implied as implicity declared
        string strNonNullableExplicit = ""; //still string as explicity declared as non-nullable
        string? strNullableExplicit = null; //explicitly declared as nullable

        strNonNullableExplicit = null; //string is transformed to string? !!!!!!
        try
        {
            Console.WriteLine(strNonNullableExplicit.Length);
        }
        catch (NullReferenceException ex)
        { }

        if (CheckForNull(strNullableExplicit))
        {
            Console.WriteLine(strNullableExplicit.Length); //stupid compiler, can't be null here as we check it in our function
        }

        if (CheckForNull2(strNullableExplicit))
        {
            Console.WriteLine(strNullableExplicit.Length); //no warning as we specified that we check for null in our function
        }

        if (CheckForNull(strNullableExplicit))
        {
            Console.WriteLine(strNullableExplicit!.Length); //no warning due to null-forgiving operator
        }
    }

    private static bool CheckForNull(string? nullableString)
    {
        return !string.IsNullOrWhiteSpace(nullableString);
    }

    private static bool CheckForNull2([NotNullWhen(true)] string? nullableString)
    {
        return !string.IsNullOrWhiteSpace(nullableString);
    }
}