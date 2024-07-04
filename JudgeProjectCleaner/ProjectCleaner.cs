namespace JudgeProjectCleaner
{
    public class ProjectCleaner
    {
        private static readonly string[] removableDirectories = { "bin", "obj" };

        public static string CleanSolution(string path)
        {
            if (isPathValid(path))
            {
                int deleteCount = 0;

                for (int i = 0; i < removableDirectories.Length; i++)
                {
                    var directories = Directory.GetDirectories(path, removableDirectories[i], SearchOption.AllDirectories);

                    if (directories.Length > 0)
                    {
                        deleteCount += directories.Length;
                        RemoveDirectories(directories);
                    }
                }

                if (deleteCount == 0)
                {
                    return "There is nothing to delete.";
                }

                return $"Successfully deleted {deleteCount} directories from your solution.";
            }    
            else
            {
                throw new InvalidOperationException($"Unable to find solution in path: {path}");
            }
        }

        private static bool isPathValid(string path)
        {
            var files = Directory.GetFiles(path);

            if (files.Length == 0)
            {
                return false;
            }

            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Contains(".sln"))
                {
                    return true;
                }
            }

            return false;
        }

        private static void RemoveDirectories(string[] directories)
        {
            foreach (var directory in directories)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(directory);
                dirInfo.Delete(true);
            }
        }
    }
}
