using CapaNegocio;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Prueba
{
    public partial class FrmTabla : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        MenuInicio mn;
        SocioBusiness socioBusiness = new SocioBusiness();
        SocioContactoBusiness socioContactoBusiness = new SocioContactoBusiness();
        private bool Editar = false;
        private string socioId = "";
        public FrmTabla()
        {
            InitializeComponent();

            cn = new SqlConnection(@"Data Source = delli5\sqlexpress; Initial Catalog = tbl; TrustServerCertificate=True;Integrated Security = True"); ;
            cn.Open();


            cmbTipoDocumento.Items.Add("DNI");
            cmbTipoDocumento.Items.Add("Libreta de Enrolamiento");
            cmbTipoSocio.Items.Add("Vitalicio");
            cmbTipoSocio.Items.Add("Regular");
            cmbTipoSocio.Items.Add("No Socio");
        
        }

        private void ClearControls()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtNumeroDocumento.Clear();
            txtTelefonos.Clear();
            txtEmail.Clear();
            cmbTipoDocumento.Text = "";
            cmbTipoSocio.Text = "";
        }

        public void EditarSocio(string id, string nombre, string apellido, string direccion, string tipoDocId, int documento, string tipoSocioId, string mail, long telefonos)
        {
            this.Editar = true;

            this.Show();
            this.socioId = id;
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtDireccion.Text = direccion;
            cmbTipoDocumento.Text = tipoDocId;
            txtNumeroDocumento.Text = documento.ToString();
            cmbTipoSocio.Text = tipoSocioId;
            txtEmail.Text = mail;
            txtTelefonos.Text = telefonos.ToString();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    //Validación de controles
                    if (txtNombre.Text == "")
                    {
                        MessageBox.Show("Falta Ingresar el Nombre", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNombre.Focus();
                        return;
                    }
                    if (txtApellido.Text == "")
                    {
                        MessageBox.Show("Falta Ingresar el Apellido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtApellido.Focus();
                        return;
                    }
                    if (txtDireccion.Text == "")
                    {
                        MessageBox.Show("Falta Ingresar la Direccion", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDireccion.Focus();
                        return;
                    }
                    if (cmbTipoDocumento.Text == "")
                    {
                        MessageBox.Show("Falta Ingresar el Número de Documento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbTipoDocumento.Focus();
                        return;
                    }
                    if (txtNumeroDocumento.Text == "")
                    {
                        MessageBox.Show("Falta Ingresar el Numero de Documento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNumeroDocumento.Focus();
                        return;
                    }
                    if (cmbTipoSocio.Text == "")
                    {
                        MessageBox.Show("Falta Ingresar el Tipo de Socio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbTipoSocio.Focus();
                        return;
                    }
                    if (txtEmail.Text == "")
                    {
                        MessageBox.Show("Falta Ingresar el Email", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtEmail.Focus();
                        return;
                    }
                    if (txtTelefonos.Text == "")
                    {
                        MessageBox.Show("Falta Ingresar el Número de Telefono", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTelefonos.Focus();
                        return;
                    }


                    socioBusiness.Create(txtNombre.Text, txtApellido.Text, txtDireccion.Text, cmbTipoDocumento.Text, Convert.ToInt32(txtNumeroDocumento.Text), cmbTipoSocio.Text, txtEmail.Text, Convert.ToInt32(txtTelefonos.Text));
                  
                    MessageBox.Show("Se guardo correctamente");

                    MenuInicio obj = (MenuInicio)Application.OpenForms["MenuInicio"];
                    obj.ViewAllSocios();

                    ClearControls();
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos, se encontro el siguiente error : " + ex);
                }
            }

            if (Editar == true)
            {

                try
                {
                    socioBusiness.Update(socioId, txtNombre.Text, txtApellido.Text, txtDireccion.Text, cmbTipoDocumento.Text, Convert.ToInt32(txtNumeroDocumento.Text), cmbTipoSocio.Text, txtEmail.Text, Convert.ToInt32(txtTelefonos.Text));
                    MessageBox.Show("Registro actualizado correctamente");
                    ClearControls();
                    Editar = false;
                    this.socioId = "";

                    MenuInicio obj = (MenuInicio)Application.OpenForms["MenuInicio"];
                    obj.ViewAllSocios();

                    ClearControls();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos, se encontro el siguiente error : " + ex);
                }
            }





            //    ////using(CrudEntities db = CrudEntities)
            //    //if (
            //    //    txtNombre.Text != string.Empty 
            //    //    //&&
            //    //    //txtApellido.Text != string.Empty && 
            //    //    //txtDireccion.Text != string.Empty &&
            //    //    //cmbTipoDocumento.Text != string.Empty &&
            //    //    //txtNumeroDocumento.Text != string.Empty &&
            //    //    //cmbTipoSocio.Text != string.Empty &&
            //    //    //txtEmail.Text != string.Empty
            //    //    )
            //    //{
            //    //    var guid = System.Guid.NewGuid().ToString();
            //    //    var guidSocio = System.Guid.NewGuid().ToString();
            //    //    var guidSocioContacto = System.Guid.NewGuid().ToString();

            //    //    cmd = new SqlCommand("SocioCrudOperations", cn);
            //    //    cmd.CommandType = CommandType.StoredProcedure;
            //    //    cmd.Parameters.AddWithValue("@Id", guid);
            //    //    cmd.Parameters.AddWithValue("@IdSocioContacto", guidSocioContacto);
            //    //    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
            //    //    cmd.Parameters.AddWithValue("@Apellido", txtApellido.Text);
            //    //    cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
            //    //    cmd.Parameters.AddWithValue("@TipoDocumento", "b06923ff-6d76-4774-b250-975484110f13");
            //    //    cmd.Parameters.AddWithValue("@NumeroDocumento", txtNumeroDocumento.Text);
            //    //    cmd.Parameters.AddWithValue("@TipoSocio", "9d6ee309-e42d-4f86-ab61-939bfc6ee062");
            //    //    cmd.Parameters.AddWithValue("@FechaAlta", DateTime.Now);
            //    //    cmd.Parameters.AddWithValue("@Telefonos", txtTelefonos.Text);
            //    //    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            //    //    cmd.Parameters.AddWithValue("@OperationType", "1");
            //    //    cmd.ExecuteNonQuery();
            //    //    MessageBox.Show("Record inserted successfully.", "Record Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //    //mn.GetSociosRecord();
            //    //    txtNombre.Text = "";
            //    //    txtApellido.Text = "";
            //    //    txtDireccion.Text = "";
            //    //    txtNumeroDocumento.Text = "";
            //    //}
            //    //else
            //    //{
            //    //    MessageBox.Show("Please enter value in all fields", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //}


        }


    }
}
