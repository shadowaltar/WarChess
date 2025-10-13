using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using Engine.Models.Abstracts;
using Engine.Visuals.Sprites;

using SkiaSharp;

using static System.Net.Mime.MediaTypeNames;

namespace Engine.Visuals;
public class SpriteToVisualJobHelper
{
    public AnimationClip ReadSpriteSheet(byte[] imageData,
        string spriteSetId,
        Coordinate2D sheetStartXY,
        Coordinate2D sheetEndXY,
        int rowCount,
        int colCount)
    {
        var width = (int)(sheetEndXY.X - sheetStartXY.X);
        var height = (int)(sheetEndXY.Y - sheetStartXY.Y);
        return null;
    }
}