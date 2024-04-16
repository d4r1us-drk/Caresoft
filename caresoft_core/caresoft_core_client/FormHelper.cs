using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caresoft_core_client
{
    public static class FormHelper
    {
        public static void ErrorBox(string message)
        {
            MessageBox.Show(message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
        public static void InfoBox(string message)
        {
            MessageBox.Show(message, "Información", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }
        public static void WarningBox(string message)
        {
            MessageBox.Show(message, "Advertencia", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
        }
        public static void ConfirmBox(string message, Action onYes)
        {
            var result = MessageBox.Show(message, "Confirmación", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                onYes();
            }
        }
    }
}
