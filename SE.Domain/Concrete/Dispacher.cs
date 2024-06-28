using SE.Domain.DTOs;
using SE.Domain.Interfaces;

namespace SE.Domain.Concrete;

public class Dispacher: IDispacher
{
    private IList<Action<SatelliteResultDTO>> actions = new List<Action<SatelliteResultDTO>>();
    private ISatelliteService _service;

    private static long counter = 0;
    private static Random random = new Random();

    public Dispacher(ISatelliteService service)
    {
        _service = service;
    }

    public void Subscribe(Action<SatelliteResultDTO> action)
    {
        actions.Add(action);
    }

    public void Notify(SatelliteDataDTO data)
    {
        var result = _service?.Calculate(data);
        if (result != null)
        {
            counter = counter + 1;
            Console.WriteLine($"Notify Subscribers, Message No.: {counter}");

            foreach (Action<SatelliteResultDTO> action in actions)
            {
                action(result);
            }

            Console.WriteLine("");
        }
    }

    private async Task SetInterval(TimeSpan timeout)
    {
        await Task.Delay(timeout).ConfigureAwait(false);

        var data = new SatelliteDataDTO();

        data.X = random.NextDouble() * 100;
        data.Y = random.NextDouble() * 100;
        data.Z = random.NextDouble() * 100;

        this.Notify(data);
        _ = SetInterval(timeout);
    }


    public void Run()
    {
        _ = SetInterval(TimeSpan.FromSeconds(2));
        Thread.Sleep(TimeSpan.FromMinutes(10));
    }
}

