using System.Linq;
using JobExchange.BLL.DTO;

namespace JobExchange.BLL.Interfaces
{
    public interface IResumeService
    {
        void AddResume(ResumeDTO resumeDTO);
        void UpdateResume(ResumeDTO resumeDTO);
        void DeleteResume(int id);
        ResumeDTO GetResume(int id);
        IQueryable<ResumeDTO> GetResumes();
        IQueryable<ResumeDTO> GetResumesOrder(string sort);
        IQueryable<ResumeDTO> GetResumesWhere(string search);
        void Dispose();
    }
}
