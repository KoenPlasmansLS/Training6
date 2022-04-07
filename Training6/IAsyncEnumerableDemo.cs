namespace Training6;

internal static class IAsyncEnumerableDemo
{
    internal static async Task Execute()
    {
        Console.WriteLine("Press the any key to continue.");
        Console.ReadKey();

        Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Start with Task");
        foreach (var item in await FetchItemsTask())
        {
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: {item}");
        }
        Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: End with Task");

        Console.WriteLine("Press the any key to continue.");
        Console.ReadKey();

        Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Start with yield");
        foreach (var item in FetchItemsYield())
        {
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: {item}");
        }
        Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: End with yield");

        Console.WriteLine("Press the any key to continue.");
        Console.ReadKey();

        Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Start with AsyncEnumerable");
        await foreach (var item in FetchItemsAsyncEnumerable())
        {
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: {item}");
        }
        Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: End with AsyncEnumerable");
    }

    static async Task<IEnumerable<int>> FetchItemsTask()
    {
        List<int> Items = new();
        for (int i = 1; i <= 10; i++)
        {
            await Task.Delay(1000);
            Items.Add(i);
        }
        return Items;
    }

    static IEnumerable<int> FetchItemsYield()
    {
        for (int i = 1; i <= 10; i++)
        {
            Thread.Sleep(1000);
            yield return i;
        }
    }

    static async IAsyncEnumerable<int> FetchItemsAsyncEnumerable()
    {
        for (int i = 1; i <= 10; i++)
        {
            await Task.Delay(1000);
            yield return i;
        }
    }
}