using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class TodosLosPedidos
    {
        public int Id { get; set; }

        public string NombreCliente { get; set; }
        public string Ubicacion { get; set; }
        public double Ancho { get; set; }
        public double Alto { get; set; }
        public string Tela { get; set; }
        public string Posicion { get; set; }
        public double MetrosCuadrados { get; set; }
        public int Valor { get; set; }
        public int ClienteCodigo { get; set; }
        public string TipoCortina { get; set; }
        public string Descripcion { get; set; }
        public string TipoPago { get; set; }
        public int? abono { get; set; }
        public int? saldo { get; set; }
        public DateTime FechaCreacion { get; set; }

        public DateTime FechaActualizacion { get; set; }
        
        

        private void Init()
        {
            Ubicacion = string.Empty;
            Ancho = 0;
            Alto = 0;
            Tela = string.Empty;
            Posicion = string.Empty;
            MetrosCuadrados = 0;
            Valor = 0;
            ClienteCodigo = 0;
            TipoCortina = string.Empty;
            Descripcion = string.Empty;
            TipoPago = string.Empty;
            abono = 0;
            saldo = 0;
            FechaCreacion = new DateTime();
            FechaActualizacion = new DateTime();
            NombreCliente = string.Empty;
        }

        public TodosLosPedidos()
        {
            this.Init();
        }
       

        
    }
}
