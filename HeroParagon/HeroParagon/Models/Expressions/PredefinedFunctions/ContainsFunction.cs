using HeroParagon.Utils;

namespace HeroParagon.Models.Expressions.PredefinedFunctions;
public class ContainsFunction : IFunction
{
    private const string NameString = "contains";
    private static readonly int NameLength = NameString.Length;

    public string Name => NameString;
    public bool IsValid { get; private set; }
    public NamedValue Operand1 { get; private set; }
    public NamedValue Operand2 { get; private set; }

    public void ParseDefinition(ReadOnlySpan<char> definition)
    {
        IsValid = false;
        if (definition == null || definition.IsEmpty)
        {
            return;
        }

        var argList = definition.GetArgList(Name);
        if (argList.IsEmpty)
        {
            return;
        }
        int i = argList.IndexOf(Consts.ArgDelimiter);
        if (i < 0)
        {
            return;
        }
        var v1 = argList[..i].Trim();
        var v2 = argList[(i + 1)..].Trim();
        if (v1.IsNullOrEmpty() || v2.IsNullOrEmpty())
        {
            return;
        }
            //Operand1 = ParseOperand(v1);
            //Operand2 = ParseOperand(v2);
        // TODO
    }
}
