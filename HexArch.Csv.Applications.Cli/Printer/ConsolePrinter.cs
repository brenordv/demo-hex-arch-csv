using System.Reflection;

namespace HexArch.Csv.Applications.Cli.Printer;

public static class ConsolePrinter
{
    private const string Line =
        "--------------------------------------------------------------------------------------------------------------------------------";

    public static void PrintHeader()
    {
        Console.WriteLine(@" __    __   __________   ___         ___      .______        ______  __    __                  ______     _______.____    ____ ");
        Console.WriteLine(@"|  |  |  | |   ____\  \ /  /        /   \     |   _  \      /      ||  |  |  |                /      |   /       |\   \  /   / ");
        Console.WriteLine(@"|  |__|  | |  |__   \  V  /        /  ^  \    |  |_)  |    |  ,----'|  |__|  |     ______    |  ,----'  |   (----` \   \/   /  ");
        Console.WriteLine(@"|   __   | |   __|   >   <        /  /_\  \   |      /     |  |     |   __   |    |______|   |  |        \   \      \      /   ");
        Console.WriteLine(@"|  |  |  | |  |____ /  .  \      /  _____  \  |  |\  \----.|  `----.|  |  |  |               |  `----.----)   |      \    /    ");
        Console.WriteLine(@"|__|  |__| |_______/__/ \__\    /__/     \__\ | _| `._____| \______||__|  |__|                \______|_______/        \__/     ");
        Console.WriteLine($@"version: {Assembly.GetExecutingAssembly().GetName().Version}");
        Console.WriteLine(Line);
    }

    public static void PrintUsage()
    {
        Console.WriteLine("Usage: hexarchcli.exe [filename.csv]");
    }

    public static void PrintFooter()
    {
        Console.WriteLine(Line);
    }
}