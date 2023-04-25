using AutoMapper;
using Implementation.Extensions;
using Implementation.OpenDotaApi.Models.Responses;
using Repositories;
using Repositories.Models.Entities;
using Services;

namespace Implementation.Services;

public class PatchService: IPatchService
{
    private readonly IPatchRepository _patchRepository;
    private readonly HttpClient _openDotaHttpClient;
    private readonly IMapper _mapper;

    public PatchService(IPatchRepository patchRepository, IMapper mapper, IHttpClientFactory httpClientFactory)
    {
        _patchRepository = patchRepository;
        _mapper = mapper;
        _openDotaHttpClient = httpClientFactory.CreateClient(Constants.OpenDotaApiHttpClientName);
    }

    public async Task LoadPatchesToSystem()
    {
        var dbPatches = await _patchRepository.GetPatchesAsync();
        var dbPatchesOpenDotaIdList = dbPatches.Select(patch => patch.OpenDotaId);
        var openDotaPatches = await _openDotaHttpClient.GetDataAsync<List<PatchData>>("constants/patch");
        var newPatches = new List<PatchEntity>();

        foreach (var patch in openDotaPatches)
        {
            if (!dbPatchesOpenDotaIdList.Contains(patch.OpenDotaId))
            {
                newPatches.Add(_mapper.Map<PatchEntity>(patch));
            }
        }

        if (newPatches.Any())
        {
            await _patchRepository.SavePatchesAsync(newPatches);
        }
    }
    
}