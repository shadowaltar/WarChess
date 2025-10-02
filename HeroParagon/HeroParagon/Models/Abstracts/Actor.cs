using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HeroParagon.Models.Core;

namespace HeroParagon.Models.Abstracts;
public class Actor : NamedObject, ITagged, IInheritable
{
    public List<string> Inherits { get; } = [];

    public List<string> Tags { get; } = [];
}
