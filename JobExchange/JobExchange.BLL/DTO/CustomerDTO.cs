using System;
using System.Collections.Generic;
using System.Linq;


namespace JobExchange.BLL.DTO
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CustomerDescript { get; set; }

        public ICollection<VacancyDTO> Vacancies { get; set; }
    }
}
