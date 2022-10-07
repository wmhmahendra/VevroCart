using CART_WebServices;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class Program
{
    public static void Main(string[] args)
    {
        var Config = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .Build();


        var ConString = Config.GetConnectionString("CARTDatabase");
        var LogTable = Config.GetValue<string>("MyLogs:LogTableName");
        var ColOption = new ColumnOptions();

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override(source: "Microsoft", LogEventLevel.Warning)
            .WriteTo.Console()
            .WriteTo.MSSqlServer(connectionString: ConString, tableName: LogTable, columnOptions: ColOption, autoCreateSqlTable: true)
            .CreateLogger();

        try
        {
            //Log.Information(messageTemplate: "Application has Started at {LogTime}", DateTime.Now);
            CreateHostBuilder(args).Build().Run();
        }
        catch (Exception Ex)
        {
            Log.Error(Ex, messageTemplate: "Application has stopped at {LogTime}", DateTime.Now);
        }
        finally
        {
            Log.CloseAndFlush();
        }


    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
             .ConfigureLogging((Context, Logging) =>
             {
                 Logging.ClearProviders();
             })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            }).UseSerilog();
}
