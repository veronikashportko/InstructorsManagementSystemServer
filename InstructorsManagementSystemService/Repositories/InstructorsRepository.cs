using InstructorsManagementSystemService.Models;
using InstructorsManagementSystemService.Models.Contexts;
using InstructorsManagementSystemService.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstructorsManagementSystemService.Repositories
{
    public class InstructorsRepository : IInstructorsRepository
    {
        private readonly InstructorsContext _instructorsContext;

        public InstructorsRepository(InstructorsContext instructorsContext)
        {
            _instructorsContext = instructorsContext ?? throw new ArgumentNullException(nameof(instructorsContext));
        }

        public async Task<bool> AddInstructorAsync(Instructor instructor)
        {
            instructor.CreatedDateTime = DateTime.Now;

            var addedInstructor = await _instructorsContext.Instructors.AddAsync(instructor);

            await _instructorsContext.SaveChangesAsync();

            if(addedInstructor== null)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteInstructorAsync(int id)
        {
            var instructorToDelete = await GetInstructorByIdAsync(id);

            if (instructorToDelete!=null)
            {
                instructorToDelete.IsDeleted = true;
                instructorToDelete.DeletedDateTime = DateTime.Now;

                var deletedInstructor = _instructorsContext.Update(instructorToDelete);

                await _instructorsContext.SaveChangesAsync();

                if(deletedInstructor!=null)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<IEnumerable<Instructor>> GetAllInstructorsAsync()
        {
            return await _instructorsContext.Instructors.Where(x=>!x.IsDeleted).ToListAsync();
        }

        public async Task<Instructor> GetInstructorByIdAsync(int id)
        {
            var instructor = await _instructorsContext.Instructors.Where(x => x.Id == id && !x.IsDeleted).SingleOrDefaultAsync();

            return instructor;
        }

        public async Task<bool> UpdateInstructorAsync(int id, Instructor newInstructor)
        {
            var instructorToUpdate = await GetInstructorByIdAsync(id);

            if(instructorToUpdate != null)
            {
                instructorToUpdate.FirstName = newInstructor.FirstName;
                instructorToUpdate.LastName = newInstructor.LastName;

                instructorToUpdate.EditedDateTime = DateTime.Now;

                var updatedInstructor = _instructorsContext.Update(instructorToUpdate);

                await _instructorsContext.SaveChangesAsync();

                if (updatedInstructor != null)
                {
                    return true;
                }                
            }

            return false;
        }
    }
}
