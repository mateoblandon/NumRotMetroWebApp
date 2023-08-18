namespace AccesoADatos.AccesoABaseDeDatos
{
    public interface IAccesoABaseDeDatosRelacional
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "MySqlLocalHostConnection");
        Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "MySqlLocalHostConnection");
    }
}