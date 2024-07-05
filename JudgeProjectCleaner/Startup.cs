using JudgeProjectCleaner.Services;

namespace JudgeProjectCleaner
{
    public class Startup
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This app removes obj and bin folders of your solution for judge submits.");
            Console.WriteLine("Paste full path where .sln file is located:");

            string? path = Console.ReadLine();

            Console.WriteLine();

            try
            {
                if (path != string.Empty && 
                    path != null)
                {
                    Console.WriteLine(FolderManagerService.RemoveUnnecesseryDirectories(path).Trim());
                }
                else
                {
                    throw new ArgumentException("Empty path!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
