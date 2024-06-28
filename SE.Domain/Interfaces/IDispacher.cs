using SE.Domain.DTOs;

namespace SE.Domain.Interfaces;

public interface IDispacher
{
    public void Subscribe(Action<SatelliteResultDTO> action);
    public void Run();
}

