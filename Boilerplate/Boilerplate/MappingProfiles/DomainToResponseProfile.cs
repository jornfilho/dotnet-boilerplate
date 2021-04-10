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
            CreateMap<MsSqlTable, TestMsSqlDocumentResponse>();
            CreateMap<MySqlTable, TestMySqlDocumentResponse>();
            CreateMap<MongoTable, TestMongoDocumentResponse>();
        }
    }
}