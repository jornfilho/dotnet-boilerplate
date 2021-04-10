using System;

namespace Boilerplate.Contracts.V1.Responses
{
    public class TestMsSqlDocumentResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        
        public DateTime CreationDate { get; set; }
    }
}