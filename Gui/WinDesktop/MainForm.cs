
using System.Drawing;

using Engine.Models.Abstracts;
using Engine.Resources;
using Engine.Visuals.Sprites;

using SkiaSharp;

namespace WinDesktop;

public partial class MainForm : Form
{
    private readonly ResourceManager _resourceManager;
    private readonly ResourceReader _resourceReader;
    private readonly HashSet<string> _imagePaths;
    private readonly Dictionary<string, string> _imageNamesToPaths = [];

    public MainForm()
    {
        InitializeComponent();
        _resourceManager = new ResourceManager();

        _resourceReader = new ResourceReader();
        _imagePaths = _resourceReader.ImagePaths;

        // show Framed only
        foreach(var path in _imagePaths)
        {
            if (!path.Contains("-Framed"))
                continue;
        }
        //var spriteDefinition = _resourceReader.

        //cbbSpriteImagePaths.Items.AddRange([.. _imagePaths]);

        //SpriteImageFrameParser.Parse()
        //foreach (var (key, imageBytes) in rr.ImageBytes)
        //{
        //    Draw(imageBytes, default, default);
        //    break;
        //}
    }

    internal void Draw(byte[] value, Coordinate2D topLeft, Coordinate2D bottomRight)
    {
        bitmap = SKBitmap.Decode(value);

        skglControl1.Refresh();
    }

    private void btnTest_Click(object sender, EventArgs e)
    {

    }
}
