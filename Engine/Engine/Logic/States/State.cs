using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Logic.States;
public record State
{
    public string Name { get; set; }
    public string Routine { get; set; }
    public string Comment { get; set; }
}
