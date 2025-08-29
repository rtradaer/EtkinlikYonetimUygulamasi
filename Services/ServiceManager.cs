using Services.Contracts;

namespace Services;

public class ServiceManager : IServiceManager
{
    private readonly IEtkinlikService _etkinlikService;

    public ServiceManager(IEtkinlikService etkinlikService)
    {
        _etkinlikService = etkinlikService;
    }

    public IEtkinlikService EtkinlikService => _etkinlikService;
}
