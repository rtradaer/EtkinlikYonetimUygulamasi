using System.Diagnostics;
using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Contracts;

public interface IEtkinlikRepository
{
    IQueryable<Etkinlik> GetAllEtkinlik_Repo(bool trackChanges);
    IQueryable<Etkinlik> GetAllEtkinlikWithDetails_Repo(EtkinlikRequestParameters p);
    Etkinlik? GetOneEtkinlik_Repo(int id, bool trackChanges);
    void CreateEtkinlik_Repo(Etkinlik activity);
    void DeleteEtkinlik_Repo(Etkinlik activity);
    void EditEtkinlik_Repo(Etkinlik activity);
}