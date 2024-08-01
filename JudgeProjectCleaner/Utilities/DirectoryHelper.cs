
namespace JudgeProjectCleaner.Utilities;

public static class DirectoryHelper
{
    public static bool HasValidPath(string path, string searchFile)
    {
        string? fileToFind = Directory.GetFiles(path, searchFile)
            .FirstOrDefault();

        if (fileToFind != null)
        {
            return true;
        }

        return false;
    }

    public static void AddEntries(List<string> entries, string path, string[] excludedEntries)
    {
        foreach (var file in Directory.GetFiles(path))
        {
            if (!excludedEntries.Contains(Path.GetFileName(file)))
            {
                entries.Add(file);
            }
        }

        foreach (var directory in Directory.GetDirectories(path))
        {
            if (!excludedEntries.Contains(Path.GetFileName(directory)))
            {
                AddEntries(entries, directory, excludedEntries);
            }
        }
    }

    public static List<string> CutDirectories(string path, List<string> entries)
    {
        List<string> result = new List<string>();

        foreach (var entry in entries)
        {
            string parentName = Directory.GetParent(entry)!.Name;
            string mainDirectoryName = Path.GetFileName(path);

            // TODO: Make it deep copy. For now it's shallow
            if (parentName != mainDirectoryName)
            {
                result.Add(entry);
            }
        }

        return result;
    }

    public static string CutPathFromName(string path, string entry)
    {
        return Path.GetRelativePath(path, entry);
    }
}