using System;

namespace JobExchange.BLL.DTO
{
    public class ResumeDTO
    {
        public int ResumeId { get; set; }
        public string ResumeName { get; set; }
        public DateTime? Date { get; set; }
        public string ResumeDescript { get; set; }

        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public EmployeeDTO Employee { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
