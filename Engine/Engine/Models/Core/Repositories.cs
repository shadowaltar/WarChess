using Engine.Logic.Expressions;

namespace Engine.Models.Core;
public class Repositories
{
    public static KeywordRepository Keywords { get; set; } = new KeywordRepository();
}
