namespace HeroParagon.Models.Expressions;
public class Property : NamedObject
{
    public string StringValue { get; set; } = string.Empty;
    public double NumericValue { get; set; } = 0;
    public List<Property>? ChildValues { get; set; } = null;
    public Reference? ReferenceValue { get; set; }
}

public class StatefulProperty
{
    public Property? Current { get; set; } 
    public Property? Base { get; set; } 
    public Property? TemporaryBase { get; set; } 
}