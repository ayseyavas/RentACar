using Microsoft.EntityFrameworkCore;
using RentACar.DTOs.Response;
using RentACar.Models.Entities.Concreate;
using RentACar.Models.Repository.Abstract;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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



            //query = query.Include(c => c.brand);

            query= query.Include(c=> c.model);

            query = query.Include(c => c.model.brand);


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

        public IEnumerable<Car> GetCarsByFilters(int? brandId = null, int? modelId = null, int? minPrice = null, int? maxPrice = null)
        {

            IQueryable<Car> query = _carDbRepository.cars;

            query = query
                //.Include(c => c.brand)
                        .Include(c => c.model);

            // Eğer BrandId filtrelemesi varsa, sorguya dahil ediyoruz
            if (brandId.HasValue)
            {
                query = query.Where(c => c.model.brandId == brandId.Value);
            }

            // Eğer ModelId filtrelemesi varsa, sorguya dahil ediyoruz
            if (modelId.HasValue)
            {
                query = query.Where(c => c.modelId == modelId.Value);
            }

            // Eğer fiyat aralığı filtrelemesi varsa, sorguya dahil ediyoruz
            if (minPrice.HasValue)
            {
                query = query.Where(c => c.dailyPrice >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(c => c.dailyPrice <= maxPrice.Value);
            }



            return query.ToList();
        }

        public void Update(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
