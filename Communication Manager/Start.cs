using Communication_Manager;

namespace Communication_Manager
{
    internal static class Start
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        public static F1_CommunicationMainForm f1_CommMainForm = new F1_CommunicationMainForm();

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new F0_Loading());
        }
    }
}