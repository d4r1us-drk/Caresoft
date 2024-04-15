﻿using MySql.Data.MySqlClient;
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
using System.Xml.Linq;
using static CajaHospital.Main;
using static CajaHospital.views.RegistrarPaciente;
using static Mysqlx.Crud.Order.Types;

namespace CajaHospital.views
{
    public partial class FacturarView : UserControl
    {
        readonly char _tipoFactura;
        private Dictionary<string, string> servicios = new Dictionary<string, string>();
        private Dictionary<string, int> servicios_costos = new Dictionary<string, int>();
        private Dictionary<string, int> productos = new Dictionary<string, int>();
        private Dictionary<int, int> productos_costos = new Dictionary<int, int>();
        public FacturarView( char tipoFactura )
        {
            InitializeComponent();
            _tipoFactura = tipoFactura;
        }

        private void FacturarView_Load(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;
            btnRemover.Enabled = false;
            btnCrearFactura.Enabled = false;

            switch (_tipoFactura)
            {
                case 'E':
                    lblTitulo.Text = "Generar factura para paciente";
                    chkRecarga.Checked = false;
                    chkRecarga_CheckedChanged(sender, e);

                    try
                    {
                        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["vendingLocal"].ConnectionString);
                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand("spServicioListar", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();

                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            servicios.Add(reader.GetString("nombre"), reader.GetString("servicioCodigo"));
                            servicios_costos.Add(reader.GetString("servicioCodigo"), reader.GetInt32("costo"));
                        }
                        foreach (var item in servicios )
                        {
                            lsbDisponibles.Items.Add(item.Key);
                        }

                        conn.Close();
                        
                        conn.Open();

                        cmd = new MySqlCommand("spProductoListar", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@p_costo", null);

                        reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            productos.Add(reader.GetString("nombre"), reader.GetInt32("idProducto"));
                            productos_costos.Add(reader.GetInt32("idProducto"), reader.GetInt32("costo"));
                        }
                        foreach (var item in productos)
                        {
                            lsbDisponibles.Items.Add(item.Key);
                        }

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Algo salió mal", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MessageBox.Show(ex.Message, ex.Source);
                    };

                    break;
                case 'C':
                    lblTitulo.Text = "Cargar o recargar la caja";
                    chkRecarga.Checked = true;
                    chkRecarga_CheckedChanged(sender, e);
                    break;
                default:
                    break;
            }

        }


        //Manejador del evento de la creacion de la cuenta de un nuevo paciente
        private void CuentaLista(object sender, EventArgs e )
        {
            if ( e is CuentaListaArgs eventArgs)
            {
                txtDoc.Text = eventArgs.Documento;
                cboTipoDoc.SelectedIndex = eventArgs.TipoDoc == 'I' ? 1 : 2;
                txtDoc.ReadOnly = true;
                cboTipoDoc.Enabled = false;
            }
        }

        private string CalcularSubtotal()
        {
            string seleccionado;
            int subtotal = 0;

            foreach (var item in lsbSeleccionados.Items)
            {
                seleccionado = item.ToString();

                if (servicios.ContainsKey(seleccionado))
                {
                    subtotal += servicios_costos[servicios[seleccionado]];
                }
                else
                {
                    subtotal += productos_costos[productos[seleccionado]];
                }
            }

            return subtotal.ToString();
        }

        private void chkRecarga_CheckedChanged(object sender, EventArgs e)
        {
            if ( chkRecarga.Checked)
            {
                rbnDescarga.Enabled = true;
                rbnRecarga.Enabled = true;
                txtDoc.Enabled = false;
                cboTipoDoc.Enabled = false;
                lsbDisponibles.Enabled = false;
                lsbSeleccionados.Enabled = false;
                txtPrecio.Enabled = false;
                cboAseguradora.Enabled = false;
                btnAgregar.Enabled = false;
                btnRemover.Enabled = false;
                txtSubtotal.Enabled = true;
                txtSubtotal.ReadOnly = false;
                btnCrearFactura.Text = rbnRecarga.Checked ? "Recargar caja" : "Descargar caja";
            } else
            {
                rbnDescarga.Enabled = false;
                rbnRecarga.Enabled = false;
                txtDoc.Enabled = true;
                cboTipoDoc.Enabled = true;
                lsbDisponibles.Enabled = true;
                lsbSeleccionados.Enabled = true;
                txtPrecio.Enabled = true;
                txtPrecio.ReadOnly = true;
                txtSubtotal.Enabled = true;
                txtSubtotal.ReadOnly = true;
                cboAseguradora.Enabled = true;
                btnCrearFactura.Text = "Crear factura";
            }
        }

        private void rbnRecarga_CheckedChanged(object sender, EventArgs e)
        {
            btnCrearFactura.Text = rbnRecarga.Checked ? "Recargar caja" : "Descargar caja";
        }

        private void lsbDisponibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAgregar.Enabled = true;

            string seleccionado = lsbDisponibles.SelectedItem.ToString();

            if (servicios.ContainsKey(seleccionado))
            {
                txtPrecio.Text = servicios_costos[servicios[seleccionado]].ToString();
            } else
            {
                txtPrecio.Text = productos_costos[productos[seleccionado]].ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            lsbSeleccionados.Items.Add(lsbDisponibles.SelectedItem.ToString());
            txtSubtotal.Text = CalcularSubtotal();
            btnCrearFactura.Enabled = true;
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            lsbSeleccionados.Items.RemoveAt(lsbDisponibles.SelectedIndex);
            txtSubtotal.Text = CalcularSubtotal();
        }

        private void lsbSeleccionados_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemover.Enabled = true;
        }
    }
}
