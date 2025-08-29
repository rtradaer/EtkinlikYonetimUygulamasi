using System.Diagnostics;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Repositories.Extensions;

namespace Repositories;

public class EtkinlikRepository : RepositoryBase<Etkinlik>, IEtkinlikRepository
{
    public EtkinlikRepository(RepositoryContext context) : base(context) { }

    public IQueryable<Etkinlik> GetAllEtkinlik_Repo(bool trackChanges) => FindAll(trackChanges);

    public IQueryable<Etkinlik> GetAllEtkinlikWithDetails_Repo(EtkinlikRequestParameters p)
    {
        return _context.Etkinlikler
            .OrderByDescending(e => e.CreatedAt)
            .ToPaginate(p.PageNumber, p.PageSize)
            .Where(e => e.IsActive)
            .Where(e => e.EndDate > DateTime.Now);
    }

    public IQueryable<Etkinlik> GetAllEtkinlikWithDetails_Repo(EtkinlikRequestParameters p, int id)
    {
        return _context.Etkinlikler
            .OrderByDescending(e => e.CreatedAt)
            .ToPaginate(p.PageNumber, p.PageSize)
            .Where(e => e.Id != id)
            .Where(e => e.IsActive)
            .Where(e => e.EndDate > DateTime.Now);
    }

    public Etkinlik? GetOneEtkinlik_Repo(int id, bool trackChanges) => FindByCondition(x => x.Id == id, trackChanges);

    public void CreateEtkinlik_Repo(Etkinlik activity) => Create(activity);

    public void DeleteEtkinlik_Repo(Etkinlik activity) => Remove(activity);

    public void EditEtkinlik_Repo(Etkinlik activity) => Update(activity);


}