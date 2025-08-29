using System.Security.Cryptography.X509Certificates;
using Entities.Models;

namespace Repositories.Extensions;

public static class EtkinlikRepositoryExtension
{
    public static IQueryable<Etkinlik> ToPaginate(this IQueryable<Etkinlik> etkinlikler, int pageNumber, int pageSize)
    {
        return etkinlikler
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

    }

}