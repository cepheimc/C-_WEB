using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobExchange.BLL.Interfaces
{
    public interface IService<T> where T : class
    {
        void AddData(T data);
        void UpdateData(T data);
        void DeleteData(int? id);
        T GetData(int? id);
        IQueryable<T> GetList();
        IQueryable<T> GetListOrder(string sort);
        IQueryable<T> GetListWhere(string search);
        void Dispose();
    }
}
