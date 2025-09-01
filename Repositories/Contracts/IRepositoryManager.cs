namespace Repositories.Contracts;

public interface IRepositoryManager
{
    IEtkinlikRepository EtkinlikRepository { get; }
    void Save();
}

