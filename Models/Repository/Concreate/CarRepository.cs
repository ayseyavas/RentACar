using Microsoft.EntityFrameworkCore;
using RentACar.Models.Entities.Concreate;
using RentACar.Models.Repository.Abstract;
using System.Linq.Expressions;

namespace RentACar.Models.Repository.Concreate
{
    public class CarRepository : ICarRepository
    {
        public readonly AppDbContext _carDbRepository;
        //private DbSet<Car> dbSetCar;


        public CarRepository(AppDbContext appDbContext) 
        {
            this._carDbRepository = appDbContext;
            //this.dbSetCar = _carDbRepository.Set<Car>();

        }
        public void Add(Car entity)
        {
            _carDbRepository.Add(entity);
            _carDbRepository.SaveChanges();
        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> expression, string? includeProps = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> GetAll(string? includeProps = null)
        {
            IQueryable<Car> query = _carDbRepository.cars;



            query = query.Include(c => c.brand);

            query= query.Include(c=> c.model);


            IEnumerable<Car> carModels = query.ToList();

            if (!string.IsNullOrEmpty(includeProps))
            {
                foreach (var includeProp in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }

            }
            return query.ToList();
        }

        public void Update(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
