using InstructorsManagementSystemService.Models;
using InstructorsManagementSystemService.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstructorsManagementSystemService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly IInstructorsService _instructorsService;

        public InstructorsController(IInstructorsService instructorsService)
        {
            _instructorsService = instructorsService;
        }

        // GET api/instructors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instructor>>> GetAllInstructors()
        {
            IEnumerable<Instructor> instructors = await _instructorsService.GetAll();

            if (instructors == null)
            {
                return NotFound();
            }

            return instructors.ToList();
        }

        // GET api/instructors/5
        [HttpGet("{instructorId}")]
        public async Task<ActionResult<Instructor>> GetInstructorById(int instructorId)
        {
            Instructor instructor = await _instructorsService.GetInstructorById(instructorId);

            if (instructor == null)
            {
                return NotFound();
            }

            return instructor;
        }

        // POST api/instructors
        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] Instructor instructor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return await _instructorsService.AddInstructor(instructor);
        }

        // PUT api/instructors/5
        [HttpPut("{idInstructorToUpdate}")]
        public async Task<ActionResult<bool>> Put(int idInstructorToUpdate, [FromBody] Instructor newInstructor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return await _instructorsService.UpdateInstructor(idInstructorToUpdate, newInstructor);
        }

        // DELETE api/instructors/5
        [HttpDelete("{idInstructorToDelete}")]
        public async Task<ActionResult<bool>> Delete(int idInstructorToDelete)
        {
            return await _instructorsService.DeleteInstructor(idInstructorToDelete);
        }
    }
}
