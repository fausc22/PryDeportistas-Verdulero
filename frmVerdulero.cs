using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace PryDeportistas
{
    public partial class frmVerdulero : Form
    {
        public frmVerdulero()
        {
            InitializeComponent();
        }

        OleDbConnection cnn;
        OleDbCommand cmd;
        OleDbDataReader rdr;
        

        private void button1_Click(object sender, EventArgs e)
        {
            string conexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=VERDULEROS.mdb;";

            try
            {
                cnn = new OleDbConnection(conexion);
                cnn.Open();
                cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.TableDirect;
                cmd.CommandText = "Productos";
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    decimal precio = decimal.Parse(rdr[3].ToString());
                    decimal precioC = decimal.Parse(txtPrecio.Text);
                    if (precio > precioC)
                    {
                        dgvProductos.Rows.Add(int.Parse(rdr[0].ToString()), rdr[1], rdr[2], rdr[3]);
                    }
                }
                MessageBox.Show("Datos obtenidos!", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "", MessageBoxButtons.OK);

            }
        }
    }
}
