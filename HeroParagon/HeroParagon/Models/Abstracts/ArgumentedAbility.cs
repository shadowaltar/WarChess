using HeroParagon.Models.Expressions;

namespace HeroParagon.Models.Abstracts;
public class ArgumentedAbility(Ability ability)
{
    public Ability Ability { get; } = ability;

    public Cooldown? Cooldown { get; set; }

    public List<NamedValue>? Arguments { get; set; }
}
