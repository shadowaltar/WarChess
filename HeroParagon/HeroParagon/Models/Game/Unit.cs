using HeroParagon.Models.Abstracts;
using HeroParagon.Models.Core;
using HeroParagon.Models.Expressions;

namespace HeroParagon.Models.Game;

/// <summary>
/// All kinds of game world units (creatures, characters, player/NPC avatars, buildings, temporary game objects, etc.)
/// </summary>
public class Unit : NamedObject, ITagged, IInheritable
{
    public List<NamedValue> Values { get; } = [];

    public List<string> Inherits { get; } = [];

    public List<string> Tags { get; } = [];
    
    public List<ArgumentedAbility> Abilities { get; } = [];
}
