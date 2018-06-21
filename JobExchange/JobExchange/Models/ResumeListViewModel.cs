using System;
using System.Collections.Generic;
using JobExchange.BLL.DTO;

namespace JobExchange.Models
{
    public class ResumeListViewModel
    {
        public IEnumerable<ResumeDTO> resumeDTOs { get; set; }
        public string CurrentCategory { get; set; }
    }
}