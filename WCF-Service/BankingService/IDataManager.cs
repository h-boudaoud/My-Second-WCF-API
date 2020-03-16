using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAP_WCF_Solution.BankingService
{
    public interface IDataManager<T> where T : class
    {
        List<T> List();

        T Get(int id);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Commit();
    }
}
