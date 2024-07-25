namespace JudgeProjectCleaner.Contracts;

public interface IZipArchiverService
{
    /// <summary>
    /// Archives a folder to .zip file.
    /// </summary>
    /// <param name="path">path to folder to be archived</param>
    /// <param name="entries">entries that will be included in archive</param>
    /// <returns>String that represents wheter the archiving proccess was completed or not.</returns>
    string ArchiveFolder(string path, string filename, List<string> entries);
}
