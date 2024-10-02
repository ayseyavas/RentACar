using System.Linq.Expressions;

namespace RentACar.Models.Repository.Abstract

{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string? includeProps = null);

        T Get(Expression<Func<T, bool>> expression, string? includeProps = null);

        void Update(T entity);

        void Add(T entity);

        void Delete(T entity);



    }
}
