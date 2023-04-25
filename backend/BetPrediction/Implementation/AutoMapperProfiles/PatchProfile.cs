using AutoMapper;
using Implementation.OpenDotaApi.Models.Responses;
using Repositories.Models.Entities;

namespace Implementation.AutoMapperProfiles;

public class PatchProfile: Profile
{
    public PatchProfile()
    {
        CreateMap<PatchData, PatchEntity>();
    }
}