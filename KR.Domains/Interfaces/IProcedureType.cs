using KR.Domains.Model;
using Refit;

namespace KR.Domains.Interfaces
{
    public interface IProcedureType
    {
        [Get("/ProcedureType/{skip}")]
        public Task<ProcedureType> Read([AliasAs("skip")] int skip);

        [Get("/ProcedureType")]
        public Task<List<ProcedureType>> Read([Query] int skip, [Query] int take);

        [Get("/ProcedureType/ByScript/{script}")]
        public Task<List<ProcedureType>> ReadWithScript([AliasAs("script")] string skip);

        [Put("/ProcedureType/{id}")]
        public Task Update([AliasAs("id")] int id, [Body] ProcedureType procedureType);

        [Post("/ProcedureType")]
        public Task Create([Body] ProcedureType procedureType);
    }
}
