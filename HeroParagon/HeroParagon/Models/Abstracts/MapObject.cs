using HeroParagon.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroParagon.Models.Abstracts;
public class MapObject : ModelBase
{
    public List<Modifier> Modifiers { get; set; } = new List<Modifier>(32);
}
