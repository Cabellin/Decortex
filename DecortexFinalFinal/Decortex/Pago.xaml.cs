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

namespace Decortex
{
    /// <summary>
    /// Lógica de interacción para Pago.xaml
    /// </summary>
    public partial class Pago : Window
    {
        public Pago()
        {
            InitializeComponent();
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
    }
}
