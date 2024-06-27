using SE.Domain.DTOs;
using SE.Domain.Interfaces;

namespace SE.Domain.Concrete
{
    public class Dispacher: IDispacher
    {
		IList<Action<SatelliteResultDTO>> actions = new List<Action<SatelliteResultDTO>>();
       
        private ISatelliteService _service;

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
				foreach(Action<SatelliteResultDTO> action in actions)
				{
					action(result);
				}
			}
		}

        private async Task SetInterval(TimeSpan timeout)
        {
            await Task.Delay(timeout).ConfigureAwait(false);

            var data = new SatelliteDataDTO();

            Random random = new Random();

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
}

