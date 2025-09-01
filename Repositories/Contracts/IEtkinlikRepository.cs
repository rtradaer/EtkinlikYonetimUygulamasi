using System.Diagnostics;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Contracts;

public interface IEtkinlikRepository
{
    IQueryable<Etkinlik> GetAllEtkinlik_Repo(bool trackChanges);
    IQueryable<Etkinlik> GetAllEtkinlikWithDetails_Repo(EtkinlikRequestParameters p);
    IQueryable<Etkinlik> GetAllEtkinlikWithDetails_Repo(EtkinlikRequestParameters p, int id);
    IQueryable<Etkinlik> GetAllEtkinlikWithDetails_Repo2(EtkinlikRequestParameters p);
    Etkinlik? GetOneEtkinlik_Repo(int id, bool trackChanges);
    void CreateEtkinlik_Repo(Etkinlik etkinlik);
    void DeleteEtkinlik_Repo(Etkinlik etkinlik);
    void UpdateEtkinlik_Repo(Etkinlik etkinlik);
}