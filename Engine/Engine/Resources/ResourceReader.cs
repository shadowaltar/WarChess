using System.Reflection;
using System.Text;

using Engine.Utils;

namespace Engine.Resources;
public class ResourceReader
{
    private static readonly List<(string, Assembly)> resourceToAssemblies = [];
    private static readonly string resourcesDir;

    private readonly Dictionary<string, byte[]> configFilePathAndContents;

    public Dictionary<string, byte[]> ImageBytes { get; }

    static ResourceReader()
    {
        foreach (var asm in AssemblyUtil.GetUserAssemblies())
        {
            var names = asm.GetManifestResourceNames();
            foreach (var name in names)
            {
                if (name.EndsWith(".deps.json") || name.EndsWith(".runtimeconfig.json")) continue;
                resourceToAssemblies.Add((name, asm));
            }
        }
        var baseDir = AppContext.BaseDirectory;
        // Prefer baseDir/Resources first
        var candidate = Path.Combine(baseDir, "Resources");
        if (Directory.Exists(candidate))
        {
            resourcesDir = candidate;
        }
        else
        {
            // Walk up to find a Resources folder (useful when running from project folder)
            var dirInfo = new DirectoryInfo(baseDir);
            while (dirInfo != null && dirInfo.Exists)
            {
                candidate = Path.Combine(dirInfo.FullName, "Resources");
                if (Directory.Exists(candidate))
                {
                    resourcesDir = candidate;
                    break;
                }
                dirInfo = dirInfo.Parent;
            }
        }
    }

    public ResourceReader()
    {
        configFilePathAndContents = ReadFiles([".json", ".txt", ".xml", ".csv", ".yml", ".yaml"]);
        ImageBytes = ReadFiles([".gif", ".jpeg", ".jpg", ".png", ".webp"]);
        StateTransitionFiles = configFilePathAndContents.Where(p => p.Key.Contains("StateTransitions.")).ToDictionary(p => p.Key, p => Encoding.UTF8.GetString(p.Value));
    }

    public Dictionary<string, string> GetFilesAsText(string fileKeyContainText)
    {
        return configFilePathAndContents.Where(p => p.Key.Contains(fileKeyContainText)).ToDictionary(p => p.Key, p => Encoding.UTF8.GetString(p.Value));
    }

    private static Dictionary<string, byte[]> ReadFiles(string[] allowedExts)
    {
        var result = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);

        // Read disk files if directory found
        if (!string.IsNullOrEmpty(resourcesDir) && Directory.Exists(resourcesDir))
        {
            try
            {
                var files = Directory.EnumerateFiles(resourcesDir, "*.*", SearchOption.AllDirectories)
                                     .Where(f => allowedExts.Contains(Path.GetExtension(f), StringComparer.OrdinalIgnoreCase));

                foreach (var file in files)
                {
                    try
                    {
                        var bytes = File.ReadAllBytes(file);
                        // Key: relative path from resourcesDir, normalize separators to '/'
                        var rel = Path.GetRelativePath(resourcesDir, file).Replace(Path.DirectorySeparatorChar, '/');
                        result[rel] = bytes;
                    }
                    catch (Exception)
                    {
                        // Skip files that can't be read (permission/IO issues)
                    }
                }
            }
            catch (Exception)
            {
                // Ignore directory enumeration issues; return any embedded resources below.
            }
        }

        // Read embedded resources from this assembly whose names contain ".Resources."
        try
        {
            foreach (var (name, asm) in resourceToAssemblies)
            {
                if (!name.Contains(".Resources.", StringComparison.OrdinalIgnoreCase)) continue;
                if (!allowedExts.Contains(Path.GetExtension(name), StringComparer.OrdinalIgnoreCase)) continue;

                try
                {
                    using var s = asm.GetManifestResourceStream(name);
                    if (s == null) continue;
                    using var ms = new MemoryStream();
                    s.CopyTo(ms);
                    var bytes = ms.ToArray();

                    // Make a friendly key: manifest name after the ".Resources." segment
                    var idx = name.IndexOf(".Resources.", StringComparison.OrdinalIgnoreCase);
                    var friendlyKey = idx >= 0 ? name.Substring(idx + ".Resources.".Length) : name;
                    // replace '.' separators with '/' for readability except for extension dots
                    friendlyKey = friendlyKey.Replace('.', '/');
                    result[friendlyKey] = bytes;
                }
                catch (Exception)
                {
                    // Skip failing embedded resource reads
                }
            }
        }
        catch (Exception)
        {
            // ignore reflection/assembly issues
        }

        return result;
    }
}
