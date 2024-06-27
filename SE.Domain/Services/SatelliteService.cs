using SE.Domain.DTOs;
using SE.Domain.Interfaces;

namespace SE.Domain.Services;

public class SatelliteService: ISatelliteService
{
	public SatelliteService()
	{
	}

    public SatelliteResultDTO Calculate(SatelliteDataDTO data)
    {
        var result = new SatelliteResultDTO();

        result.span = data.X + data.Y + data.Z;

        return result;
    }
}

