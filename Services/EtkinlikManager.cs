using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class EtkinlikManager : IEtkinlikService
{
    private readonly IRepositoryManager _manager;

    public EtkinlikManager(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public void CreateEtkinlik(Etkinlik etkinlik) => _manager.EtkinlikRepository.CreateEtkinlik_Repo(etkinlik);

    public void DeleteEtkinlik(Etkinlik etkinlik) => _manager.EtkinlikRepository.DeleteEtkinlik_Repo(etkinlik);

    public void EditEtkinlik(Etkinlik etkinlik) => _manager.EtkinlikRepository.EditEtkinlik_Repo(etkinlik);

    public IEnumerable<Etkinlik> GetAllEtkinlik(bool trackChanges) => _manager.EtkinlikRepository.GetAllEtkinlik_Repo(trackChanges);

    public IEnumerable<Etkinlik> GetAllEtkinlikWithDetails(EtkinlikRequestParameters p) => _manager.EtkinlikRepository.GetAllEtkinlikWithDetails_Repo(p);

    public Etkinlik? GetOneEtkinlik(int id, bool trackChanges) => _manager.EtkinlikRepository.GetOneEtkinlik_Repo(id, trackChanges);
}
