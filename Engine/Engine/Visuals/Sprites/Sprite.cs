using System.Text.Json.Serialization;

namespace Engine.Visuals.Sprites;
public class Sprite
{
    public string State { get; set; }
    [JsonConverter(typeof(FrameDimensionArrayConverter))]
    public FrameDimension[] FrameDimensions { get; set; }
}

public struct FrameDimension
{
    public int TopLeftX { get; set; }
    public int TopLeftY { get; set; }
    public int BottomRightX { get; set; }
    public int BottomRightY { get; set; }
    public int AnchorX { get; set; }
    public int AnchorY { get; set; }
}