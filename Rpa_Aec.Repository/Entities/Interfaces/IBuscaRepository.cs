using Rpa_Aec.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rpa_Aec.Repository.Entities.Interfaces
{
    public interface IBuscaRepository
    {
        Task AddRange(ICollection<Busca> busca);
    }
}
