using System;
using MongoDB.Bson;

namespace Boilerplate.Domain
{
    public class MongoTable
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime CreationDate
        {
            get => _creationDate ?? DateTime.UtcNow;
            set => _creationDate = value;
        }
        
        private DateTime? _creationDate = DateTime.UtcNow;
    }
}