using System.Collections.Generic;
using DPAPINetCore.Models;
using DPAPINetCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DPAPINetCore.Controllers.API
{
    [Route("api/[controller]")]
    public class ProposalController
    {
        private readonly ProposalRepo repo;

        public ProposalController(ProposalRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IEnumerable<ProposalModel> Get(int conferenceId)
        {
            return repo.GetAllApprovedForConference(conferenceId);
        }
    }
}
