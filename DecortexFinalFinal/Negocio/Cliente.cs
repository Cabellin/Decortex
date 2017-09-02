using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Cliente
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string Especificaciones { get; set; }

        public Cliente()
        {
            this.Init();
        }

        private void Init()
        {
            Nombre = string.Empty;
            Correo = string.Empty;
            Direccion = string.Empty;
            Telefono = 0;
            Especificaciones = string.Empty;
        }

        //CRUD

        public bool Existe()
        {
            try
            {
                CommonBC.ModeloDecortex.Cliente.First(v => v.Nombre.Equals(Nombre));
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
                DALC.Cliente cliente = new DALC.Cliente();
                cliente.Correo = Correo;
                cliente.Direccion = Direccion;
                cliente.Nombre = Nombre;
                cliente.Telefono = Telefono;
                cliente.Especificaciones = Especificaciones;
                CommonBC.ModeloDecortex.Cliente.Add(cliente);
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
                DALC.Cliente cliente = CommonBC.ModeloDecortex.Cliente.First(v => v.Codigo == Codigo);
                cliente.Correo = Correo;
                cliente.Direccion = Direccion;
                cliente.Nombre = Nombre;
                cliente.Telefono = Telefono;
                cliente.Especificaciones = Especificaciones;
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
                DALC.Cliente cliente = CommonBC.ModeloDecortex.Cliente.First(v => v.Codigo == Codigo);
                CommonBC.ModeloDecortex.Cliente.Remove(cliente);
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
