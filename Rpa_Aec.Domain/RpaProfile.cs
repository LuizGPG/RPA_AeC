using AutoMapper;
using Rpa_Aec.Domain.Entities;
using Rpa_Aec.Domain.Model;

namespace Rpa_Aec.Domain
{
    public class RpaProfile : Profile
    {
        public RpaProfile()
        {
            CreateMap<Busca, BuscaModel>().ReverseMap();
        }

    }
}
