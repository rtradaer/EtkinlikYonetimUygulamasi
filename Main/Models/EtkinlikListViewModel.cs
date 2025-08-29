using Entities.Models;

namespace Main.Models;

public class EtkinlikListViewModel
{
    public IEnumerable<Etkinlik> Etkinlikler { get; set; } = Enumerable.Empty<Etkinlik>();
    public Pagination Pagination { get; set; } = new();
    public int TotalCount => Etkinlikler.Count();
}