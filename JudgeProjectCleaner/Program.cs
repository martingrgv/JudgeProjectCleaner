namespace JudgeProjectCleaner
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This app removes obj and bin folders of your solution for judge submits.");
            Console.WriteLine("Paste full path where .sln file is located:");

            string? path = Console.ReadLine();

            try
            {
                if (path != string.Empty && 
                    path != null)
                {
                    ProjectCleaner.CleanSolution(path);
                }
                else
                {
                    throw new InvalidOperationException("Empty path!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
