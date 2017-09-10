using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CortinaCollection
    {
        private List<Cortina> GenerarListado(List<DALC.Cortina> cortina)
        {
            List<Cortina> cortinas = new List<Cortina>();
            foreach (DALC.Cortina temp in cortina)
            {
                Cortina c = new Cortina();
                c.Alto = temp.Alto;
                c.Ancho = temp.Ancho;
                c.ClienteCodigo = temp.ClienteCodigo;
                c.Id = temp.Id;
                c.MetrosCuadrados = temp.MetrosCuadrados;
                c.Posicion = temp.Posicion;
                c.Tela = temp.Tela;
                c.Ubicacion = temp.Ubicacion;
                c.Valor = temp.Valor;
                c.TipoCortina = temp.TipoCortina;
                c.Descripcion = temp.Descripcion;
                c.TipoPago = temp.TipoPago;                
                c.abono = temp.Abono;
                c.saldo = temp.Saldo;
                c.FechaCreacion = (DateTime)temp.FechaCreacion;
                c.FechaActualizacion = (DateTime)temp.FechaActualizacion;
                cortinas.Add(c);
            }
            return cortinas;
        }

        public List<Cortina> ReadAll()
        {
            var cortinas = CommonBC.ModeloDecortex.Cortina;
            return GenerarListado(cortinas.ToList());
        }

        public List<Cortina> Read(int codigoCliente)
        {
            var cortinas = CommonBC.ModeloDecortex.Cortina.Where(v => v.ClienteCodigo == codigoCliente);
            return GenerarListado(cortinas.ToList());
        }

        public List<Cortina> ReadDeudas(int codigoCliente)
        {
            var cortinas = CommonBC.ModeloDecortex.Cortina.Where(v => v.ClienteCodigo == codigoCliente && v.Saldo > 0);
            return GenerarListado(cortinas.ToList());
        }
    }
}
