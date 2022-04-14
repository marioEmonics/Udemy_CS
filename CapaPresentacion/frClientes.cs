
using CapaNegocio;  
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class frClientes : Form
    {

        CEnegocio CNCli=new CEnegocio();

        public frClientes()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpia();
        }


        private void Limpia()
        {
            txtId.Value = 0;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            pcbFoto.Image = null;

        }

        private void lnkFoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ofdFoto.FileName = String.Empty;
            

            if(ofdFoto.ShowDialog()== DialogResult.OK)
            {
                pcbFoto.Load(ofdFoto.FileName);

            }
            ofdFoto.FileName = String.Empty;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool resultado;
            CEClientes clientes=new CEClientes();
            clientes.Id= (int)txtId.Value;
            clientes.Nombre = txtNombre.Text;
            clientes.Apellido= txtApellido.Text;
            clientes.Foto = pcbFoto.ImageLocation;     
            resultado = CNCli.ValidaCliente(clientes);
            if (resultado == false)
            {
                return;
            }
           
            if (clientes.Id == 0)
            {
                CNCli.crearCliente(clientes);
            }
            else
            {
                CNCli.EditarCliente(clientes);
            }


            cargar();
            Limpia();
        }

        private void frClientes_Load(object sender, EventArgs e)
        {
            cargar();
        }


        private void cargar()
        {
            dataGridView1.DataSource = CNCli.obtenerDatos().Tables["tabla"];
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Value = (int)dataGridView1.CurrentRow.Cells["Id"].Value;
            txtNombre.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
            txtApellido.Text = dataGridView1.CurrentRow.Cells["apellido"].Value.ToString();
            pcbFoto.Load(dataGridView1.CurrentRow.Cells["foto"].Value.ToString());

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Value == 0) return;

            if (MessageBox.Show("¿Deseas Eliminar el Registro?", "Titulo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CEClientes cE = new CEClientes();
                cE.Id = (int)txtId.Value;
                CNCli.EliminarCliente(cE);
                cargar();
                Limpia();
            }

        }
    }
}