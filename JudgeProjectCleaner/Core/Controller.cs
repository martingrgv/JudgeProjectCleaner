using JudgeProjectCleaner.Contracts;
using JudgeProjectCleaner.Utilities;

namespace JudgeProjectCleaner.Core;

public class Controller : IController
{
    private readonly IZipArchiverService _zipArchiver;

    public Controller(IZipArchiverService zipArchiver)
    {
        _zipArchiver = zipArchiver;
    }

    public string ArchiveProject(string path, string[] excludedEntries)
    {
        if (!Directory.Exists(path))
        {
            throw new ArgumentException("Invalid path! Directory doesn't exist!");
        }
        else if (!DirectoryHelper.HasValidPath(path, $"{Path.GetFileName(path)}.csproj"))
        {
            throw new ArgumentException("Invalid path! Could not find .csproj file!");
        }

        string filename = Path.GetFileName(path) + "Cleaned.zip";
        string fullPath = Path.Combine(path, filename);

        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }

        List<string> entries = new List<string>();
        DirectoryHelper.AddEntries(entries, path, excludedEntries);

        return _zipArchiver.ArchiveFolder(path, filename, entries);
    }
}
