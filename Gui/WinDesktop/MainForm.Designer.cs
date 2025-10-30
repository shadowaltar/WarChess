using System.Drawing;

using OpenTK.GLControl;

using SkiaSharp;
using SkiaSharp.Views.Desktop;

namespace WinDesktop;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        skglControl1 = new SKGLControl();
        btnTest = new Button();
        cbbSpriteImagePaths = new ComboBox();
        cbbSpriteStates = new ComboBox();
        SuspendLayout();
        // 
        // skglControl1
        // 
        skglControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        skglControl1.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
        skglControl1.APIVersion = new Version(3, 3, 0, 0);
        skglControl1.Flags = OpenTK.Windowing.Common.ContextFlags.Default;
        skglControl1.IsEventDriven = true;
        skglControl1.Location = new Point(12, 41);
        skglControl1.Name = "skglControl1";
        skglControl1.Profile = OpenTK.Windowing.Common.ContextProfile.Core;
        skglControl1.SharedContext = null;
        skglControl1.Size = new Size(776, 397);
        skglControl1.TabIndex = 0;
        skglControl1.PaintSurface += SkglControl1_PaintSurface;
        // 
        // btnTest
        // 
        btnTest.Location = new Point(713, 10);
        btnTest.Name = "btnTest";
        btnTest.Size = new Size(75, 23);
        btnTest.TabIndex = 1;
        btnTest.Text = "Test";
        btnTest.UseVisualStyleBackColor = true;
        btnTest.Click += btnTest_Click;
        // 
        // cbbSpriteImagePaths
        // 
        cbbSpriteImagePaths.FormattingEnabled = true;
        cbbSpriteImagePaths.Location = new Point(12, 10);
        cbbSpriteImagePaths.Name = "cbbSpriteImagePaths";
        cbbSpriteImagePaths.Size = new Size(438, 25);
        cbbSpriteImagePaths.TabIndex = 2;
        // 
        // cbbSpriteStates
        // 
        cbbSpriteStates.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        cbbSpriteStates.FormattingEnabled = true;
        cbbSpriteStates.Location = new Point(456, 10);
        cbbSpriteStates.Name = "cbbSpriteStates";
        cbbSpriteStates.Size = new Size(251, 25);
        cbbSpriteStates.TabIndex = 3;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(cbbSpriteStates);
        Controls.Add(cbbSpriteImagePaths);
        Controls.Add(btnTest);
        Controls.Add(skglControl1);
        Name = "MainForm";
        Text = "Form1";
        ResumeLayout(false);
    }

    private SKBitmap? bitmap;

    private void SkglControl1_PaintSurface(object sender, SKPaintGLSurfaceEventArgs e)
    {
        var canvas = e.Surface.Canvas;
        canvas.Clear(SKColors.White);
        var destRect = new SKRect(12, 50, skglControl1.Width, skglControl1.Height);

        if (bitmap != null)
        {
            // Draw the bitmap to fill the control
            canvas.DrawBitmap(bitmap, destRect, destRect);
        }
    }

    #endregion

    private SkiaSharp.Views.Desktop.SKGLControl skglControl1;
    private Button btnTest;
    private ComboBox cbbSpriteImagePaths;
    private ComboBox cbbSpriteStates;
}
