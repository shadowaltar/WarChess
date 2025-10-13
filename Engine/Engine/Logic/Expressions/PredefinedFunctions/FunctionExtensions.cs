using Engine.Logic.Expressions;
using Engine.Models.Core;

namespace Engine.Logic.Expressions.PredefinedFunctions;
public static class FunctionExtensions
{
    public static bool IsValidArgList(this ReadOnlySpan<char> expression)
    {
        expression = expression.Trim();
        return !expression.IsEmpty && expression[0] == Consts.ArgListStart && expression[^1] == Consts.ArgListEnd;
    }

    public static ReadOnlySpan<char> GetArgList(this ReadOnlySpan<char> expression, string functionName)
    {
        expression = expression.Trim();
        if (!expression.StartsWith(functionName, StringComparison.OrdinalIgnoreCase))
        {
            return [];
        }
        expression = expression[functionName.Length..].Trim();
        if (!expression.IsEmpty && expression[0] == Consts.ArgListStart && expression[^1] == Consts.ArgListEnd)
        {
            return expression[1..^1].Trim();
        }
        return [];
    }

    public static bool TrySplitArgList(this ReadOnlySpan<char> remaining, ref List<string> operands)
    {
        if (!remaining.IsEmpty)
        {
            int i = remaining.IndexOf(Consts.ArgDelimiter);
            ReadOnlySpan<char> token = i < 0 ? remaining.Trim() : remaining[..i].Trim();
            ReadOnlySpan<char> rest = i < 0 ? [] : remaining[(i + 1)..];

            operands.Add(token.ToString());

            if (!rest.IsEmpty)
            {
                if (!rest.TrySplitArgList(ref operands))
                {
                    return false;
                }
            }
            if (operands.Count > Consts.MaxFunctionArgCount)
            {
                operands.Clear();
                return false;
            }
        }
        return true;
    }


    public static Reference ParseReference(this ReadOnlySpan<char> expression)
    {
        expression = expression.Trim();
        if (expression.IsEmpty)
        {
            return null;
        }
        // TODO
        var i = expression.IndexOf(Consts.Membership);
        if (i == -1)
        {
            return expression.ParseKeywordReference();
        }
        return null;
    }

    private static Reference ParseKeywordReference(this ReadOnlySpan<char> expression)
    {
        if (expression == Consts.Self)
        {
            return Reference.Self;
        }

        // TODO
        var strExpression = expression.ToString();
        if (Repositories.Keywords.TryGet(strExpression, out var r))
        {
            // look up from caller's reference repository
            return r;
        }
        return null;
    }


    public static Property ParseNamedValue(this ReadOnlySpan<char> expression)
    {
        // must not be a list of values
        expression = expression.Trim();
        if (expression.IsEmpty)
        {
            return null;
        }
        // array values
        // pure string value, must be quoted

        // numeric value

        // reference
        return null;
    }
}
