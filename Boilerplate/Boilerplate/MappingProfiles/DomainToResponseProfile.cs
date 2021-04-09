using AutoMapper;
using Boilerplate.Contracts.V1.Responses;
using Boilerplate.Domain;

namespace Boilerplate.MappingProfiles
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<TestDocument, TestDocumentResponse>();
        }
    }
}