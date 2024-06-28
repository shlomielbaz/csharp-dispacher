using System;
using System.Globalization;
using SE.Domain.DTOs;
using SE.Domain.Interfaces;

namespace SE.Domain.Concrete.consumers;

public class ArchiveConsumer : IConsumer
{
    public void Consume(SatelliteResultDTO result)
    {
        Console.WriteLine($"ArchiveConsumer Consume Output: {result.span.ToString("F", CultureInfo.InvariantCulture)}");
    }
}