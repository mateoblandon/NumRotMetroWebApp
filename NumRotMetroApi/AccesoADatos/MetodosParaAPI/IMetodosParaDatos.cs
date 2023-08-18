using AccesoADatos.Modelos;

namespace AccesoADatos.MetodosParaAPI
{
    public interface IMetodosParaDatos
    {
        Task<IEnumerable<RegistroDeBaseDeDatos>> ObtenerTodosLosRegistros();
    }
}