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
    public partial class frmDeporte : Form
    {
        public frmDeporte()
        {
            InitializeComponent();
        }

        OleDbConnection cnn;
        OleDbCommand cmd;
        OleDbDataReader rdr;

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnObtener_Click(object sender, EventArgs e)
        {
            string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DEPORTE.accdb;";
            try
            {
                cnn = new OleDbConnection(conexion);
                cnn.Open();
                cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.TableDirect;
                cmd.CommandText = "DEPORTISTA";
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    dgvDeportista.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6]);
                    
                }

                MessageBox.Show("Datos obtenidos!", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "", MessageBoxButtons.OK);
                
            }
        }

        private void btnObtenerE_Click(object sender, EventArgs e)
        {
            string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DEPORTE.accdb;";
            try
            {
                cnn = new OleDbConnection(conexion);
                cnn.Open();
                cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.TableDirect;
                cmd.CommandText = "ENTRENADORES";
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    dgvEntrenador.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]);

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
