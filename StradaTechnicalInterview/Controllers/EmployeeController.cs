using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using StradaTechnicalInterview.Models.Dtos.Request;
using StradaTechnicalInterview.Services.Interfaces;

namespace StradaTechnicalInterview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmploymentService _employmentService;

        public EmployeeController(IEmploymentService employmentService)
        {
            _employmentService = employmentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployment([FromBody] EmploymentRequestDto employmentDto)
        {
            if (employmentDto == null)
                return BadRequest("Employment data is required.");

            try
            {
                var employmentId = await _employmentService.CreateEmploymentAsync(employmentDto);
                return CreatedAtAction(nameof(GetEmploymentById), new { id = employmentId }, employmentDto);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{employmentId}/{userId}")]
        public async Task<IActionResult> UpdateEmployment(int employmentId, int userId, [FromBody] EmploymentRequestDto employmentDto)
        {
            if (employmentDto == null)
                return BadRequest("Employment data is required.");

            try
            {
                await _employmentService.UpdateEmploymentAsync(employmentId, userId, employmentDto);
                return NoContent();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{employmentId}")]
        public async Task<IActionResult> DeleteEmployment(int employmentId)
        {
            try
            {
                await _employmentService.DeleteEmployment(employmentId);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmploymentById(int id)
        {
            try
            {
                var employment = await _employmentService.GetEmploymentByIdAsync(id);
                if (employment == null)
                    return NotFound($"Employment with ID {id} not found.");

                return Ok(employment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}