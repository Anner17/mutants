using Microsoft.AspNetCore.Mvc;
using Mutantes.Models;
using Mutantes.Service;

namespace Mutantes.Controllers
{
    [Route("api")]
    public class MutantController : ControllerBase
    {
        MutantService mutantService = new MutantService();

        [Route("mutant")]
        [HttpPost]
        public ActionResult<bool> Mutant([FromBody]DnaModel dnaModel)
        {
            return Ok(mutantService.CheckDna(dnaModel.dna));
        }

        [Route("statistics")]
        [HttpGet]
        public ActionResult<bool> Statistics()
        {
            return Ok(mutantService.getStatistics());
        }
    }
}
