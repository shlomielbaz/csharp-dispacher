using System;
using System.Globalization;
using SE.Domain.DTOs;
using SE.Domain.Interfaces;

namespace SE.Domain.Concrete.consumers
{
	public class LoggerConsumer: IConsumer
    {
        public void Consume(SatelliteResultDTO result)
        {
            Console.WriteLine($"LoggerConsumer Consume Output: {result.span.ToString("F", CultureInfo.InvariantCulture)}");
        }
    }
}

