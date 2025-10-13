using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Engine.Models.Core;

namespace Engine.Models.Abstracts;
public class Actor : NamedObject, ITagged, IInheritable
{
    public List<string> Inherits { get; } = [];

    public List<string> Tags { get; } = [];
}
