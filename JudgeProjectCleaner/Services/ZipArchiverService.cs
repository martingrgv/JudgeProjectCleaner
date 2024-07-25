using System.IO.Compression;
using JudgeProjectCleaner.Contracts;
using JudgeProjectCleaner.Utilities;

namespace JudgeProjectCleaner;

public class ZipArchiverService : IZipArchiverService
{
    public string ArchiveFolder(string path, string filename, List<string> entries)
    {
        string fullPath = Path.Combine(path, filename);

        using (FileStream fileStream = new FileStream(fullPath, FileMode.OpenOrCreate))
        {
            using (ZipArchive archive = new ZipArchive(fileStream, ZipArchiveMode.Update))
            {
                foreach (var entry in entries)
                {
                    string fileName = DirectoryHelper.CutPathFromName(path, entry);
                    archive.CreateEntryFromFile(entry, fileName);
                }
            }
        }

        return $"Successfully archived {entries.Count} entries!";
    }
}
