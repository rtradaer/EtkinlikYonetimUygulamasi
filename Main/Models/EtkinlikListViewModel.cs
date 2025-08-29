using Entities.Models;

namespace Main.Models;

public class EtkinlikListViewModel
{
    public Etkinlik Etkinlik { get; set; }
    public IEnumerable<Etkinlik> Etkinlikler { get; set; } = Enumerable.Empty<Etkinlik>();
    public Pagination Pagination { get; set; } = new();
    public int TotalCount => Etkinlikler.Count();
}