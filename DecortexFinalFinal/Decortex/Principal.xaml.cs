using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
            CargarLista();
            txtCodigo.IsEnabled = false;
        }

        public void Crear()
        {

            if (txtnombre.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar un nombre");
                txtnombre.Text = string.Empty;
                return;
            }
            else
            {
                if (txtDireccion.Text.Length == 0)
                {
                    MessageBox.Show("Debe ingresar una dirección");
                    txtDireccion.Text = string.Empty;
                    return;
                }
                else
                {
                    if (txtCorreo.Text.Length == 0)
                    {
                        MessageBox.Show("Debe ingresar un Correo");
                        txtCorreo.Text = string.Empty;
                        return;
                    }
                    else
                    {
                        if (email_bien_escrito(txtCorreo.Text) == false)
                        {
                            MessageBox.Show("Correo debe seguir el patrón 'a@a.a'");
                            txtCorreo.Text = string.Empty;
                            return;
                        }
                        else
                        {
                            if (txtTelefono.Text.Length == 0)
                            {
                                MessageBox.Show("Debe ingresar un teléfono");
                                txtTelefono.Text = string.Empty;
                                return;
                            }
                            else
                            {
                                if (txtEspecificaciones.Text.Length == 0)
                                {
                                    MessageBox.Show("Debe ingresar una especificación");
                                    txtEspecificaciones.Text = string.Empty;
                                    return;
                                }
                            }
                        }
                    }
                }
            }

            try
            {
                int.Parse(txtTelefono.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Debe ingresar un número en el campo Teléfono");
                return;
            }
                     

            Cliente c = new Cliente();
            c.Nombre = txtnombre.Text;
            if (c.Existe())
            {
                MessageBox.Show("Cliente ya existe");
                txtnombre.Text = string.Empty;
                return;
            }
            c.Direccion = txtDireccion.Text;
            c.Correo = txtCorreo.Text;
            c.Telefono = int.Parse(txtTelefono.Text);
            c.Especificaciones = txtEspecificaciones.Text;

            if (c.Create())
            {
                MessageBox.Show("Cliente ingresado");
            }
            else
            {
                MessageBox.Show("Cliente no ingresado");
            }
        }

        public void CargarLista()
        {
            ClienteCollection c = new ClienteCollection();
            dataGrid.ItemsSource = c.ReadAll();         
        }

        private void btn_agregar_Click(object sender, RoutedEventArgs e)
        {
            Crear();
            CargarLista();

            txtnombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEspecificaciones.Text = string.Empty;
            txtfiltrador.Text = string.Empty;
            txtCodigo.Text = string.Empty;
        }

        private void eliminar()
        {

            if (txtCodigo.Text.Length == 0)
            {
                MessageBox.Show("Debe seleccionar un Cliente");
                txtCodigo.Text = string.Empty;
                return;
            }

            Cliente c = new Cliente();
            c.Codigo = int.Parse(txtCodigo.Text);

            if (c.Delete())
            {
                MessageBox.Show("Cliente eliminado");
            }
            else
            {
                MessageBox.Show("Cliente no existe en la base de datos");
            }
        }

        private void btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            if (txtCodigo.Text.Length == 0)
            {
                MessageBox.Show("Debe Seleccionar un Código");
                txtCodigo.Text = string.Empty;
                return;
            }

            if (Application.Current.Windows.OfType<PedidosPorCliente>().Count() == 0)
            {
                Properties.Settings.Default.Codigo = int.Parse(txtCodigo.Text);

                PedidosPorCliente p = new PedidosPorCliente();
                p.Show();
                Close();
            }
        }

        private void btn_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            eliminar();
            CargarLista();
            txtCodigo.Text = string.Empty;
            txtnombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEspecificaciones.Text = string.Empty;
            txtfiltrador.Text = string.Empty;
        }

        private Boolean email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cliente af = new Cliente();
            af = (Cliente)dataGrid.SelectedItem;
            if (af != null)
            {
                txtnombre.Text = af.Nombre;
                txtCorreo.Text = af.Correo;
                txtTelefono.Text = af.Telefono.ToString();
                txtDireccion.Text = af.Direccion;
                txtEspecificaciones.Text = af.Especificaciones;
                txtCodigo.Text = af.Codigo.ToString();
            }
        }

        public void Editar()
        {
            if (txtCodigo.Text.Length == 0)
            {
                MessageBox.Show("Debe seleccionar un Cliente");
                txtnombre.Text = string.Empty;
                txtDireccion.Text = string.Empty;
                txtCorreo.Text = string.Empty;
                txtTelefono.Text = string.Empty;
                txtEspecificaciones.Text = string.Empty;
                return;
            }

            if (txtnombre.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar un nombre");
                txtnombre.Text = string.Empty;
                return;
            }
            else
            {
                if (txtDireccion.Text.Length == 0)
                {
                    MessageBox.Show("Debe ingresar una dirección");
                    txtDireccion.Text = string.Empty;
                    return;
                }
                else
                {
                    if (txtCorreo.Text.Length == 0)
                    {
                        MessageBox.Show("Debe ingresar un Correo");
                        txtCorreo.Text = string.Empty;
                        return;
                    }
                    else
                    {
                        if (email_bien_escrito(txtCorreo.Text) == false)
                        {
                            MessageBox.Show("Correo debe seguir el patrón 'a@a.a'");
                            txtCorreo.Text = string.Empty;
                            return;
                        }
                        else
                        {
                            if (txtTelefono.Text.Length == 0)
                            {
                                MessageBox.Show("Debe ingresar un teléfono");
                                txtTelefono.Text = string.Empty;
                                return;
                            }
                            else
                            {
                                if (txtEspecificaciones.Text.Length == 0)
                                {
                                    MessageBox.Show("Debe ingresar una especificación");
                                    txtEspecificaciones.Text = string.Empty;
                                    return;
                                }
                            }
                        }
                    }
                }
            }

            try
            {
                int.Parse(txtTelefono.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Debe ingresar un número en el campo Teléfono");
                return;
            }

            Cliente c = new Cliente();
            c.Codigo = int.Parse(txtCodigo.Text);
            c.Nombre = txtnombre.Text;
            c.Direccion = txtDireccion.Text;
            c.Correo = txtCorreo.Text;
            c.Telefono = int.Parse(txtTelefono.Text);
            c.Especificaciones = txtEspecificaciones.Text;

            if (c.Update())
            {
                MessageBox.Show("Cliente Actualizado");
            }
            else
            {
                MessageBox.Show("Cliente no actualizado");
            }
        }

        private void txtnombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 32 || ascci == 126)
                e.Handled = false;
            else

                e.Handled = true;
        }

        private void txtDireccion_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 48 && ascci <= 57 || ascci >= 65 && ascci <= 90 || ascci == 126 || ascci >= 97 && ascci <= 122 || ascci == 35 || ascci == 32)
                e.Handled = false;
            else e.Handled = true;
        }

        private void txtTelefono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 48 && ascci <= 57 || ascci == 43)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtCorreo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 48 && ascci <= 57 || ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 64 || ascci == 95 || ascci == 45 || ascci == 46)
                e.Handled = false;
            else e.Handled = true;
        }

        private void txtEspecificaciones_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 32 || ascci >= 48 && ascci <= 57 || ascci == 44 || ascci == 45 || ascci == 46 || ascci == 126)
                e.Handled = false;
            else

                e.Handled = true;
        }

        private void txtfiltrador_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122 || ascci == 32 || ascci == 126)
                e.Handled = false;
            else

                e.Handled = true;
        }

        private void btn_Editar_Click(object sender, RoutedEventArgs e)
        {
            Editar();
            CargarLista();
            dataGrid.UnselectAll();
            txtnombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEspecificaciones.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtfiltrador.Text = string.Empty;
        }

        private void txtfiltrador_TextChanged(object sender, TextChangedEventArgs e)
        {
            ClienteCollection c = new ClienteCollection();
            if (txtfiltrador.Text.Length == 0)
            {
                dataGrid.ItemsSource = c.ReadAll();
                return;
            }
            dataGrid.ItemsSource = c.Filtrados(txtfiltrador.Text);
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

                Pago p = new Pago();
                p.Show();
                Close();
            }
        }
    }
}
