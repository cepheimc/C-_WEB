using System;
using JobExchange.DAL.Entities;


namespace JobExchange.BLL.DTO
{
    class ResumeDTO
    {
        public int ResumeId { get; set; }
        public string ResumeName { get; set; }
        public DateTime? Date { get; set; }
        public string ResumeDescript { get; set; }

        public int EmployedId { get; set; }

        public int CategoryId { get; set; }
    }
}
