using Engine.Models.Abstracts;
using Engine.Models.Core;
using Engine.Visuals;

namespace Engine.Models.Game;
public class World : Actor
{
    public View View { get; set; }
    public Dictionary<string, View> RelatedViews = [];
}
