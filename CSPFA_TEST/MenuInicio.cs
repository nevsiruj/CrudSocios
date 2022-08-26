using Microsoft.Data.SqlClient;
using Microsoft.Data.Sql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using CapaNegocio;

namespace Prueba
{
    public partial class MenuInicio : Form
    {

        SocioBusiness objetoCN = new SocioBusiness();
        private string idProducto = "";       


        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        FrmTabla ft;
        public MenuInicio()
        {
            InitializeComponent();

        }


        private void MenuInicio_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tblDataSet.Socio' table. You can move, or remove it, as needed.

            //cn = new SqlConnection(@"Data Source = delli5\sqlexpress; Initial Catalog = tbl; TrustServerCertificate=True;Integrated Security = True"); ;
            //cn.Open();


            ViewAllSocios();

            //GetSociosRecord();

            //btnUpdate.Enabled = false;
            //btnDelete.Enabled = false;

        }


        public void ViewAllSocios()
        {
            SocioBusiness objeto = new SocioBusiness();
            dataGridSocios.DataSource = objeto.View();
        }

        //public void GetSociosRecord()
        //{
        //    cmd = new SqlCommand("SocioCrudOperations", cn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Employeeid", 0);
        //    cmd.Parameters.AddWithValue("@EmployeeName", "");
        //    cmd.Parameters.AddWithValue("@EmployeeSalary", 0);
        //    cmd.Parameters.AddWithValue("@EmployeeCity", "");
        //    cmd.Parameters.AddWithValue("@OperationType", "5");
        //    da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    dataGridView2.DataSource = dt;

        //}



        private void button2_Click(object sender, EventArgs e)
        {
            FrmTabla oFrmTabla = new FrmTabla();
            oFrmTabla.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            //this.dataGridSocios.DataSource = null;
            //this.dataGridSocios.Rows.Clear();
            //this.socioTableAdapter.Fill(this.tblDataSet.Socio);
        /*    this.dataGridSocios.DataSource = this.ViewAllSocios()*/;

            string searchValue = txtNombreFind.Text.ToLower();
            int rowIndex = -1;
        

            //dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dataGridSocios.Rows)
                {
                    if (row.Cells[2].Value.ToString().ToLower().Equals(searchValue))
                    {
                        rowIndex = row.Index;
                        dataGridSocios.Rows[row.Index].Selected = true;
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }


        }

        private void tblDataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void deleteSocioButton_Click(object sender, EventArgs e)
        {
            if (dataGridSocios.SelectedRows.Count > 0)
            {
                idProducto = dataGridSocios.CurrentRow.Cells["ID"].Value.ToString();
                objetoCN.Delete(idProducto);
                MessageBox.Show("Registro eliminado correctamente");
                ViewAllSocios();
            }
            else
                MessageBox.Show("Por favor debe seleccionar una fila");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridSocios.SelectedRows.Count > 0)
            {

                var idSocio = dataGridSocios.CurrentRow.Cells["ID"].Value.ToString();
                var nombre = dataGridSocios.CurrentRow.Cells["Nombre"].Value.ToString();
                var apellido = dataGridSocios.CurrentRow.Cells["Apellido"].Value.ToString();
                var direccion = dataGridSocios.CurrentRow.Cells["Direccion"].Value.ToString();
                var tipoDoc = dataGridSocios.CurrentRow.Cells["TipoDocumento"].Value.ToString();
                var documento = Convert.ToInt32(dataGridSocios.CurrentRow.Cells["Documento"].Value);
                var tipoSocio = dataGridSocios.CurrentRow.Cells["TipoSocio"].Value.ToString();
                var mail = dataGridSocios.CurrentRow.Cells["Mail"].Value.ToString();
                var telefonos = Convert.ToInt64(dataGridSocios.CurrentRow.Cells["Telefonos"].Value.ToString());

                FrmTabla oFrmTabla = new FrmTabla();
                oFrmTabla.EditarSocio(idSocio, nombre, apellido, direccion, tipoDoc, documento, tipoSocio, mail, telefonos);
                //ft.EditarSocio(idSocio);
                //mn.Editar = true;

            }
            else
                MessageBox.Show("Por favor debe seleccionar una fila");
        }

     
    }
}
