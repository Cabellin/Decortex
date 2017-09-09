using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para ListaDeudores.xaml
    /// </summary>
    public partial class ListaDeudores : Window
    {
        public ListaDeudores()
        {
            InitializeComponent();
            cargarLista();
            txtCodigo.IsEnabled = false;
        }

        public void cargarLista()
        {
            ClienteCollection c = new ClienteCollection();
            dataGrid.ItemsSource = c.Deudores2Weeks();
        }

        private void btn_Pago_Click(object sender, RoutedEventArgs e)
        {
            if (txtCodigo.Text.Length == 0)
            {
                MessageBox.Show("Debe Seleccionar un Código");
                txtCodigo.Text = string.Empty;
                return;
            }

            if (Application.Current.Windows.OfType<Pago>().Count() == 0)
            {
                Properties.Settings.Default.Codigo = int.Parse(txtCodigo.Text);

                Pago2 p = new Pago2();
                p.Show();
                Close();
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cliente af = new Cliente();
            af = (Cliente)dataGrid.SelectedItem;
            if (af != null)
            {
                txtCodigo.Text = af.Codigo.ToString();
            }
        }
    }
}
