using Services.Contracts;

namespace Services;

public class ServiceManager : IServiceManager
{
    private readonly IEtkinlikService _etkinlikService;
    private readonly IAuthService _authService;

    public ServiceManager(IEtkinlikService etkinlikService, IAuthService authService)
    {
        _etkinlikService = etkinlikService;
        _authService = authService;
    }

    public IEtkinlikService EtkinlikService => _etkinlikService;

    public IAuthService AuthService => _authService;
}
