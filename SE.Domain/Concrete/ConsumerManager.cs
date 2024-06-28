using SE.Domain.DTOs;
using SE.Domain.Interfaces;

namespace SE.Domain.Concrete;

public class ConsumerManager : IManager
{
	private List<IConsumer> consumers = new List<IConsumer>();

	public ConsumerManager(IDispacher dispacher)
	{
		dispacher.Subscribe(NotfyConsumers);
	}

	public void AddConsumer(IConsumer consumer)
	{
		consumers.Add(consumer);
	}

	private void NotfyConsumers(SatelliteResultDTO result)
	{
		foreach(IConsumer consumer in consumers)
		{
			consumer.Consume(result);
		}
	}
}

