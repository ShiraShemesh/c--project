using BlApi;
using Dal;

namespace UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Initialization.Initialize();
            Application.Run(new MainForm());
        }
    }
}