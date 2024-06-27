using SE.Domain.DTOs;

namespace SE.Domain.Interfaces
{
    public interface IConsumer
	{
		public void Consume(SatelliteResultDTO result);

    }
}

