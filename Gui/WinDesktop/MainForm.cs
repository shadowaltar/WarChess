
using System.Drawing;

using Engine.Models.Abstracts;
using Engine.Resources;

using SkiaSharp;

namespace WinDesktop;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        var rr = new ResourceReader();
        foreach (var (key, imageBytes) in rr.ImageBytes)
        {
            Draw(imageBytes, null, null);
            break;
        }
    }

    internal void Draw(byte[] value, Coordinate2D topLeft, Coordinate2D bottomRight)
    {
        bitmap = SKBitmap.Decode(value);
        skglControl1.Refresh();
    }
}
