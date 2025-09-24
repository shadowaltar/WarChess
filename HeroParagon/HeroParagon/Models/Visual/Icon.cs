namespace HeroParagon.Models.Visual;

/// <summary>
/// Represents an icon set which has multiple size and usage of icons.
/// </summary>
public class Icon
{
    public long Id { get; set; }

    public Dictionary<long, Sprite> Icons { get; set; } = [];

    public Sprite? DefaultIcon => Icons.Values.FirstOrDefault();
}
