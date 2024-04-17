namespace caresoft_core_client.Utils;

public static class FormHelper
{
    public static void ErrorBox(string message)
    {
        MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    public static void InfoBox(string message)
    {
        MessageBox.Show(message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    public static void WarningBox(string message)
    {
        MessageBox.Show(message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
    public static void ConfirmBox(string message, Action onYes, string title = "Confirmacoin")
    {
        var result = MessageBox.Show(message, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
        {
            onYes();
        }
    }
}
