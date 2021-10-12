using Calabonga.EntityFrameworkCore.Entities.Base;
using System;

namespace Calabonga.RichDomainModelDemo.Entities
{
    public class Participant: Identity
    {
        public Participant(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public string? Description { get; set; }

        public Guid DocumentId { get; set; }

        public Document Document { get; set; }

        public string GetInfo() => string.IsNullOrWhiteSpace(Description)
            ? Name 
            : $"{Name}. {Description}";
    }
}
