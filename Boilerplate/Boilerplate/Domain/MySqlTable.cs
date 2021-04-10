using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boilerplate.Domain
{
    public class MySqlTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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