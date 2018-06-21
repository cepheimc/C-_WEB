using System;

namespace JobExchange.BLL.DTO
{
    public class VacancyDTO
    {
        public int VacancyId { get; set; }
        public string VacancyName { get; set; }
        public DateTime? Date { get; set; }
        public string VacancyDescript { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public CategoryDTO Category {get; set;}

        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string Company { get; set; }
        public CustomerDTO Customer { get; set; }
    }
}
