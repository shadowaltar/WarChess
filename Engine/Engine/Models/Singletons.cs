using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Engine.Logic.Expressions;
using Engine.Models.Game;
using Engine.Models.Supportive;

namespace Engine.Models;
public class Singletons
{
    public World World { get; set; }

    public TitleScreen TitleScreen { get; set; }
}
