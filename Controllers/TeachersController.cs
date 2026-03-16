using Microsoft.AspNetCore.Mvc;
using MyWebApi.Models.DTOs;
using MyWebApi.Services;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        /// <summary>
        /// Get all teachers
        /// </summary>
        /// <returns>List of all teachers</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherResponse>>> GetAllTeachers()
        {
            var teachers = await _teacherService.GetAllTeachersAsync();
            return Ok(teachers);
        }

        /// <summary>
        /// Get teacher by ID
        /// </summary>
        /// <param name="id">Teacher ID</param>
        /// <returns>Teacher details</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherResponse>> GetTeacher(int id)
        {
            var teacher = await _teacherService.GetTeacherByIdAsync(id);
            
            if (teacher == null)
            {
                return NotFound(new { message = $"Teacher with ID {id} not found." });
            }

            return Ok(teacher);
        }

        /// <summary>
        /// Create a new teacher
        /// </summary>
        /// <param name="request">Teacher details</param>
        /// <returns>Created teacher</returns>
        [HttpPost]
        public async Task<ActionResult<TeacherResponse>> CreateTeacher([FromBody] TeacherRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teacher = await _teacherService.CreateTeacherAsync(request);
            return CreatedAtAction(nameof(GetTeacher), new { id = teacher.Id }, teacher);
        }

        /// <summary>
        /// Update an existing teacher
        /// </summary>
        /// <param name="id">Teacher ID</param>
        /// <param name="request">Updated teacher details</param>
        /// <returns>Updated teacher</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<TeacherResponse>> UpdateTeacher(int id, [FromBody] TeacherRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teacher = await _teacherService.UpdateTeacherAsync(id, request);

            if (teacher == null)
            {
                return NotFound(new { message = $"Teacher with ID {id} not found." });
            }

            return Ok(teacher);
        }

        /// <summary>
        /// Delete a teacher
        /// </summary>
        /// <param name="id">Teacher ID</param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var result = await _teacherService.DeleteTeacherAsync(id);

            if (!result)
            {
                return NotFound(new { message = $"Teacher with ID {id} not found." });
            }

            return NoContent();
        }
    }
}
