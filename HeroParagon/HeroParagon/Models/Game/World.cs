using HeroParagon.Models.Core;

namespace HeroParagon.Models.Game;
public class World : ModelBase, IHierarchicalModel
{
    public int ParentId { get; set; } = int.MinValue;
}
