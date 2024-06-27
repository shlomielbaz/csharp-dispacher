using Microsoft.Extensions.DependencyInjection;
using SE.Domain.Concrete;
using SE.Domain.Concrete.consumers;
using SE.Domain.Interfaces;
using SE.Domain.Services;

public class Program
{
    public static void Main()
    {
        ServiceCollection services = new ServiceCollection();

        services.AddSingleton<ISatelliteService, SatelliteService>()
            .AddScoped<IDispacher, Dispacher>()
            .AddScoped<IManager, ConsumerManager>();

        var provider = services.BuildServiceProvider();

        var dispacher = provider.GetService<IDispacher>();
        if(dispacher != null)
        {
            var manager = provider.GetService<IManager>();
            if(manager != null)
            {
                var c1 = new ArchiveConsumer();
                var c2 = new LoggerConsumer();

                manager.AddConsumer(c1);
                manager.AddConsumer(c2);

                dispacher.Run();
            }
        }
    }
}

