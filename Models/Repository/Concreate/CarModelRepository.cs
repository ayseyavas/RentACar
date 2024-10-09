using Microsoft.EntityFrameworkCore;
using RentACar.Models.Entities.Concreate;
using RentACar.Models.Repository.Abstract;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;


namespace RentACar.Models.Repository.Concreate
{
    public class CarModelRepository : ICarModelRepository
    {
        public readonly AppDbContext _carModelDbContext;
        //private DbSet<CarModel> dbSetModels;

        public CarModelRepository(AppDbContext appDbContext)
        {
            this._carModelDbContext = appDbContext;
            //this.dbSetModels= _modelDbContext.Set<CarModel>();

        }
        public void Add(CarModel entity)
        {

            _carModelDbContext.Add(entity);
            _carModelDbContext.SaveChanges();
        }
            
        public void Delete(CarModel entity)
        {
           _carModelDbContext.Remove(entity);
            _carModelDbContext.SaveChanges();
        }

      

        public CarModel Get(Expression<Func<CarModel, bool>> expression, string? includeProps = null)
        {
            IQueryable<CarModel> query = _carModelDbContext.models.Where(expression);

            if (!string.IsNullOrEmpty(includeProps))
            {
                foreach (var includeProp in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }

            }

            return query.AsNoTracking().FirstOrDefault();
        }

        public IEnumerable<CarModel> GetAll(string? includeProps = null)
        {
            IQueryable<CarModel> query = _carModelDbContext.models;



            query = query.Include(c => c.brand);
            IEnumerable<CarModel> carModels = query.ToList(); // içine brandId alanı eklendi

            if (!string.IsNullOrEmpty(includeProps))
            {
                foreach (var includeProp in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }

            }
            return carModels;
        }

        public void Update(CarModel entity)
        {


            

            _carModelDbContext.Update(entity);
            _carModelDbContext.SaveChanges();
        }
    }
}
