using InstructorsManagementSystemService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstructorsManagementSystemService.Repositories.Contracts
{
    public interface IInstructorsRepository
    {
        Task<IEnumerable<Instructor>> GetAllInstructorsAsync();
        Task<Instructor> GetInstructorByIdAsync(int id);
        Task<bool> AddInstructorAsync(Instructor instructor);
        Task<bool> UpdateInstructorAsync(int id, Instructor newInstructor);
        Task<bool> DeleteInstructorAsync(int id);
    }
}
