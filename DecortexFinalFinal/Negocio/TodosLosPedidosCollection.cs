using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class TodosLosPedidosCollection
    {
        private List<TodosLosPedidos> GenerarListado(List<DALC.Cortina> cortina)
        {
            List<TodosLosPedidos> cortinas = new List<TodosLosPedidos>();
            foreach (DALC.Cortina temp in cortina)
            {
                TodosLosPedidos c = new TodosLosPedidos();
                c.Alto = temp.Alto;
                c.Ancho = temp.Ancho;
                c.ClienteCodigo = temp.ClienteCodigo;
                c.Id = temp.Id;
                c.MetrosCuadrados = temp.MetrosCuadrados;
                c.Posicion = temp.Posicion;
                c.Tela = temp.Tela;
                c.Ubicacion = temp.Ubicacion;
                c.Valor = temp.Valor;
                c.abono = temp.Abono;
                c.saldo = temp.Saldo;
                c.TipoCortina = temp.TipoCortina;
                c.Descripcion = temp.Descripcion;
                c.TipoPago = temp.TipoPago;
                c.FechaCreacion = (DateTime)temp.FechaCreacion;
                c.FechaActualizacion = (DateTime)temp.FechaActualizacion;
                c.NombreCliente = CommonBC.ModeloDecortex.Cliente.First(v => v.Codigo == temp.ClienteCodigo).Nombre;
                cortinas.Add(c);
            }
            return cortinas;
        }

        public List<TodosLosPedidos> ReadAll()
        {
            var cortinas = CommonBC.ModeloDecortex.Cortina;
            return GenerarListado(cortinas.ToList());
        }

    }
}
