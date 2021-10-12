using Calabonga.RichDomainModelDemo.Entities;
using Calabonga.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calabonga.RichDomainModelDemo.Web.Controllers
{
    /// <summary>
    /// Documents Controller
    /// </summary>
    [Route("api/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DocumentsController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        [HttpGet("[action]")]
        public async Task<IActionResult> CreateDocument(string name)
        {
            var repository = _unitOfWork.GetRepository<Document>();

            var exists = await repository.GetFirstOrDefaultAsync(predicate: x => x.Title.ToLower().Equals(name.ToLower()));
            if (exists is not null)
            {
                return BadRequest("Already exists");
            }

            var document = new Document(name);
            var participant1 = new Participant("One");
            var participant2 = new Participant("Two");

            document.AddParticipant(participant1);

            var status1 = document.Status;
            var isComplete1 = document.SetStatus(DocumentStatus.Complete);

            document.AddParticipant(participant2);
            var status2 = document.Status;
            var isComplete2 = document.SetStatus(DocumentStatus.Complete);

            await repository.InsertAsync(document);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("[action]")]
        public IActionResult GetDocuments()
        {
            var repository = _unitOfWork.GetRepository<Document>();
            return Ok(repository.GetAll(true).ToList());
        }
    }
}
