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

namespace Decortex
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : Window
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void btn_Clientes_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Windows.OfType<Principal>().Count() == 0 && Application.Current.Windows.OfType<PedidosPorCliente>().Count() == 0)
            {
                Principal pa = new Principal();
                pa.Show();
            }
        }

        private void btn_Pedidos_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Windows.OfType<CortinaPage>().Count() == 0)
            {
                CortinaPage cor = new CortinaPage();
                cor.Show();
            }
        }

        private void btn_Deudores_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Windows.OfType<ListaDeudores>().Count() == 0)
            {
                ListaDeudores lis = new ListaDeudores();
                lis.Show();
            }
        }

    }
}
