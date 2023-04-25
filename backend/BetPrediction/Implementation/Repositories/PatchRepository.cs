using Implementation.Data;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Models.Entities;

namespace Implementation.Repositories;

public class PatchRepository: IPatchRepository
{
    private readonly DataBaseContext _context;

    public PatchRepository(DataBaseContext context)
    {
        _context = context;
    }

    public async Task<List<PatchEntity>> GetPatchesAsync()
    {
        return await _context.Patches.ToListAsync();
    }

    public async Task<PatchEntity?> GetPatchByOpenDotaId(int openDotaId)
    {
        return await _context.Patches.FirstOrDefaultAsync(patch => patch.OpenDotaId == openDotaId);
    }

    public async Task<PatchEntity?> GetPatchById(Guid id)
    {
        return await _context.Patches.FirstOrDefaultAsync(patch => patch.Id == id);
    }

    public async Task SavePatchesAsync(List<PatchEntity> patchesList)
    {
        foreach (var patch in patchesList)
        {
            if (patch.Id == default)
            {
                _context.Patches.Add(patch);
            }
            else
            {
                _context.Patches.Update(patch);
            }
        }
        
        
        await _context.SaveChangesAsync();
    }

    public async Task SavePatch(PatchEntity patch)
    {
        if (patch.Id == default)
        {
            _context.Patches.Add(patch);
        }
        else
        {
            _context.Patches.Update(patch);
        }
        
        await _context.SaveChangesAsync();
    }
}