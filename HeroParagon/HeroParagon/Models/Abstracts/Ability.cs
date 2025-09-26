using HeroParagon.Models.Core;
using HeroParagon.Models.Expressions;
using HeroParagon.Models.Visual;

namespace HeroParagon.Models.Abstracts;

/// <summary>
/// A flexible ability system. Requirements to be fulfilled:
/// <list type="bullet">
///     <item>They must be globally singleton. Names must be unique among all abilities.</item>
///     <item>Parameters or arguments must be separated and stored in <see cref="ArgumentedAbility"/>.</item>
///     <item>
///         <term>Game behavior requirements</term>
///         <list type="bullet">
///             <term>Conditions in order to execute</term>
///             <list type="bullet">
///                 <item>Should check ability/global cooldown of skills of invoker.</item>
///                 <item>Should check if invoker has resource/value to invoke.</item>
///                 <item>Should check if target is within range/selectable/invincible.</item>
///             </list>
///         </list>
///     </item>
/// </list>
/// </summary>
public class Ability : NamedObject, IInheritable
{
    public List<string> Inherits { get; } = [];

    public Func<bool>? CanAct { get; set; }

    public Delegate? Action { get; set; }

    public Delegate? BeforeAction { get; set; }

    public Delegate? AfterAction { get; set; }

    public SpriteSet Sprites { get; set; } = [];

    public virtual bool CanBeUsed(Reference? invoker, Reference? target, List<Reference>? otherTargets)
    {
        return true;
    }

    public virtual void OnCreated() { }

    public virtual void OnRemoved() { }
}

public class PassiveAbility : Ability
{
}

public class ActiveAbility : Ability
{
    public Func<bool>? CanTarget { get; set; }
    public Delegate? TargetAction { get; set; }
}