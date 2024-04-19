using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajaHospital
{
    internal static class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Info("Configuracion del servicio de registros conpletada");
            log.Info("Preparandose para correr el sistema de caja...");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            log.Info("Sistema de caja corriendo correctamente");
            Application.Run(new Login());
            log.Info("Sistema de caja apagado correctamente");
        }
    }
}
