namespace caresoft_core_client
{
    internal static class Program
    {
        private static readonly string baseUrl = "http://localhost:5143";
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();


            // Create an instance of frmMain and frmLogin
            frmMain mainForm = new frmMain(baseUrl);
            frmLogin loginForm = new frmLogin(baseUrl);


            // Pass references to each other
            mainForm.SetLoginForm(loginForm);
            loginForm.SetMainForm(mainForm);

            // Run the login form
            Application.Run(loginForm);
        }
    }
}