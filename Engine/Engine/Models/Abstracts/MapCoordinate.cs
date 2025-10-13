namespace Engine.Models.Abstracts;

/// <summary>
/// Coordinate collection for a tile.
/// Tiles of square or hexagon maps usually only use X and Y. Z is used for height if needed.
/// MapId is to identify which map this coordinate belongs to.
/// LayerId is to identify which layer of the map this coordinate belongs to.
/// </summary>
public struct MapCoordinate
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    public double MapId { get; set; }
    public double LayerId { get; set; }
}

public struct Coordinate2D
{
    public double X { get; set; }
    public double Y { get; set; }
}
