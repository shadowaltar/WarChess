
using System.Drawing;

using Engine.Resources;

using SkiaSharp;

namespace WinDesktop;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        var rr = new ResourceReader();
        rr.ImageBytes
        using var s = new SKManagedStream()
        SKImage.FromPicture(SKPicture.Deserialize())
        Draw(ResourceReader.ImageBytes.FirstOrDefault().Value);
    }

    internal void Draw(byte[] value)
    {
        bitmap = SKBitmap.Decode(value);
        skglControl1.Refresh();
    }
}
