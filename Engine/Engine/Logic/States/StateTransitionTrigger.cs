using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Engine.Logic.Expressions;

namespace Engine.Logic.States;
public record StateTransitionTrigger
{
    public string Type { get; set; }
    public AndList<string> Conditions { get; set; }
    public AndList<Condition> ParsedConditions { get; set; }
}

public record GuiActionTrigger : StateTransitionTrigger
{

}

public record EventTrigger : StateTransitionTrigger
{

}