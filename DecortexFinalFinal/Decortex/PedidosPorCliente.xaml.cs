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
using System.Runtime.InteropServices;
using System.Windows.Interop;
using Negocio;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Decortex
{
    /// <summary>
    /// Lógica de interacción para PedidosPorCliente.xaml
    /// </summary>
    public partial class PedidosPorCliente : Window
    {
        public PedidosPorCliente()
        {
            InitializeComponent();
            CargarLista();
            txtCodigo.IsEnabled = false;
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

        private void btn_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            Eliminar();
            CargarLista();
            txtUbicacion.Text = string.Empty;
            txtAlto.Text = string.Empty;
            txtAncho.Text = string.Empty;
            txtTela.Text = string.Empty;
            txtPosicion.Text = string.Empty;
            txtCodigo.Text = string.Empty;
        }

        private void btn_agregar_Click(object sender, RoutedEventArgs e)
        {
            Crear();
            CargarLista();

            txtUbicacion.Text = string.Empty;
            txtAlto.Text = string.Empty;
            txtAncho.Text = string.Empty;
            txtTela.Text = string.Empty;
            txtPosicion.Text = string.Empty;
            txtCodigo.Text = string.Empty;
        }

        private float metroCuadrado()
        {
            float metrocuadrado = 0;
            try
            {
                metrocuadrado = float.Parse(txtAncho.Text) * float.Parse(txtAlto.Text);
            }
            catch (Exception)
            {

            }
            return metrocuadrado;
        }

        private int valor()
        {
            int valor = 0;
            try
            {
                valor = (int)(25000 * metroCuadrado());
            }
            catch (Exception)
            {

            }
            return valor;
        }

        private void Crear()
        {
            if (txtUbicacion.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar una ubicación");
                txtUbicacion.Text = string.Empty;
                return;
            }

            try
            {
                float.Parse(txtAlto.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("El alto de la cortina debe ser un número");
            }

            if (txtAlto.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar un alto");
                txtAlto.Text = string.Empty;
                return;
            }

            try
            {
                float.Parse(txtAncho.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("El ancho de la cortina debe ser un número");
            }

            if (txtAncho.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar un Ancho");
                txtAncho.Text = string.Empty;
                return;
            }

            if (txtTela.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar una tela");
                txtTela.Text = string.Empty;
                return;
            }

            if (txtPosicion.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar una posición");
                txtPosicion.Text = string.Empty;
                return;
            }

            Cortina c = new Cortina();
            c.Ubicacion = txtUbicacion.Text;
            c.Ancho = float.Parse(txtAncho.Text);
            c.Alto = float.Parse(txtAlto.Text);
            c.Tela = txtTela.Text;
            c.Posicion = txtPosicion.Text;
            c.MetrosCuadrados = this.metroCuadrado();
            c.Valor = this.valor();
            c.ClienteCodigo = Properties.Settings.Default.Codigo;
            
            if (c.Create())
            {
                MessageBox.Show("Pedido ingresado");
            }
            else
            {
                MessageBox.Show("Pedido no ingresado");
            }
        }

        private void Eliminar()
        {
            if (txtCodigo.Text.Length == 0)
            {
                MessageBox.Show("Debe seleccionar un Código");
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

        private void CargarLista()
        {
            CortinaCollection c = new CortinaCollection();
            dataGrid.ItemsSource = c.Read(Properties.Settings.Default.Codigo);
        }

        public void Editar()
        {
            if (txtCodigo.Text.Length == 0)
            {
                MessageBox.Show("Debe seleccionar un Código");
                txtCodigo.Text = string.Empty;
                return;
            }

            if (txtUbicacion.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar una ubicación");
                txtUbicacion.Text = string.Empty;
                return;
            }

            try
            {
                float.Parse(txtAlto.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("El alto de la cortina debe ser un número");
            }

            if (txtAlto.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar un alto");
                txtAlto.Text = string.Empty;
                return;
            }

            try
            {
                float.Parse(txtAncho.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("El ancho de la cortina debe ser un número");
            }

            if (txtAncho.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar un Ancho");
                txtAncho.Text = string.Empty;
                return;
            }

            if (txtTela.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar una tela");
                txtTela.Text = string.Empty;
                return;
            }

            if (txtPosicion.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar una posición");
                txtPosicion.Text = string.Empty;
                return;
            }

            Cortina c = new Cortina();
            c.Id = int.Parse(txtCodigo.Text);
            c.Ubicacion = txtUbicacion.Text;
            c.Ancho = float.Parse(txtAncho.Text);
            c.Alto = float.Parse(txtAlto.Text);
            c.Tela = txtTela.Text;
            c.Posicion = txtPosicion.Text;
            c.MetrosCuadrados = this.metroCuadrado();
            c.Valor = this.valor();
            c.ClienteCodigo = Properties.Settings.Default.Codigo;

            if (c.Update())
            {
                MessageBox.Show("Pedido actualizado");
            }
            else
            {
                MessageBox.Show("Pedido no actualizado");
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cortina af = new Cortina();
            af = (Cortina)dataGrid.SelectedItem;
            if (af != null)
            {
                txtUbicacion.Text = af.Ubicacion;
                txtPosicion.Text = af.Posicion;
                txtTela.Text = af.Tela;
                txtAlto.Text = af.Alto.ToString();
                txtAncho.Text = af.Ancho.ToString();
                txtCodigo.Text = af.Id.ToString();
            }
        }

        private void btn_Volver_Click(object sender, RoutedEventArgs e)
        {
            Principal pri = new Principal();
            pri.Show();
            this.Close();
        }

        private void btn_Editar_Click(object sender, RoutedEventArgs e)
        {
            Editar();
            CargarLista();
            dataGrid.UnselectAll();
            txtUbicacion.Text = string.Empty;
            txtAlto.Text = string.Empty;
            txtAncho.Text = string.Empty;
            txtTela.Text = string.Empty;
            txtPosicion.Text = string.Empty;
            txtCodigo.Text = string.Empty;
        }

        private void txtUbicacion_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 46 || ascci == 32 || ascci >= 48 && ascci <= 57 || ascci == 126)
                e.Handled = false;
            else

                e.Handled = true;
        }

        private void txtPosicion_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 46 || ascci == 32 || ascci >= 48 && ascci <= 57 || ascci == 126)
                e.Handled = false;
            else

                e.Handled = true;
        }

        private void txtAncho_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 48 && ascci <= 57 || ascci == 44)
                e.Handled = false;
            else

                e.Handled = true;
        }

        private void txtAlto_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 48 && ascci <= 57 || ascci == 44)
                e.Handled = false;
            else

                e.Handled = true;
        }

        private void txtTela_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 32 || ascci >= 48 && ascci <= 57 || ascci == 126)
                e.Handled = false;
            else

                e.Handled = true;
        }
    }
}
