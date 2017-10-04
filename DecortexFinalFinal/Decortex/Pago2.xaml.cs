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
using System.Runtime.InteropServices;
using System.Windows.Interop;
using Negocio;
using System.Data;

namespace Decortex
{
    /// <summary>
    /// Lógica de interacción para Pago2.xaml
    /// </summary>
    public partial class Pago2 : Window
    {
        public Pago2()
        {
            InitializeComponent();
            CargarLista();
            txtAbono.IsEnabled = false;
            txtPrecio.IsEnabled = false;
            txtSaldoActual.IsEnabled = false;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hwnd, bool revert);

        [DllImport("user32.dll")]
        private static extern bool DeleteMenu(IntPtr hMenu, uint position, uint flags);
        private const uint SC_CLOSE = 0xF060;
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            IntPtr hwnd = GetSystemMenu(helper.Handle, false);
            DeleteMenu(hwnd, SC_CLOSE, 0);
        }

        private void btn_Abono_Click(object sender, RoutedEventArgs e)
        {
            if (txtNuevoAbono.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar un abono");
                return;
            }

            if (int.Parse(txtNuevoAbono.Text) == 0)
            {
                MessageBox.Show("Abono debe ser mayor a 0");
                return;
            }

            if (int.Parse(txtNuevoAbono.Text) > int.Parse(txtSaldoActual.Text))
            {
                MessageBox.Show("Abono no puede ser mayor a saldo actual");
                return;
            }

            Cortina c = new Cortina();
            c.Id = Properties.Settings.Default.idCortina;
            c.abono = int.Parse(txtAbono.Text) + int.Parse(txtNuevoAbono.Text);
            c.saldo = int.Parse(txtSaldoActual.Text) - int.Parse(txtNuevoAbono.Text);
            c.ClienteCodigo = Properties.Settings.Default.Codigo;

            if (c.abonar())
            {
                MessageBox.Show("Abono realizado");
                CargarLista();
                txtNuevoAbono.Text = string.Empty;
                txtAbono.Text = string.Empty;
                txtPrecio.Text = string.Empty;
                txtSaldoActual.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Abono no realizado");
            }

        }

        private void CargarLista()
        {
            CortinaCollection c = new CortinaCollection();
            dgPago.ItemsSource = c.ReadDeudas2(Properties.Settings.Default.Codigo);
        }

        private void dgPago_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cortina af = new Cortina();
            af = (Cortina)dgPago.SelectedItem;
            if (af != null)
            {
                txtPrecio.Text = af.Valor.ToString();
                txtAbono.Text = af.abono.ToString();
                txtSaldoActual.Text = af.saldo.ToString();
                Properties.Settings.Default.idCortina = af.Id;
            }
        }

        private void btn_Volver_Click(object sender, RoutedEventArgs e)
        {
            ListaDeudores pri = new ListaDeudores();
            pri.Show();
            this.Close();
        }

        private void btn_Pagartodo_Click(object sender, RoutedEventArgs e)
        {
            Cortina c = new Cortina();
            c.Id = Properties.Settings.Default.idCortina;
            c.abono = int.Parse(txtPrecio.Text);
            c.saldo = 0;
            c.ClienteCodigo = Properties.Settings.Default.Codigo;

            if (c.abonar())
            {
                MessageBox.Show("Pedido pagado completamente");
                CargarLista();
                txtNuevoAbono.Text = string.Empty;
                txtAbono.Text = string.Empty;
                txtPrecio.Text = string.Empty;
                txtSaldoActual.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Pago no realizado");
            }
        }
    }
}
