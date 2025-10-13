using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Logic.Expressions;
public class Reference
{
    public bool IsSelf { get; private set; }
    public static Reference Self { get; } = new Reference { IsSelf = true };
}
