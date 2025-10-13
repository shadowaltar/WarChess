using Engine.Models.Game;

namespace Engine.Logic.H3;

/// <summary>
/// Stores the battle sequence of different units in combat.
/// It is also responsible for reordering of unit sequence if it has morale effect or used Wait ability.
/// </summary>
public class BattleSequence
{
    public BattleSequence(List<Unit> units)
    {
        Units = units;
    }

    public List<Unit> Units { get; }
}
