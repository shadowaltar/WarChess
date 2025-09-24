namespace HeroParagon.Models.Expressions;
public class NamedValue : NamedObject
{
    public string StringValue { get; set; } = string.Empty;
    public double NumericValue { get; set; } = 0;
    public List<NamedValue>? ChildValues { get; set; } = null;
    public Reference? ReferenceValue { get; set; }
}
