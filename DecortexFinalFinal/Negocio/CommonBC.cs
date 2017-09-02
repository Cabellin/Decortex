using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALC;

namespace Negocio
{
    public class CommonBC
    {
        private static DecortexEntities _modeloDecortex;
        public static DecortexEntities ModeloDecortex
        {
            get
            {
                if (_modeloDecortex == null)
                {
                    _modeloDecortex = new DecortexEntities();
                }
                return _modeloDecortex;
            }
        }
    }
}
