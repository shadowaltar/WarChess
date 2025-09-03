using HeroParagon.Models.Abstracts;

namespace HeroParagon.Models.Core;
public interface IPlaceable
{
    public Coordinate Coordinate { get; set; }
}