using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajaHospital.views
{
    public partial class PagoControl : Form
    {
        private readonly decimal _monto;
        private readonly decimal _montoAcumulado;
        private Dictionary<int, int> cantidadDenominaciones = new Dictionary<int,int>();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public PagoControl(decimal montoTotal)
        {
            InitializeComponent();
            _monto = montoTotal;
            txtMonto.Text = montoTotal.ToString();
            cantidadDenominaciones.Add(2000, 0);
            cantidadDenominaciones.Add(1000, 0);
            cantidadDenominaciones.Add(500, 0);
            cantidadDenominaciones.Add(200, 0);
            cantidadDenominaciones.Add(100, 0);
            cantidadDenominaciones.Add(50, 0);
            cantidadDenominaciones.Add(25, 0);
            cantidadDenominaciones.Add(10, 0);
            cantidadDenominaciones.Add(5, 0);
            cantidadDenominaciones.Add(1, 0);
        }

        private void calcularTotales()
        {
            int total = 0;

            foreach ( KeyValuePair<int,int> cantidad in cantidadDenominaciones )
            {
                total += cantidad.Key * cantidad.Value;
            }

            if (total > _monto)
            {
                throw new Exception("El total acumulado es mayor que el monto de la factura");
            } else if ( total == _monto )
            {
                btnCambiosMonedas.Enabled = true;
            }

            txtAcumulado.Text = total.ToString();
        }

        private void n2000_ValueChanged(object sender, EventArgs e)
        {
            int denominacion = 2000;
            int cantidadNueva = (int)n2000.Value;
            int cantidadPrevia = cantidadDenominaciones[denominacion];
            int valorDenominacion;

            cantidadDenominaciones[denominacion] = cantidadNueva;

            try
            {
                calcularTotales();
                valorDenominacion = denominacion * cantidadNueva;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                cantidadDenominaciones[denominacion] = cantidadPrevia;
                n2000.Value = cantidadPrevia;
                return;
            }

            string v = valorDenominacion.ToString();
            lbl2k.Text = v;
        }

        private void n1000_ValueChanged(object sender, EventArgs e)
        {
            int denominacion = 1000;
            int cantidadNueva = (int)n1000.Value;
            int cantidadPrevia = cantidadDenominaciones[denominacion];
            int valorDenominacion;

            cantidadDenominaciones[denominacion] = cantidadNueva;

            try
            {
                calcularTotales();
                valorDenominacion = denominacion * cantidadNueva;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                cantidadDenominaciones[denominacion] = cantidadPrevia;
                n1000.Value = cantidadPrevia;
                return;
            }

            string v = valorDenominacion.ToString();
            lbl1k.Text = v;
        }

        private void n500_ValueChanged(object sender, EventArgs e)
        {
            int denominacion = 500;
            int cantidadNueva = (int)n500.Value;
            int cantidadPrevia = cantidadDenominaciones[denominacion];
            int valorDenominacion;

            cantidadDenominaciones[denominacion] = cantidadNueva;

            try
            {
                calcularTotales();
                valorDenominacion = denominacion * cantidadNueva;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                cantidadDenominaciones[denominacion] = cantidadPrevia;
                n1000.Value = cantidadPrevia;
                return;
            }

            string v = valorDenominacion.ToString();
            lbl500.Text = v;
        }

        private void n200_ValueChanged(object sender, EventArgs e)
        {
            int denominacion = 200;
            int cantidadNueva = (int)n200.Value;
            int cantidadPrevia = cantidadDenominaciones[denominacion];
            int valorDenominacion;

            cantidadDenominaciones[denominacion] = cantidadNueva;

            try
            {
                calcularTotales();
                valorDenominacion = denominacion * cantidadNueva;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                cantidadDenominaciones[denominacion] = cantidadPrevia;
                n1000.Value = cantidadPrevia;
                return;
            }

            string v = valorDenominacion.ToString();
            lbl200.Text = v;
        }

        private void n100_ValueChanged(object sender, EventArgs e)
        {
            int denominacion = 100;
            int cantidadNueva = (int)n100.Value;
            int cantidadPrevia = cantidadDenominaciones[denominacion];
            int valorDenominacion;

            cantidadDenominaciones[denominacion] = cantidadNueva;

            try
            {
                calcularTotales();
                valorDenominacion = denominacion * cantidadNueva;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                cantidadDenominaciones[denominacion] = cantidadPrevia;
                n1000.Value = cantidadPrevia;
                return;
            }

            string v = valorDenominacion.ToString();
            lbl100.Text = v;
        }

        private void n50_ValueChanged(object sender, EventArgs e)
        {
            int denominacion = 50;
            int cantidadNueva = (int)n50.Value;
            int cantidadPrevia = cantidadDenominaciones[denominacion];
            int valorDenominacion;

            cantidadDenominaciones[denominacion] = cantidadNueva;

            try
            {
                calcularTotales();
                valorDenominacion = denominacion * cantidadNueva;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                cantidadDenominaciones[denominacion] = cantidadPrevia;
                n1000.Value = cantidadPrevia;
                return;
            }

            string v = valorDenominacion.ToString();
            lbl50.Text = v;
        }

        private void n25_ValueChanged(object sender, EventArgs e)
        {
            int denominacion = 25;
            int cantidadNueva = (int)n25.Value;
            int cantidadPrevia = cantidadDenominaciones[denominacion];
            int valorDenominacion;

            cantidadDenominaciones[denominacion] = cantidadNueva;

            try
            {
                calcularTotales();
                valorDenominacion = denominacion * cantidadNueva;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                cantidadDenominaciones[denominacion] = cantidadPrevia;
                n1000.Value = cantidadPrevia;
                return;
            }

            string v = valorDenominacion.ToString();
            lbl25.Text = v;
        }

        private void n10_ValueChanged(object sender, EventArgs e)
        {
            int denominacion = 10;
            int cantidadNueva = (int)n10.Value;
            int cantidadPrevia = cantidadDenominaciones[denominacion];
            int valorDenominacion;

            cantidadDenominaciones[denominacion] = cantidadNueva;

            try
            {
                calcularTotales();
                valorDenominacion = denominacion * cantidadNueva;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                cantidadDenominaciones[denominacion] = cantidadPrevia;
                n1000.Value = cantidadPrevia;
                return;
            }

            string v = valorDenominacion.ToString();
            lbl10.Text = v;
        }

        private void n5_ValueChanged(object sender, EventArgs e)
        {
            int denominacion = 5;
            int cantidadNueva = (int)n5.Value;
            int cantidadPrevia = cantidadDenominaciones[denominacion];
            int valorDenominacion;

            cantidadDenominaciones[denominacion] = cantidadNueva;

            try
            {
                calcularTotales();
                valorDenominacion = denominacion * cantidadNueva;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                cantidadDenominaciones[denominacion] = cantidadPrevia;
                n1000.Value = cantidadPrevia;
                return;
            }

            string v = valorDenominacion.ToString();
            lbl5.Text = v;
        }

        private void n1_ValueChanged(object sender, EventArgs e)
        {
            int denominacion = 1;
            int cantidadNueva = (int)n1.Value;
            int cantidadPrevia = cantidadDenominaciones[denominacion];
            int valorDenominacion;

            cantidadDenominaciones[denominacion] = cantidadNueva;

            try
            {
                calcularTotales();
                valorDenominacion = denominacion * cantidadNueva;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                cantidadDenominaciones[denominacion] = cantidadPrevia;
                n1000.Value = cantidadPrevia;
                return;
            }

            string v = valorDenominacion.ToString();
            lbl1.Text = v;
        }

        private void btnCambiosMonedas_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["vendingLocal"].ConnectionString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("spIngresarDenominaciones", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("p_2000", (int)n2000.Value);
                cmd.Parameters.AddWithValue("p_1000", (int)n1000.Value);
                cmd.Parameters.AddWithValue("p_500", (int)n500.Value);
                cmd.Parameters.AddWithValue("p_200", (int)n200.Value);
                cmd.Parameters.AddWithValue("p_100", (int)n100.Value);
                cmd.Parameters.AddWithValue("p_50", (int)n50.Value);
                cmd.Parameters.AddWithValue("p_25", (int)n25.Value);
                cmd.Parameters.AddWithValue("p_10", (int)n10.Value);
                cmd.Parameters.AddWithValue("p_5", (int)n5.Value);
                cmd.Parameters.AddWithValue("p_1", (int)n1.Value);

                log.Info("Ingresando denominaciones...");
                cmd.ExecuteNonQuery();
                log.Info("Denominaciones ingresadas");
                conn.Close();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                log.Error("Algo salio mal", ex);
                MessageBox.Show(ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                this.DialogResult = DialogResult.Cancel;
                throw;
            }
        }
    }
}
