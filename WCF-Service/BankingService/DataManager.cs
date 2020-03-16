using SOAP_WCF_Solution.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP_WCF_Solution.BankingService
{
    public class DataManager<T> : IDataManager<T> where T : class
    {
        private EFContexte context = new EFContexte();

        public virtual List<T> List() => context.Set<T>().ToList();

        public virtual T Get(int id) => context.Set<T>().Find(id);

        public virtual void Create(T entity) => context.Set<T>().Add(entity);

        public virtual void Update(T entity) => context.Set<T>().Attach(entity);

        public virtual void Delete(T entity) => context.Set<T>().Remove(entity);

        public virtual void Commit() => context.SaveChanges();
    }
}