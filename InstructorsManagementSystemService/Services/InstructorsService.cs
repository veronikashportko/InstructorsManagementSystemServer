using System.Collections.Generic;
using System.Threading.Tasks;
using InstructorsManagementSystemService.Models;
using InstructorsManagementSystemService.Services.Contracts;
using System;
using InstructorsManagementSystemService.Repositories.Contracts;

namespace InstructorsManagementSystemService.Services
{
    public class InstructorsService : IInstructorsService
    {
        private readonly IInstructorsRepository _instructorsRepository;

        public InstructorsService(IInstructorsRepository instructorsRepository)
        {
            _instructorsRepository = instructorsRepository;
        }

        public async Task<bool> AddInstructor(Instructor instructor)
        {
            instructor.IsDeleted = false;

            return await _instructorsRepository.AddInstructorAsync(instructor);
        }

        public async Task<bool> DeleteInstructor(int id)
        {
            return await _instructorsRepository.DeleteInstructorAsync(id);
        }

        public async Task<IEnumerable<Instructor>> GetAll()
        {
            return await _instructorsRepository.GetAllInstructorsAsync();
        }

        public async Task<Instructor> GetInstructorById(int id)
        {
            return await _instructorsRepository.GetInstructorByIdAsync(id);
        }

        public async Task<bool> UpdateInstructor(int id, Instructor newInstructor)
        {
            return await _instructorsRepository.UpdateInstructorAsync(id, newInstructor);
        }
    }
}
