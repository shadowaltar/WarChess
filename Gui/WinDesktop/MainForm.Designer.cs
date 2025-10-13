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
        skglControl1 = new SkiaSharp.Views.Desktop.SKGLControl();
        SuspendLayout();
        // 
        // skglControl1
        // 
        skglControl1.Dock = DockStyle.Fill;
        skglControl1.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
        skglControl1.APIVersion = new Version(3, 3, 0, 0);
        skglControl1.Flags = OpenTK.Windowing.Common.ContextFlags.Default;
        skglControl1.IsEventDriven = true;
        skglControl1.Location = new Point(217, 113);
        skglControl1.Name = "skglControl1";
        skglControl1.Profile = OpenTK.Windowing.Common.ContextProfile.Core;
        skglControl1.SharedContext = null;
        skglControl1.Size = new Size(358, 219);
        skglControl1.TabIndex = 0;
        skglControl1.PaintSurface += SkglControl1_PaintSurface;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(skglControl1);
        Name = "Form1";
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
}
