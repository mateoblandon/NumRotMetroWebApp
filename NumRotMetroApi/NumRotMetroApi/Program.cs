
using AccesoADatos.AccesoABaseDeDatos;
using AccesoADatos.MetodosParaAPI;
using AccesoADatos.Modelos;

namespace NumRotMetroApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IAccesoABaseDeDatosRelacional, AccesoABaseDeDatosRelacional>();
            builder.Services.AddSingleton<IMetodosParaDatos,  MetodosParaDatos>();

            // la parte a continuación es para tratar el error que soltó angular: "has been blocked by CORS policy: No 'Access-Control-Allow-Origin'  header is present on the requested resource."
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularOrigins",
                builder =>
                {
                    builder.WithOrigins(
                                        "http://localhost:4200"
                                        )
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });

            var app = builder.Build();
            app.UseCors("AllowAngularOrigins");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            //app.UseAuthorization();

            app.ConfigureApi();

            app.Run();
        }
    }
}