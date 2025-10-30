
using Engine.Visuals.Sprites;

using SkiaSharp;

namespace Engine.Resources;
public class ResourceManager
{
    private readonly ResourceReader reader;

    public Dictionary<string, SKBitmap> SpriteBitmaps { get; } = [];
    public Dictionary<string, AnimationClip> AnimationClips { get; } = [];
    public Dictionary<DefinitionResourceType, Dictionary<string, string>> Configs => reader.Configs;
    public Dictionary<BinaryResourceType, Dictionary<string, byte[]>> Images => reader.Images;

    public ResourceManager()
    {
        reader = new ResourceReader();
        reader.Read();
        var configs = reader.Configs;
        SpriteBitmaps = reader.ImageBytes.ToDictionary(p => p.Key, p => SKBitmap.Decode(p.Value));

        var animationDefinitions = configs[DefinitionResourceType.Animation];
    }

    //public Dictionary<string, string> GetConfigFiles(string prefix)
    //{
    //    if (prefix == null)
    //        throw new ArgumentNullException(nameof(prefix));
    //    if (!prefix.EndsWith("."))
    //        prefix = prefix + ".";
    //    return reader.Configs.Where(p => p.Key.StartsWith(prefix)).ToDictionary(p => p.Key, p => p.Value);
    //}
}
