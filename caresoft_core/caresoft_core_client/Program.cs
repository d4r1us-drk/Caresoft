namespace caresoft_core_client
{
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
            ApplicationConfiguration.Initialize();
            string baseURL = "http://localhost:5143";


            // Create an instance of frmMain and frmLogin
            frmMain mainForm = new frmMain(baseURL);
            frmLogin loginForm = new frmLogin(baseURL);

            // Pass references to each other
            mainForm.SetLoginForm(loginForm);
            loginForm.SetMainForm(mainForm);

            // Run the login form
            Application.Run(loginForm);
        }
    }
}