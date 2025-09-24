using HeroParagon.Models.Core;
using HeroParagon.Models.Visual;

namespace HeroParagon.Models.Abstracts;
public class Ability : NamedObject, IInheritable
{
    public List<string> Inherits { get; } = [];

    public Func<bool>? CanAct { get; set; }

    public Delegate? Action { get; set; }

    public Delegate? BeforeAction { get; set; }

    public Delegate? AfterAction { get; set; }

    public SpriteSet Sprites { get; set; } = [];
}
