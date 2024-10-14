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

namespace DapperDemoParcial
{
    public partial class Form1 : Form
    {
        CustomerRepository customerR = new CustomerRepository();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnObtenerTodos_Click(object sender, EventArgs e)
        {
            var cliente = customerR.ObtenerTodo();
            dgvCustomers.DataSource = cliente;
        }

        private void btnObtenerId_Click(object sender, EventArgs e)
        {
            var cliente = customerR.ObtenerPorID(tBoxObteneID.Text);
            dgvCustomers.DataSource = new List<Customers> { cliente };
            
            if(cliente != null)
            {
                RellenaForm(cliente);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var nuevoCliente = CrearCliente();
            var insertado = customerR.insertarCliente(nuevoCliente);
            MessageBox.Show($"{insertado} registros insertados");
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var clienteActualizado = CrearCliente();
            var actualizados = customerR.ActualizarCliente(clienteActualizado);
            var cliente = customerR.ObtenerPorID(clienteActualizado.CustomerID);
            dgvCustomers.DataSource = new List<Customers> { cliente };


            MessageBox.Show($"filas actualizadas {actualizados} , {clienteActualizado.CustomerID}");

        }
        private Customers CrearCliente()
        {
            var nuevo = new Customers
            {
                CustomerID = txbCustomerId.Text,
                CompanyName = txbCompanyName.Text,
                ContactName = txbContactName.Text,
                ContactTitle = txbContactTitle.Text,
                Address = tbxAddress.Text
            };
            return nuevo;
        }

        private void RellenaForm(Customers customers)
        {
            tBoxObteneID.Text = customers.CustomerID;
            txbCompanyName.Text = customers.CompanyName;
            txbContactName.Text = customers.ContactName;
            txbContactTitle.Text = customers.ContactTitle;
            tbxAddress.Text = customers.Address;
        }
        
    }
}
