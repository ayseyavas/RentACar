using AutoMapper;
using RentACar.DTOs.Request;
using RentACar.DTOs.Response;
using RentACar.Models.Business.Abstract;
using RentACar.Models.Entities.Concreate;
using RentACar.Models.Repository.Abstract;

namespace RentACar.Models.Business.Concreate
{
    public class CarManager : ICarService<Car>
    {
        ICarRepository carRepository;
        IMapper _mapper;
        ICarModelRepository carModelRepository;
        IBrandRepository brandRepository;
        public CarManager(ICarRepository carRepository, IMapper mapper, ICarModelRepository carModelRepository,IBrandRepository brandRepository)
        {
            this.carRepository = carRepository;
            this._mapper = mapper;
            this.carModelRepository = carModelRepository;
            this.brandRepository = brandRepository;
        }

        public void AddNewCar(CreateNewCarRequest createNewCarRequest)
        {


            //brand id yi carmodel üzerinden ulaşıp requestin içindeki brandId alanına eşliyorum
            createNewCarRequest.brandId = carModelRepository.Get(x => x.id == createNewCarRequest.modelId).brandId;

            Car car= _mapper.Map<Car>(createNewCarRequest);
            carRepository.Add(car);
            
        }

        public IEnumerable<GetAllCarsResponse> GetAll(string? includeProps = null)
        {
            IEnumerable<Car> cars = carRepository.GetAll(includeProps);

            IEnumerable<GetAllCarsResponse> getAllCarsResponses = _mapper.Map<IEnumerable<GetAllCarsResponse>>(cars);

            return getAllCarsResponses;
        }

        public IEnumerable<GetAllCarModelsResponse> GetAllCarModels()
        {

            IEnumerable<CarModel> carModels = carModelRepository.GetAll();

            IEnumerable<GetAllCarModelsResponse> getAllCarModelsResponses=_mapper.Map<IEnumerable<GetAllCarModelsResponse>>(carModels);

            return getAllCarModelsResponses;


        }
    }
}
