using HeroParagon.Models.Expressions.Operands;

namespace HeroParagon.Models.Expressions.PredefinedFunctions;
public class RandomFunction : IFunction
{
    private const string NameString = "random";
    private static readonly int NameLength = NameString.Length;

    public string Name => NameString;

    public bool IsValid { get; private set; }

    public double Operand1 { get; set; } = 0;

    public double Operand2 { get; set; } = 0;

    public bool IsDiscrete { get; private set; }

    public RangeInclusiveness Inclusiveness { get; private set; } = RangeInclusiveness.BothInclusive;

    public void ParseDefinition(ReadOnlySpan<char> definition)
    {
        Reset();

        if (definition == null || definition.IsEmpty)
        {
            return;
        }

        var argList = definition.GetArgList(Name);
        if (argList.IsEmpty)
        {
            return;
        }

        var operands = new List<string>(4);
        if (!argList.TrySplitArgList(ref operands))
        {
            return;
        }

        if (operands.Count < 2 || operands.Count > 4)
        {
            return;
        }

        if (double.TryParse(operands[0], out var v1) && double.TryParse(operands[1], out var v2) && v1 < v2)
        {
            Operand1 = v1;
            Operand2 = v2;
            IsDiscrete = false;
        }
        else
        {
            return;
        }

        if (operands.Count > 2)
        {
            if (Enum.TryParse<RangeInclusiveness>(operands[2], out var inclusiveness))
                Inclusiveness = inclusiveness;
            else
                return;
        }

        if (operands.Count > 3)
        {
            if (bool.TryParse(operands[3], out var isDiscrete))
                IsDiscrete = isDiscrete;
            else
                return;
        }

        IsValid = true;

    }

    private void Reset()
    {
        IsValid = false;
        Operand1 = 0;
        Operand2 = 0;
        IsDiscrete = false;
        Inclusiveness = RangeInclusiveness.BothInclusive;
    }
}
