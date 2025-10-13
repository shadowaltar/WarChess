namespace Engine.Logic.States;
public class StateMachine(string Name)
{
    public HashSet<StateTransition> Transitions { get; } = [];
}
