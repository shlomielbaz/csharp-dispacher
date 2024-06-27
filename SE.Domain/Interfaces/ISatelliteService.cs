using SE.Domain.DTOs;

namespace SE.Domain.Interfaces;

public interface ISatelliteService
{
    public SatelliteResultDTO Calculate(SatelliteDataDTO data);
}

