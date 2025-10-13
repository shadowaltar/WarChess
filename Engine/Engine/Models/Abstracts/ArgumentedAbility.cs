using Engine.Logic.Expressions;

namespace Engine.Models.Abstracts;
public class ArgumentedAbility(Ability ability)
{
    public Ability Ability { get; } = ability;

    public List<Property> Arguments { get; set; }
}
