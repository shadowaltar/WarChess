using System.Reflection;

using Engine.Resources;

namespace WinDesktop;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.

        Assembly.Load("PixelHeroes3");
        Application.EnableVisualStyles();
        ApplicationConfiguration.Initialize();
        var mainForm = new MainForm();
        Application.Run(mainForm);
    }
}