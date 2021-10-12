using Calabonga.EntityFrameworkCore.Entities.Base;
using System.Collections.Generic;
using System.Linq;

namespace Calabonga.RichDomainModelDemo.Entities
{
    public class Document : Identity
    {
        private readonly List<Participant> _participants;

        public Document(string title, string? description = "без описания")
        {
            Title = title;
            Description = description;
            Status = DocumentStatus.Draft;
            _participants = new List<Participant>();
        }

        public string Title { get; private set; }

        public string? Description { get; private set; }

        public DocumentStatus Status { get; private set; }

        public virtual ICollection<Participant> Participants => _participants;

        public void AddParticipant(Participant participant)
        {
            if (!_participants.Select(x => x.Name).Contains(participant.Name))
            {
                _participants.Add(participant);
                if (Status == DocumentStatus.Draft && _participants.Count > 1)
                {
                    Status = DocumentStatus.InWork;
                }
            }
        }

        public bool SetStatus(DocumentStatus status)
        {
            if (CanSetStatus(status))
            {
                Status = status;
                return true;
            }
            return false;
        }

        private bool CanSetStatus(DocumentStatus status) => Status switch
        {
            DocumentStatus.None => false,
            DocumentStatus.Draft => false,
            DocumentStatus.InWork => true && Participants.Count > 1,
            DocumentStatus.Complete => false,
            _ => false
        };
    }
}
