using SE.Domain.DTOs;
using SE.Domain.Services;

namespace SE.Tests;

public class SatelliteServiceTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SatelliteServiceCalculateTest()
    {
        var service = new SatelliteService();
        var data = new SatelliteDataDTO();

        data.X = 1.0;
        data.Y = 1.0;
        data.Z = 1.0;

        var result = service.Calculate(data);

        Assert.That(result.span, Is.EqualTo(3.0));
    }
}
