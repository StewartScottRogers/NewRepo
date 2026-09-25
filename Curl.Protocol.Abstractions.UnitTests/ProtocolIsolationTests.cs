using System.Xml.Linq;

namespace Curl.Protocol.Abstractions;

/// <summary>
/// Guards the architecture rule that makes the protocol libraries independent.
/// </summary>
public sealed class ProtocolIsolationTests
{
    private const string Abstractions = "Curl.Protocol.Abstractions.UnitLibrary";

    [Fact]
    public void ProtocolLibrary_References_OnlyAbstractions()
    {
        var violations = new List<string>();

        foreach (var project in ProtocolLibraries())
        {
            foreach (var referenced in ProjectReferences(project))
            {
                if (referenced != Abstractions)
                {
                    violations.Add($"{ProjectName(project)} -> {referenced}");
                }
            }
        }

        Assert.Empty(violations);
    }

    [Fact]
    public void Abstractions_References_Nothing()
    {
        var project = Path.Combine(RepositoryRoot(), Abstractions, Abstractions + ".csproj");

        Assert.Empty(ProjectReferences(project));
    }

    [Fact]
    public void EveryProtocolLibrary_HasAMatchingTestProject()
    {
        var root = RepositoryRoot();

        foreach (var project in ProtocolLibraries())
        {
            var tests = ProjectName(project).Replace(".UnitLibrary", ".UnitTests");

            Assert.True(
                File.Exists(Path.Combine(root, tests, tests + ".csproj")),
                $"{tests} is missing.");
        }
    }

    private static IEnumerable<string> ProtocolLibraries() =>
        Directory.EnumerateFiles(RepositoryRoot(), "Curl.Protocol.*.UnitLibrary.csproj",
                SearchOption.AllDirectories)
            .Where(path => ProjectName(path) != Abstractions);

    private static string ProjectName(string projectPath) =>
        Path.GetFileNameWithoutExtension(projectPath);

    private static IReadOnlyList<string> ProjectReferences(string projectPath) =>
        XDocument.Load(projectPath)
            .Descendants("ProjectReference")
            .Select(element => (string?)element.Attribute("Include"))
            .Where(include => include is not null)
            .Select(include => Path.GetFileNameWithoutExtension(include!.Replace('\\', '/')))
            .ToList();

    private static string RepositoryRoot()
    {
        var directory = new DirectoryInfo(AppContext.BaseDirectory);

        while (directory is not null && !File.Exists(Path.Combine(directory.FullName, "Curl.slnx")))
        {
            directory = directory.Parent;
        }

        Assert.NotNull(directory);

        return directory!.FullName;
    }
}
