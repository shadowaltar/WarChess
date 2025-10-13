using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Logic.Actions;
public class FormulaAction(string Name, params string[] Args) : BasicAction(Name, Args)
{
    public string Formula { get; set; }
}
