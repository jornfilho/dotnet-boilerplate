using AutoMapper;
using Boilerplate.Contracts.V1.Requests;
using Boilerplate.Contracts.V1.Requests.Queries;
using Boilerplate.Domain;

namespace Boilerplate.MappingProfiles
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<PaginationQuery, PaginationFilter>();
            CreateMap<CreateMsSqlRequest, MsSqlTable>()
                .ForMember(x=> x.Id, x=> x.Ignore())
                .ForMember(x=> x.CreationDate, x=> x.Ignore());
        }
    }
}