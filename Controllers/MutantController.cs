using Microsoft.AspNetCore.Mvc;
using Mutantes.Models;
using Mutantes.Service;
using System;

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
            try
            {
                return Ok(mutantService.CheckDna(dnaModel.dna));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("statistics")]
        [HttpGet]
        public ActionResult<bool> Statistics()
        {
            try
            {
                return Ok(mutantService.getStatistics());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
