using KR.Domains.Interfaces;
using KR.Domains.Model;
using Microsoft.AspNetCore.Mvc;

namespace KR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcedureTypeController : ControllerBase, IProcedureType
    {
        private readonly ProcedureTypeRepository procedureTypeRepository;

        public ProcedureTypeController(ProcedureTypeRepository procedureTypeRepository)
        {
            this.procedureTypeRepository = procedureTypeRepository;
        }

        [HttpGet("{skip}")]
        public async Task<ProcedureType> Read(int skip)
        {
            return await procedureTypeRepository.Read(skip);
        }

        [HttpGet]
        public async Task<List<ProcedureType>> Read([FromQuery] int skip, [FromQuery] int take)
        {
            return await procedureTypeRepository.Read(skip, take);
        }

        [HttpPut("{id}")]
        public async Task Update(int id, [FromBody] ProcedureType procedureType)
        {
            await procedureTypeRepository.Update(id, procedureType);
        }

        [HttpPost]
        public async Task Create([FromBody] ProcedureType procedureType)
        {
            await procedureTypeRepository.Create(procedureType);
        }
    }
}