using System.Text.Json;

using Engine.Resources;

namespace Engine.Logic.States;
public class StateMachines
{
    public Dictionary<string, StateMachine> Machines { get; } = new();

    public void Initialize(ResourceManager rm)
    {
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var fileContents = rm.GetTextFiles("States");

        foreach (var content in fileContents.Values)
        {
            var states = JsonSerializer.Deserialize<List<State>>(content, options);
            if (states == null) { continue; }
            foreach (var routine in states.Select(s => s.Routine).Where(s => s != null))
            {
                if (!Machines.TryGetValue(routine, out var machine))
                {
                    var stateMachine = new StateMachine(routine);
                    Machines[routine] = stateMachine;
                }
            }
        }

        fileContents = rm.GetTextFiles("Transitions");
        foreach (var content in fileContents.Values)
        {
            var trans = JsonSerializer.Deserialize<List<StateTransition>>(content, options);
            foreach (var t in trans)
            {
                if (Machines.TryGetValue(t.From, out var machine))
                {
                    machine.Transitions.Add(t);
                }
            }
        }
    }
}
