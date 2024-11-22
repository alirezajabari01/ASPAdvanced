using Serilog;

namespace Shop.EndPoint.API
{
    public static class RegisterSerilog
    {
        public static WebApplicationBuilder AddSerilogProvider(this WebApplicationBuilder webApplicationBuilder, string url)
        {
            webApplicationBuilder.Host.UseSerilog();
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel
            .Debug()
            //.Enrich.WithProperty("Service", serviceName)
            .WriteTo.Console()
            .WriteTo.Seq("http://localhost:5341/")
            // .WriteTo.Seq(url)
            .CreateLogger();

            return webApplicationBuilder;
        }
    }
}
