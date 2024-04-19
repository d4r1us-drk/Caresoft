using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajaHospital.views
{
    public partial class ReciboCuadre : Form
    {
        private List<CuadreDto> _cuadres = new List<CuadreDto>();
        public ReciboCuadre()
        {
            InitializeComponent();
        }

        private void ReciboCuadre_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader dr = null;
            CuadreDto cuadre = null;

            try
            {
                conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["vendingLocal"].ConnectionString);
                conn.Open();
                cmd = new MySqlCommand("spGetCuadres", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p_idSucursal", Convert.ToUInt32(ConfigurationManager.AppSettings["noCaja"]));

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cuadre = new CuadreDto();

                    cuadre.DocumentoCajero = dr.GetString("documentoCajero");
                    cuadre.IdCuadre = dr.GetUInt32("idCuadre");
                    cuadre.IdSucursal = dr.GetUInt32("idSucursal");
                    cuadre.MontoDescargado = dr.GetDecimal("montoDescargado");
                    cuadre.Fecha = dr.GetDateTime("fecha");

                    _cuadres.Add(cuadre);

                }

                conn.Close();

                rptCuadres.LocalReport.DataSources.Clear();
                rptCuadres.LocalReport.DataSources.Add(new ReportDataSource("dsCuadres", _cuadres));
                rptCuadres.LocalReport.Refresh();

            }
            catch (Exception)
            {
                MessageBox.Show("Error al solicitar el reporte de los cuadres");
                throw;
            }


            this.rptCuadres.RefreshReport();
        }
    }
}
