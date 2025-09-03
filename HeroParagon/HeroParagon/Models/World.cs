using HeroParagon.Models.Core;

namespace HeroParagon.Models;
public class World : ModelBase, IHierarchicalModel
{
    public int ParentId { get; set; } = int.MinValue;
}
