using JudgeProjectCleaner.Contracts;

namespace JudgeProjectCleaner.Core;

public class Engine : IEngine
{
    IController _controller;
    private readonly string[] EXCLUDED_ENTRIES = { "bin", "obj", ".DS_Store", "Migrations", "Datasets" };

    public Engine(IController controller)
    {
        _controller = controller;       
    }

    public void Run()
    {
        Console.WriteLine("Judge project cleaner");
        Console.WriteLine("---------------------");
        Console.WriteLine("Paste path to .csproj file");

        string? path = Console.ReadLine();

        Console.WriteLine();

        if (path == string.Empty ||
            path == null)
        {
            Console.WriteLine("Path must be set!");
            return;
        }

        try
        {
            string result = _controller.ArchiveProject(path, EXCLUDED_ENTRIES);
            Console.WriteLine(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
