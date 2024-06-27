using System;
using SE.Domain.DTOs;
using SE.Domain.Interfaces;

namespace SE.Domain.Concrete.consumers
{
	public class LoggerConsumer: IConsumer
    {
        public void Consume(SatelliteResultDTO result)
        {
            Console.WriteLine($"LoggerConsumer result: {result.span}");
        }
    }
}

