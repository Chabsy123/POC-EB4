using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POC_Application.DTOs;
using POC_Application.Services;

namespace POC_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitutionController : ControllerBase
    {
        private readonly InstitutionService _service;

        public InstitutionController(InstitutionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var data = await _service.GetByIdAsync(id);
            return data == null ? NotFound() : Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateInstitution request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var result = await _service.CreateAsync(request);
                return CreatedAtAction(nameof(GetById), new { id = result.RecordID }, result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateInstitution request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var success = await _service.UpdateAsync(id, request);
                return success ? NoContent() : NotFound();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var success = await _service.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
