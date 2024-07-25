namespace JudgeProjectCleaner.Contracts;

public interface IController
{
    /// <summary>
    /// Archives project to .zip file.
    /// </summary>
    /// <param name="path">path to project where .csproj is located</param>
    /// <param name="excludedEntries">entries excluded from archive</param>
    /// <returns>Result wether the zip was successfully created.</returns>
    string ArchiveProject(string path, string[] excludedEntries);
}
