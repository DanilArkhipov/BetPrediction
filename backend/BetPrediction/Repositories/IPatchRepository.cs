using Repositories.Models.Entities;

namespace Repositories;

public interface IPatchRepository
{
    Task<List<PatchEntity>> GetPatchesAsync();

    Task<PatchEntity?> GetPatchByOpenDotaId(int openDotaId);

    Task<PatchEntity?> GetPatchById(Guid id);

    Task SavePatchesAsync(List<PatchEntity> patchesList);

    Task SavePatch(PatchEntity patch);
}