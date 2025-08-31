namespace Services.Contracts;

public interface IServiceManager
{
    IEtkinlikService EtkinlikService { get; }
    IAuthService AuthService { get; }
}