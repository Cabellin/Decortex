using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Negocio;

namespace Decortex
{
    /// <summary>
    /// Lógica de interacción para CortinaPage.xaml
    /// </summary>
    public partial class CortinaPage : Window
    {
        public CortinaPage()
        {
            InitializeComponent();
            CargarLista();
            txtCodigo.IsEnabled = false;
        }

        private void CargarLista()
        {
            TodosLosPedidosCollection c = new TodosLosPedidosCollection();
            dataGrid.ItemsSource = c.ReadAll();
        }


        private void btn_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            eliminar();
            CargarLista();
            txtCodigo.Text = string.Empty;
        }

        private void eliminar()
        {
            if (txtCodigo.Text.Length == 0)
            {
                MessageBox.Show("Debe seleccionar un pedido");
                txtCodigo.Text = string.Empty;
                return;
            }

            Cortina c = new Cortina();
            c.Id = int.Parse(txtCodigo.Text);

            if (c.Delete())
            {
                MessageBox.Show("Pedido eliminado");
            }
            else
            {
                MessageBox.Show("Pedido no existe en la base de datos");
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TodosLosPedidos af = new TodosLosPedidos();
            af = (TodosLosPedidos)dataGrid.SelectedItem;
            if (af != null)
            {
                txtCodigo.Text = af.Id.ToString();
            }
        }
    }
}
