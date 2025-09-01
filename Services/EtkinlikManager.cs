using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class EtkinlikManager : IEtkinlikService
{
    private readonly IRepositoryManager _manager;
    private readonly IMapper _mapper;

    public EtkinlikManager(IRepositoryManager manager, IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public void CreateEtkinlik(EtkinlikDtoCreate etkinlikDto)
    {
        Etkinlik etkinlik = _mapper.Map<Etkinlik>(etkinlikDto);
        etkinlik.CreatedAt = DateTime.Now;
        _manager.EtkinlikRepository.CreateEtkinlik_Repo(etkinlik);
        _manager.Save();
    }


    public void DeleteEtkinlik(int id)
    {
        Etkinlik etkinlik = _manager.EtkinlikRepository.GetOneEtkinlik_Repo(id, false);
        if (etkinlik != null)
        {
            _manager.EtkinlikRepository.DeleteEtkinlik_Repo(etkinlik);
            _manager.Save();
        }
    }

    public void UpdateEtkinlik(EtkinlikDto etkinlikDto)
    {
        Etkinlik etkinlik = _mapper.Map<Etkinlik>(etkinlikDto);
        _manager.EtkinlikRepository.UpdateEtkinlik_Repo(etkinlik);
        _manager.Save();
    }

    public IEnumerable<Etkinlik> GetAllEtkinlik(bool trackChanges) => _manager.EtkinlikRepository.GetAllEtkinlik_Repo(trackChanges);

    public IEnumerable<Etkinlik> GetAllEtkinlikWithDetails(EtkinlikRequestParameters p) => _manager.EtkinlikRepository.GetAllEtkinlikWithDetails_Repo(p);
    public IEnumerable<Etkinlik> GetAllEtkinlikWithDetails(EtkinlikRequestParameters p, int id) => _manager.EtkinlikRepository.GetAllEtkinlikWithDetails_Repo(p, id);
    public IEnumerable<Etkinlik> GetAllEtkinlikWithDetails_2(EtkinlikRequestParameters p) => _manager.EtkinlikRepository.GetAllEtkinlikWithDetails_Repo2(p);

    public Etkinlik? GetOneEtkinlik(int id, bool trackChanges) => _manager.EtkinlikRepository.GetOneEtkinlik_Repo(id, trackChanges);

    public EtkinlikDto? GetOneEtkinlikForUpdate(int id, bool trackChanges)
    {
        var etkinlik = _manager.EtkinlikRepository.GetOneEtkinlik_Repo(id, trackChanges);
        var etkinlikDto = _mapper.Map<EtkinlikDto>(etkinlik);
        return etkinlikDto;
    }
}
