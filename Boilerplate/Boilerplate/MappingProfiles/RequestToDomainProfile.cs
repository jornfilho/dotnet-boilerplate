using AutoMapper;
using Boilerplate.Contracts.V1.Requests.Queries;
using Boilerplate.Domain;

namespace Boilerplate.MappingProfiles
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<PaginationQuery, PaginationFilter>();
        }
    }
}