using AutoMapper;

namespace Rpa_Aec.Domain
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration((config) =>
            {
                config.AddProfile(new OrganizationProfile());
            });
        }
    }
}
