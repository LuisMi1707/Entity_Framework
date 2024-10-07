using AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFDemo
{
    public partial class Form1 : Form
    {
        private CustomerRepository cr = new CustomerRepository();
        public Form1()
        {
            InitializeComponent();
        }
      
        private void btnObtenerTodos_Click(object sender, EventArgs e)
        {
            var cliente = cr.ObtenerTodos();
            dgvCustomers.DataSource = cliente;
        }
        #region ObtenerPorID
        private void btnTodo_Click(object sender, EventArgs e)
        {
            var cliente =cr.ObtenerPorID(txbObtenerTodos.Text);
            List<Customers> lista1 = new List<Customers> { cliente };
            if (cliente != null)
            {
                llenarCampos(cliente);

            }
            dgvCustomers.DataSource = lista1;
        }
        #endregion

        #region InsertarCliente
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var cliente = CrearCliente();
            var resultado = cr.InsertarCliente(cliente);
            MessageBox.Show($"Se inserto {resultado}");
        }

        private Customers CrearCliente()
        {
            var cliente = new Customers
            {
                CustomerID = txbCustomerID.Text,
                CompanyName = txbCompanyName.Text,
                ContactName = txbContactName.Text,
                ContactTitle = txbContactTitle.Text,
                Address = txbAddress.Text,
            };
            return cliente;

        }
        #endregion

        #region ActualizarCliente
        private void llenarCampos(Customers customers)
        {
            txbCustomerID.Text = customers.CustomerID;
            txbCompanyName.Text = customers.CompanyName;
            txbContactName.Text = customers.ContactName;
            txbContactTitle.Text = customers.ContactTitle;
            txbAddress.Text = customers.Address;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var cliente = CrearCliente();
            cr.UpdateCliente(cliente);
            var resultado = cr.ObtenerPorID(cliente.CustomerID);
            List<Customers> lista1 = new List<Customers>
            {
                resultado
            };
            dgvCustomers.DataSource = lista1;
        }
        #endregion

        #region ELiminarCliente
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            var eliminadas = cr.DeleteCliente(txbCustomerID.Text);
            MessageBox.Show($"Se elimino {eliminadas} filas");
        }
        #endregion
    }

}
