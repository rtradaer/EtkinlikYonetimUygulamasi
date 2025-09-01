using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;

namespace Services.Contracts;

public interface IEtkinlikService
{
    IEnumerable<Etkinlik> GetAllEtkinlik(bool trackChanges);
    IEnumerable<Etkinlik> GetAllEtkinlikWithDetails(EtkinlikRequestParameters p);
    IEnumerable<Etkinlik> GetAllEtkinlikWithDetails(EtkinlikRequestParameters p, int id);
    IEnumerable<Etkinlik> GetAllEtkinlikWithDetails_2(EtkinlikRequestParameters p);
    Etkinlik? GetOneEtkinlik(int id, bool trackChanges);
    EtkinlikDto? GetOneEtkinlikForUpdate(int id, bool trackChanges);
    void CreateEtkinlik(EtkinlikDtoCreate etkinlikDto);
    void DeleteEtkinlik(int id);
    void UpdateEtkinlik(EtkinlikDto etkinlikDto);
}