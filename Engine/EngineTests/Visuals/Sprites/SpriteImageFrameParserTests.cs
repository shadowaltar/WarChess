using NUnit.Framework;
using Engine.Visuals.Sprites;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Visuals.Sprites.Tests;

[TestFixture()]
public class SpriteImageFrameParserTests
{
    [Test()]
    public void ParseTest()
    {
        SpriteImageFrameParser.Parse(@"D:\Projects\WarChess\Game\PixelHeroes3\Resources\Sprites\AllStates-Archangel.Framed.png");
    }
}