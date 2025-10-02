using HeroParagon.Models.Expressions;

namespace HeroParagon.Models.Abstracts;
public class ArgumentedAbility(Ability ability)
{
    public Ability Ability { get; } = ability;

    public List<Property>? Arguments { get; set; }
}
