using Rpa_Aec.Domain.Entities;
using Rpa_Aec.Repository.Entities.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rpa_Aec.Repository.Entities
{
    public class BuscaRepository : IBuscaRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BuscaRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task AddRange(ICollection<Busca> busca)
        {
            try
            {
                await _applicationDbContext.AddRangeAsync(busca);
                await _applicationDbContext.SaveChangesAsync();

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
