using SE.Domain.DTOs;
using SE.Domain.Interfaces;

namespace SE.Domain.Concrete.consumers;

public class ArchiveConsumer : IConsumer
{
    public void Consume(SatelliteResultDTO result)
    {
        Console.WriteLine($"ArchiveConsumer result: {result.span}");
    }
}