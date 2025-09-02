namespace Entities.RequestParameters;

public class EtkinlikRequestParameters : RequestParameters
{
    public bool IsActive { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public EtkinlikRequestParameters() : this(1, 8) { }
    public EtkinlikRequestParameters(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}