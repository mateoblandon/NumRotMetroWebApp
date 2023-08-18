using AccesoADatos.MetodosParaAPI;
using AccesoADatos.Modelos;

namespace NumRotMetroApi
{
    public static class EndPoints
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet(pattern: "/Registros", ObtenerRegistros);
        }

        private static async Task<IResult> ObtenerRegistros(IMetodosParaDatos data)
        {
            try
            {
                return Results.Ok(await data.ObtenerTodosLosRegistros());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
