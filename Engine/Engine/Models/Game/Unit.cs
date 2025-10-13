using Engine.Logic.Expressions;
using Engine.Models.Abstracts;

namespace Engine.Models.Game;

/// <summary>
/// All kinds of game world units (creatures, characters, player/NPC avatars, buildings, temporary game objects, etc.)
/// </summary>
public class Unit : Actor
{
    public List<Property> Properties { get; } = [];

    public List<ArgumentedAbility> Abilities { get; } = [];
}
