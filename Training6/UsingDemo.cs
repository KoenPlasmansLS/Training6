namespace Training6;

internal static class UsingDemo
{
    internal static void Execute()
    {
        Console.WriteLine("UsingDemo Start");

        //code block
        {
            string manyLines = @"This is line one
            This is line two
            Here is line three
            The penultimate line is line four
            This is the final, fifth line.";

            using var reader = new StringReader(manyLines);
            string? item;
            do
            {
                item = reader.ReadLine();
                Console.WriteLine(item);
            } while (item != null);
        }

        //At this point the reader is disposed as we're out of the scope
        // reader. is not reachable anymore so that's out of scope

        Console.WriteLine("UsingDemo Done");
    }
}