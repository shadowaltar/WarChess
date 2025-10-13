using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Engine.Logic.Actions;
using Engine.Logic.Expressions;

namespace Engine.Logic.States;
public class StateTransition
{
    public string From { get; set; }
    public string To { get; set; }
    public StateTransitionTrigger Trigger { get; set; }
    public AndList<string> Actions { get; set; }
    public StepByStepList<BasicAction> ParsedActions { get; set; }
}
