namespace Engine.Logic.Expressions.PredefinedFunctions;
public interface IFunction
{
    string Name { get; }

    void ParseDefinition(ReadOnlySpan<char> definition);

    bool IsValid { get; }
}
