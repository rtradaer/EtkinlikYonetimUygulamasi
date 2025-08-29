using Repositories.Contracts;

namespace Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly IEtkinlikRepository _etkinlikRepository;

    public RepositoryManager(IEtkinlikRepository etkinlikRepository)
    {
        _etkinlikRepository = etkinlikRepository;
    }

    public IEtkinlikRepository EtkinlikRepository => _etkinlikRepository;
}