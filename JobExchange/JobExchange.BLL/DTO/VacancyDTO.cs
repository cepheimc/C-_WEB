using System;
using JobExchange.DAL.Entities;

namespace JobExchange.BLL.DTO
{
    class VacancyDTO
    {
        public int VacancyID { get; set; }
        public string VacancyName { get; set; }
        public DateTime? Date { get; set; }
        public string VacancyDescript { get; set; }

        public int CategoryId { get; set; }

        public int CustomerId { get; set; }
    }
}
