using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Cortina
    {
        public int Id { get; set; }
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
        public int abono { get; set; }
        public int saldo { get; set; }
        public DateTime FechaCreacion { get; set; }

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
            FechaCreacion = DateTime.Now;
        }

        public Cortina()
        {
            this.Init();
        }

        //CRUD

        public bool Existe()
        {
            try
            {
                CommonBC.ModeloDecortex.Cortina.First(v => v.Id == Id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public bool Create()
        {
            try
            {
                DALC.Cortina cortina = new DALC.Cortina();
                cortina.Ubicacion = Ubicacion;
                cortina.Posicion = Posicion;
                cortina.Tela = Tela;
                cortina.Alto = Alto;
                cortina.Ancho = Ancho;
                cortina.MetrosCuadrados = MetrosCuadrados;
                cortina.Valor = Valor;
                cortina.ClienteCodigo = ClienteCodigo;
                cortina.TipoCortina = TipoCortina;
                cortina.Descripcion = Descripcion;
                cortina.TipoPago = TipoPago;
                cortina.Abono = 0;
                cortina.Saldo = Valor;
                cortina.FechaCreacion = DateTime.Now;
                CommonBC.ModeloDecortex.Cortina.Add(cortina);
                CommonBC.ModeloDecortex.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                DALC.Cortina cortina = CommonBC.ModeloDecortex.Cortina.First(v => v.Id == Id);
                cortina.Ubicacion = Ubicacion;
                cortina.Posicion = Posicion;
                cortina.Tela = Tela;
                cortina.Alto = Alto;
                cortina.Ancho = Ancho;
                cortina.MetrosCuadrados = MetrosCuadrados;
                cortina.Valor = Valor;
                cortina.ClienteCodigo = ClienteCodigo;
                cortina.TipoCortina = TipoCortina;
                cortina.Descripcion = Descripcion;
                cortina.TipoPago = TipoPago;
                CommonBC.ModeloDecortex.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete()
        {
            try
            {
                DALC.Cortina cortina = CommonBC.ModeloDecortex.Cortina.First(v => v.Id == Id);
                CommonBC.ModeloDecortex.Cortina.Remove(cortina);
                CommonBC.ModeloDecortex.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
