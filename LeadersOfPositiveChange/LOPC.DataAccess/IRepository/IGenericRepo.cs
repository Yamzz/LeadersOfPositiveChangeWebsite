using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LOPC.DataAccess.IRepository
{
    public interface IGenericRepo<Vm, E, Db>
    {
        IQueryable<E> GetAll();
        IQueryable<E> FindBy(Expression<Func<E, bool>> predicate);
        Vm GetSingle(Expression<Func<E, bool>> whereCondition);
        void Add(Vm entity);
        void Delete(Vm entity);
        void Edit(Vm entity);
        void Save();
        long Count();
    }
}
