using insurance.api.Dtos;
using insurance.api.Models;
using insurance.api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace insurance.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyRepository _repository;
        public PolicyController(IPolicyRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(PolicyForRegisterDto policyForRegisterDto)
        {
            var policyToCreate = new Policy
            {
                Name = policyForRegisterDto.Name,
                Description = policyForRegisterDto.Description,
                InitialDate = policyForRegisterDto.InitialDate,
                Period = policyForRegisterDto.Period,
                RiskScale = policyForRegisterDto.RiskScale,
                Price = policyForRegisterDto.Price,
                CoveringPercentage = policyForRegisterDto.RiskScale == "High" ? 50 : policyForRegisterDto.CoveringPercentage
            };

            var Policy = await _repository.Register(policyToCreate);

            return Ok(Policy);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePolicy(int id, PolicyForRegisterDto policyForRegisterDto)
        {
            var policyFromRepo = await _repository.GetPolicy(id);

            policyFromRepo.Name = policyForRegisterDto.Name;
            policyFromRepo.Description = policyForRegisterDto.Description;
            policyFromRepo.InitialDate = policyForRegisterDto.InitialDate;
            policyFromRepo.Period = policyForRegisterDto.Period;
            policyFromRepo.Price = policyForRegisterDto.Price;
            policyFromRepo.RiskScale = policyForRegisterDto.RiskScale;
            policyFromRepo.CoveringPercentage = policyForRegisterDto.CoveringPercentage;

            if (await _repository.SaveAll())
                return NoContent();

            throw new Exception($"Updating Policy {id} failed on update");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicy(int id)
        {
            var policy = await _repository.GetPolicy(id);

            if (policy.Id > 0) _repository.Delete(policy);

            if (await _repository.SaveAll())
                return Ok();

            return BadRequest("Failed to delete the policy");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var policies = _repository.GetAll();

            return Ok(policies);
        }
    }
}
