using Engine.Visuals;

namespace Engine.Models;

public class DisplayableObject : NamedObject
{
    public Icon Icon { get; set; } = new();

    public SpriteSet SpriteSet { get; set; } = new();
}
