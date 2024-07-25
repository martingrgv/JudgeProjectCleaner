using Microsoft.Extensions.DependencyInjection;
using JudgeProjectCleaner.Core;
using JudgeProjectCleaner.Contracts;

namespace JudgeProjectCleaner
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddTransient<IZipArchiverService, ZipArchiverService>()
            .AddTransient<IController, Controller>()
            .BuildServiceProvider();

            var controller = serviceProvider.GetRequiredService<IController>();

            Engine engine = new Engine(controller);

            if (args != null &&
                args.Length > 0)
            {
                engine.Run(args);               
                return;
            }

            engine.Run();
        }
    }
}
