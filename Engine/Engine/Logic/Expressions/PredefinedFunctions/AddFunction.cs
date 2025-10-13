using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Logic.Expressions.PredefinedFunctions;
public class AddFunction
{
    public string Name => "Add";

    public string Operand1 { get; set; } = string.Empty;

    public string Operand2 { get; set; } = string.Empty;
}
