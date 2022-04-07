namespace Training6;

internal static class RecordDemo
{
    private static readonly DailyTemperature[] data = new DailyTemperature[]
    {
        new DailyTemperature(HighTemp: 57, LowTemp: 30),
        new DailyTemperature(60, 35),
        new DailyTemperature(63, 33),
        new DailyTemperature(68, 29),
        new DailyTemperature(72, 47),
        new DailyTemperature(75, 55),
        new DailyTemperature(77, 55),
        new DailyTemperature(72, 58),
        new DailyTemperature(70, 47),
        new DailyTemperature(77, 59),
        new DailyTemperature(85, 65),
        new DailyTemperature(87, 65),
        new DailyTemperature(85, 72),
        new DailyTemperature(83, 68),
        new DailyTemperature(77, 65),
        new DailyTemperature(72, 58),
        new DailyTemperature(77, 55),
        new DailyTemperature(76, 53),
        new DailyTemperature(80, 60),
        new DailyTemperature(85, 66)
    };

    internal static void Execute()
    {
        foreach (var item in data)
        {
            Console.WriteLine(item);
        }

        var heatingDegreeDays = new HeatingDegreeDays(65, data);
        Console.WriteLine($"Heating days: {heatingDegreeDays}");

        var coolingDegreeDays = new CoolingDegreeDays(65, data);
        Console.WriteLine($"Cooling days: {coolingDegreeDays}");

        var growingDegreeDays = coolingDegreeDays with { BaseTemperature = 41 }; //non-destructive mutation == new record instance with same properties BUT one or more properties can be changed
        Console.WriteLine(growingDegreeDays);

        var growingDegreeDaysCopy = growingDegreeDays with { };
        Console.WriteLine(growingDegreeDays);

        var cl1 = new DailyTemperatureClass { HighTemp = 5, LowTemp = 5 };
        var cl2 = new DailyTemperatureClass { HighTemp = 5, LowTemp = 5 };
        var r1 = new DailyTemperature { HighTemp = 5, LowTemp = 5 };
        var r2 = new DailyTemperature { HighTemp = 5, LowTemp = 5 };
        Console.WriteLine($"Are classes with same values samesies? {cl1.Equals(cl2)}");
        Console.WriteLine($"Are records with same values samesies? {r1.Equals(r2)}");
    }
}