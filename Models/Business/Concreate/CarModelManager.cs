using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentACar.DTOs.Request;
using RentACar.DTOs.Response;
using RentACar.Models.Business.Abstract;
using RentACar.Models.Entities.Concreate;
using RentACar.Models.Repository.Abstract;

namespace RentACar.Models.Business.Concreate
{
    public class CarModelManager : ICarModelService<CarModel>
    {
        public ICarModelRepository carModelRepository;
        public readonly IMapper _mapper;
        public IBrandRepository brandRepository;
        public CarModelManager(ICarModelRepository modelRepository, IBrandRepository brandRepository, IMapper mapper)
        {
            this.carModelRepository = modelRepository;
            this._mapper = mapper;
            this.brandRepository = brandRepository;
        }

        public void AddNewCarModel(CreateNewCarModelRequest createNewCarModelRequest)
        {
            CarModel carModel=_mapper.Map<CarModel>(createNewCarModelRequest);
            carModelRepository.Add(carModel);
        }





        public IEnumerable<GetAllCarModelsResponse> GetAll(string? includeProps = null)
        {


            IEnumerable<CarModel> carModels = carModelRepository.GetAll();

            IEnumerable<GetAllCarModelsResponse> getAllCarModelsResponses=_mapper.Map<IEnumerable<GetAllCarModelsResponse >>(carModels);


            //foreach ( var carModelResponse in getAllCarModelsResponses) 
            //{
            //    carModelResponse

            //}



            //// Eğer includeProps varsa, belirtilen ilişkileri dahil et
            //if (!string.IsNullOrEmpty(includeProps))
            //{
            //    foreach (var includeProp in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            //    {
            //        query = query.Include(includeProp);
            //    }
            //}

            return getAllCarModelsResponses;
        }

        public IEnumerable<GetAllBrandsResponse> getAllBrandsResponses(string? includeProps = null)
        {
           IEnumerable<Brand> brands = brandRepository.GetAll();
            IEnumerable<GetAllBrandsResponse> getAllBrandsResponses=_mapper.Map<IEnumerable <GetAllBrandsResponse>>(brands);

            return getAllBrandsResponses;
        }

        public GetCarModelByIdResponse GetCarModelById(int id)
        {
            CarModel carModel= carModelRepository.Get(x=>x.id==id);

            GetCarModelByIdResponse getCarModelByIdResponse=_mapper.Map<GetCarModelByIdResponse>(carModel);

            return getCarModelByIdResponse;
        }

        public void updateCarModel(UpdateCarModelRequest updateCarModelRequest)
        {
            //CarModel carModel = carModelRepository.Get(x => x.id == updateCarModelRequest.id);

            CarModel tempCarModel = _mapper.Map<CarModel>(updateCarModelRequest);

            //carModel =tempCarModel;

            
            carModelRepository.Update(tempCarModel);
          
        }

        public void deleteCarModel(GetCarModelByIdResponse getCarModelByIdResponse)
        {
            CarModel carModel = _mapper.Map<CarModel>(getCarModelByIdResponse);

            carModelRepository.Delete(carModel);

        }
    }
}
