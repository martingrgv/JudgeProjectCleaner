using JudgeProjectCleaner.Contracts;

namespace JudgeProjectCleaner.Core;

public class Engine : IEngine
{
    IController _controller;
    private string? _path;

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


        _path = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(_path))
        {
            Console.WriteLine("Path must be set!");
            return;
        }

        ExecuteCommands();
    }

    public void Run(string[] args)
    {
        switch (args[0])
        {
            case "-p":
                if (args.Length == 2)
                {
                    if (string.IsNullOrWhiteSpace(args[1]))
                    {
                        Console.WriteLine("Could not find valid path!");
                        return;
                    }

                    _path = args[1];
                }
                break;
            default:
                Console.WriteLine("Invalid arguments");
                return;
        }

        ExecuteCommands();
    }

    private void ExecuteCommands()
    {
        Console.WriteLine();

        try
        {
            string result = _controller.ArchiveProject(_path!, EXCLUDED_ENTRIES);
            Console.WriteLine(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
