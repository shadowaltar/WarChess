using Engine.Models.Abstracts;

namespace Engine.Models.Core;
public interface IPlaceable
{
    public MapCoordinate Coordinate { get; set; }
}