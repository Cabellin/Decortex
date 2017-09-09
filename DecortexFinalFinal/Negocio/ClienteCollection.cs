using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ClienteCollection
    {
        private List<Cliente> GenerarListado(List<DALC.Cliente> cliente)
        {
            List<Cliente> clientes = new List<Cliente>();
            foreach (DALC.Cliente temp in cliente)
            {
                Cliente c = new Cliente();
                c.Codigo = temp.Codigo;
                c.Correo = temp.Correo;
                c.Direccion = temp.Direccion;
                c.Especificaciones = temp.Especificaciones;
                c.Nombre = temp.Nombre;
                c.Telefono = temp.Telefono;
                clientes.Add(c);
            }
            return clientes;
        }

        public List<Cliente> ReadAll()
        {
            var clientes = CommonBC.ModeloDecortex.Cliente;
            return GenerarListado(clientes.ToList());
        }

        public List<Cliente> Filtrados(string txtfiltrador)
        {
            var clientes = CommonBC.ModeloDecortex.Cliente.SqlQuery("SELECT * FROM Cliente where Nombre like ('" + txtfiltrador + "%')");
            return GenerarListado(clientes.ToList());
        }

        public List<Cliente> Deudores2Weeks()
        {
            var clientes = CommonBC.ModeloDecortex.Cliente.SqlQuery("select distinct c.* from DecortexDB.dbo.Cliente c, DecortexDB.dbo.Cortina co where co.Saldo > 0 and DATEDIFF(day, co.FechaCreacion, GETDATE()) >= 14 and co.ClienteCodigo = c.Codigo;");
            return GenerarListado(clientes.ToList());
        }
    }
}
