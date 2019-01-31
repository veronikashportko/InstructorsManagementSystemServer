using InstructorsManagementSystemService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstructorsManagementSystemService.Services.Contracts
{
    public interface IInstructorsService
    {
        Task<IEnumerable<Instructor>> GetAll();
        Task<Instructor> GetInstructorById(int id);
        Task<bool> AddInstructor(Instructor instructor);
        Task<bool> UpdateInstructor(int id, Instructor newInstructor);
        Task<bool> DeleteInstructor(int id);
    }
}
