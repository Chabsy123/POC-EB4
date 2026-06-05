using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POC_Application.DTOs;
using POC_Application.Services;

namespace POC_WebApi.Controllers
{
    [Route("api/[controller]")] //Exposes REST endpoint for CRUD operations
    [ApiController]
    public class FIController : ControllerBase
    {
        
        private readonly FinancialInstitutionService _service;

        public FIController(FinancialInstitutionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFIDTO request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _service.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.RecordID }, result);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateFIDTO request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var success = await _service.UpdateAsync(id, request);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
    
