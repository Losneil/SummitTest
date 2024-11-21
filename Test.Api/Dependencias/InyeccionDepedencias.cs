using Test.Api.Services;

namespace Test.Api.Dependencias
{
    public static class InyeccionDepedencias
    {
        public static IServiceCollection AgregarDependencias(this IServiceCollection servicios, IConfiguration configuracion)
        {
            
            //Agregar los servicios
            servicios.AddTransient<TestService>();
           

            servicios.AddSingleton<IConfiguration>(configuracion);

            return servicios;
        }
    }
}
