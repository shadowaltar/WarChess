
using Engine.Visuals.Sprites;

using SkiaSharp;

namespace Engine.Resources;
public class ResourceManager
{
    private readonly ResourceReader reader;

    public Dictionary<string, SKImage> Images { get; } = [];
    public Dictionary<string, AnimationClip> AnimationClips { get; } = [];

    public ResourceManager()
    {
        reader = new ResourceReader();
    }

    public Dictionary<string, string> GetTextFiles(string fileNameContains)
    {
        if (fileNameContains == null)
            throw new ArgumentNullException(nameof(fileNameContains));
        if (!fileNameContains.EndsWith(".")) 
            fileNameContains = fileNameContains + ".";
        return reader.GetFilesAsText(fileNameContains);
    }
}
