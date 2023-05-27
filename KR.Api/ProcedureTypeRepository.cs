using KR.Domains;
using KR.Domains.Model;
using Microsoft.EntityFrameworkCore;

namespace KR.Api
{
    public class ProcedureTypeRepository
    {
        private readonly AppDbContext dbContext;

        public ProcedureTypeRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ProcedureType> Read(int skip)
        {
            return await dbContext.ProcedureTypes.AsNoTrackingWithIdentityResolution().Skip(skip).FirstOrDefaultAsync();
        }

        public async Task<List<ProcedureType>> Read(int skip, int take)
        {
            return await dbContext.ProcedureTypes.AsNoTrackingWithIdentityResolution().Skip(skip).Take(take).ToListAsync();
        }

        public void Delete(int id)
        {
            dbContext.ProcedureTypes.Remove(new ProcedureType() { Id = id });
            dbContext.SaveChanges();
        }

        public async Task Create(ProcedureType procedureType)
        {
            await dbContext.ProcedureTypes.AddAsync(procedureType);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(int id, ProcedureType procedureType)
        {
            var entity = await dbContext.ProcedureTypes.AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync(pt => pt.Id == id);
            dbContext.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
