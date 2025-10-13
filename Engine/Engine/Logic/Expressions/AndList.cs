using System.Text;

namespace Engine.Logic.Expressions;

public class AndList<T> : List<T>
{
    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var s in this)
        {
            if (sb.Length > 0)
                sb.Append(" AND ");
            sb.Append(s?.ToString());
        }
        return sb.ToString();
    }
}

public class StepByStepList<T>: AndList<T>
{
    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var s in this)
        {
            if (sb.Length > 0)
                sb.Append(" THEN ");
            sb.Append(s?.ToString());
        }
        return sb.ToString();
    }
}
