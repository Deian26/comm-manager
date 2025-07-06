using Communication_Manager;

namespace Communication_Manager
{
    internal static class Start
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new F0_Loading());
        }
    }
}