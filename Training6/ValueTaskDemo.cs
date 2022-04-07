namespace Training6
{
    internal static class ValueTaskDemo
    {
        private static string? _myInformation;

        internal static async ValueTask Execute()
        {
            Console.WriteLine("Start ValueTaskDemo");
            Console.WriteLine(await GetInformation());
            Console.WriteLine(await GetInformation());
            Console.WriteLine(await GetInformation());
        }

        internal static async ValueTask<string> GetInformation()
        {
            if (_myInformation is null)
            {
                _myInformation = await ReadInformation();
            }
            return _myInformation;
        }

        internal static async Task<string> ReadInformation()
        {
            await Task.Delay(1000);
            return "Got it";
        }
    }
}