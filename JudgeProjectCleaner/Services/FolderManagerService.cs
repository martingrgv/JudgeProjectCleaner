namespace JudgeProjectCleaner.Services
{
    /// <summary>
    /// Exposes static methods for removing unnecessary directories from your project. This class cannot be inherited.
    /// </summary>
    public sealed class FolderManagerService
    {
        private static readonly string[] defaultRemovableDirectories = { "bin", "obj" };

        /// <summary>
        /// Returns whether the removal was successfull or not.
        /// </summary>
        /// <param name="path">path to .sln file</param>
        /// <returns>Result of deletion.</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static string RemoveUnnecesseryDirectories(string path)
        {
            if (isPathValid(path))
            {
                var directories = FindDirectories(path, defaultRemovableDirectories);
                int deletedDirectoriesCount = DeleteDirectories(directories);

                if (deletedDirectoriesCount == 0)
                {
                    return "There is nothing to delete.";
                }

                return $"Successfully deleted {deletedDirectoriesCount} directories from your solution.";
            }
            else
            {
                throw new FileNotFoundException($"Unable to find solution in directory: {path}");
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

        private static List<string[]> FindDirectories(string path, string[] removableDirectories)
        {
            List<string[]> directories = new();

            for (int i = 0; i < removableDirectories.Length; i++)
            {
                directories.Add(Directory.GetDirectories(path, removableDirectories[i], SearchOption.AllDirectories));
            }

            return directories;
        }

        private static int DeleteDirectories(List<string[]> directories)
        {
            int removeCount = 0;
            foreach (var directoryArr in directories)
            {
                foreach (var directory in directoryArr)
                { 
                    DirectoryInfo dirInfo = new DirectoryInfo(directory);
                    dirInfo.Delete(true);
                    removeCount++;
                }
            }

            return removeCount;
        }
    }
}
