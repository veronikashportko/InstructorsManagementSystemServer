using System;

namespace InstructorsManagementSystemService.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? CreatedDateTime { get; set; } = null;
        public DateTime? EditedDateTime { get; set; } = null;
        public DateTime? DeletedDateTime { get; set; } = null;
    }
}
