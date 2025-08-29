namespace Entities.Models;

public class Etkinlik
{
    public int Id { get; set; }
    public String? Title { get; set; }
    public String? ShortDescription { get; set; }
    public String? LongDescription { get; set; }
    public String? ImageUrl { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }
}
