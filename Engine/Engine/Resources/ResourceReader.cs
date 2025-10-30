using System.Reflection;
using System.Text;

using Engine.Logic.Logging;
using Engine.Utils;

namespace Engine.Resources;
public class ResourceReader
{
    private const string DefaultDefinitionKey = "*";
    private const string DefinitionKeyword = "Definitions";
    private const string DefinitionBuiltInKeyword = "BuiltIn";
    private const string DefinitionBaseKeyword = "Base";
    private const string ImageKeyword = "Images";
    private const string SpriteAllStatesKeyword = "AllStates";
    private const string SpriteFramedKeyword = "Framed";

    private static readonly List<(string, Assembly)> resourceToAssemblies = [];

    private string resourcesDir;

    public Dictionary<DefinitionResourceType, Dictionary<string, string>> Configs { get; } = [];
    public Dictionary<BinaryResourceType, Dictionary<string, byte[]>> Images { get; } = [];
    public Dictionary<BinaryResourceType, Dictionary<string, byte[]>> Videos { get; } = [];
    public Dictionary<BinaryResourceType, Dictionary<string, byte[]>> Audios { get; } = [];
    public HashSet<string> ImagePaths => [.. ImageBytes.Keys];
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
    }

    public void Read()
    {
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
        const string jsonSuffix = "json";
        const string pngSuffix = "png";
        Configs.Clear();
        var configFilePathAndContents = ReadFiles(["." + jsonSuffix]);
        foreach (var (path, content) in configFilePathAndContents)
        {
            var parts = path.Split('/', '\\');
            if (!parts.ContainsIgnoreCase(DefinitionKeyword))
                continue;

            // definitions are all jsons
            if (!Enum.TryParse<DefinitionResourceType>(parts[2], out var type)
                && !Enum.TryParse(parts[1], out type))
            {
                Log.Error("Failed to parse to definition type, path is: " + path);
                continue;
            }
            var configs = Configs.GetOrCreate(type);
            var key = path[(DefinitionKeyword.Length + 1)..^(jsonSuffix.Length + 1)];
            key = key[(type.ToString().Length)..].Trim('/', '\\');
            key = string.IsNullOrEmpty(key) ? DefaultDefinitionKey : key;
            configs[key] = Encoding.UTF8.GetString(content);
        }

        var imageBytes = ReadFiles(["." + pngSuffix]);
        foreach (var (path, bytes) in imageBytes)
        {
            var parts = path.Split('/', '\\');
            if (!parts.ContainsIgnoreCase(ImageKeyword))
                continue;

            if (!Enum.TryParse<BinaryResourceType>(parts[2], out var type)
                && !Enum.TryParse(parts[1], out type))
            {
                Log.Error("Failed to parse to definition type, path is: " + path);
                continue;
            }
            var key = path[(ImageKeyword.Length + 1)..^(pngSuffix.Length + 1)];
            parts = key.Split('/', '\\').Where(p => p != type.ToString()).ToArray();
            var images = Images.GetOrCreate(type);
        }
    }

    //public Dictionary<string, string> GetFilesAsText(string fileKeyContainText)
    //{
    //    return configFilePathAndContents.Where(p => p.Key.Contains(fileKeyContainText)).ToDictionary(p => p.Key, p => Encoding.UTF8.GetString(p.Value));
    //}

    private Dictionary<string, byte[]> ReadFiles(string[] allowedExts)
    {
        var result = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);

        // Read disk files if directory found
        if (!string.IsNullOrEmpty(resourcesDir) && Directory.Exists(resourcesDir))
        {
            try
            {
                var files = Directory
                    .EnumerateFiles(resourcesDir, "*.*", SearchOption.AllDirectories)
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
