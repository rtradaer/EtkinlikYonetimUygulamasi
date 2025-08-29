using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;

namespace Services.Contracts;

public interface IEtkinlikService
{
    IEnumerable<Etkinlik> GetAllEtkinlik(bool trackChanges);
    IEnumerable<Etkinlik> GetAllEtkinlikWithDetails(EtkinlikRequestParameters p);
    Etkinlik? GetOneEtkinlik(int id, bool trackChanges);
    void CreateEtkinlik(Etkinlik etkinlik);
    void DeleteEtkinlik(Etkinlik etkinlik);
    void EditEtkinlik(Etkinlik etkinlik);
}