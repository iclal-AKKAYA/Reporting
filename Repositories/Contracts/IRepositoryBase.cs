using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        // Veritabanından tüm verileri getirir
        IQueryable<T> GenericRead(bool trackChanges);

        // Veritabanından koşullu sorgular yapar
        IQueryable<T> GenericReadExpression(Expression<Func<T, bool>> expression, bool trackChanges);

        // Yeni bir veri ekler
        Task GenericCreateAsync(T entity);

        // Var olan bir veriyi günceller
        void GenericUpdate(T entity);

        // Veritabanından bir veriyi siler
        void GenericDelete(T entity);
    }
}
