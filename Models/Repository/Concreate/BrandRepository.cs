using Microsoft.EntityFrameworkCore;
using RentACar.Models.Entities.Concreate;
using RentACar.Models.Repository.Abstract;
using System.Linq.Expressions;


namespace RentACar.Models.Repository.Concreate
{
    public class BrandRepository : IBrandRepository
    {
        public readonly AppDbContext _brandDbContext;
        //private DbSet<Brand> dbSetBrands;
        public BrandRepository(AppDbContext appDbContext)
        {
            this._brandDbContext = appDbContext;
            //this.dbSetBrands = _brandDbContext.Set<Brand>();
        }

        public void Add(Brand entity)
        {

            _brandDbContext.Add(entity);
            _brandDbContext.SaveChanges();
        }

        public void Delete(Brand entity)
        {
            _brandDbContext.Remove(entity);
            _brandDbContext.SaveChanges();
        }

        public Brand Get(Expression<Func<Brand, bool>> expression, string? includeProps = null)
        {
            IQueryable<Brand> query = _brandDbContext.brands.Where(expression);

            if (!string.IsNullOrEmpty(includeProps))
            {
                foreach (var includeProp in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }

            }

            return query.AsNoTracking().FirstOrDefault();
        }

        public IEnumerable<Brand> GetAll(string? includeProps = null)
        {
            IQueryable<Brand> query = _brandDbContext.brands;
            if (!string.IsNullOrEmpty(includeProps))
            {
                foreach (var includeProp in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }

            }
            return query.ToList();
        }

        public void Update(Brand entity)
        {
          
            _brandDbContext.Update(entity);
            _brandDbContext.SaveChanges();
            
        }
    }
}
