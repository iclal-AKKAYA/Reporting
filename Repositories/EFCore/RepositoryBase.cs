using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext _context;

        public RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        // Veritabanından tüm verileri getirir
        public IQueryable<T> GenericRead(bool trackChanges) =>
            trackChanges ? _context.Set<T>() : _context.Set<T>().AsNoTracking();

        // Veritabanından koşullu sorgular yapar
        public IQueryable<T> GenericReadExpression(Expression<Func<T, bool>> expression, bool trackChanges) =>
            trackChanges ? _context.Set<T>().Where(expression) : _context.Set<T>().Where(expression).AsNoTracking();

        // Yeni bir veri ekler
        public async Task GenericCreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        // Var olan bir veriyi günceller
        public void GenericUpdate(T entity) => _context.Set<T>().Update(entity);

        // Veritabanından bir veriyi siler
        public void GenericDelete(T entity) => _context.Set<T>().Remove(entity);
    }
}
