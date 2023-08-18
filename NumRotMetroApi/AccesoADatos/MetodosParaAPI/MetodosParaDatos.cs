using AccesoADatos.AccesoABaseDeDatos;
using AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos.MetodosParaAPI
{
    public class MetodosParaDatos : IMetodosParaDatos
    {
        private readonly IAccesoABaseDeDatosRelacional _conexionABaseDeDatos;
        public MetodosParaDatos(IAccesoABaseDeDatosRelacional conexionABaseDeDatos)
        {
            _conexionABaseDeDatos = conexionABaseDeDatos;
        }

        public async Task<IEnumerable<RegistroDeBaseDeDatos>> ObtenerTodosLosRegistros()
        {
            var results = await _conexionABaseDeDatos.LoadData<RegistroDeBaseDeDatos, dynamic>(storedProcedure: "spFacturaElectronicaDetalle_GetAll", new { });
            return results;
        }
    }
}