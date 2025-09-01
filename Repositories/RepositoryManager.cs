using Repositories.Contracts;

namespace Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;
    private readonly IEtkinlikRepository _etkinlikRepository;

    public RepositoryManager(IEtkinlikRepository etkinlikRepository, RepositoryContext context)
    {
        _etkinlikRepository = etkinlikRepository;
        _context = context;
    }

    public IEtkinlikRepository EtkinlikRepository => _etkinlikRepository;

    public void Save() => _context.SaveChanges();

}