using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
        public readonly IWebHostEnvironment webHostEnvironment;
        public CarModelManager(ICarModelRepository modelRepository, IBrandRepository brandRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            this.carModelRepository = modelRepository;
            this._mapper = mapper;
            this.brandRepository = brandRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        public void AddNewCarModel(CreateNewCarModelRequest createNewCarModelRequest, IFormFile? file)
        {
            string wwwRootPath = webHostEnvironment.WebRootPath;
            string brandpath = Path.Combine(wwwRootPath, @"img", @"carModel");

            using (var fileStream = new FileStream(Path.Combine(brandpath, file.FileName), FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            createNewCarModelRequest.PictureUrl = @"\img\brand\" + file.FileName;



            CarModel carModel =_mapper.Map<CarModel>(createNewCarModelRequest);
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

        public void updateCarModel(UpdateCarModelRequest updateCarModelRequest, IFormFile file)
        {

            string wwwRootPath = webHostEnvironment.WebRootPath;
            string brandpath = Path.Combine(wwwRootPath, @"img", @"carModel");

            CarModel carModel = carModelRepository.Get(x => x.id==updateCarModelRequest.id);


            if (file!=null)
            {
                using (var fileStream = new FileStream(Path.Combine(brandpath, file.FileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                updateCarModelRequest.PictureUrl = @"\img\brand\" + file.FileName;

            }
            else
            {
                updateCarModelRequest.PictureUrl=carModel.PictureUrl;
            }
           
            CarModel tempCarModel = _mapper.Map<CarModel>(updateCarModelRequest);


            
            carModelRepository.Update(tempCarModel);
          
        }

        public void deleteCarModel(GetCarModelByIdResponse getCarModelByIdResponse)
        {
            CarModel carModel = _mapper.Map<CarModel>(getCarModelByIdResponse);

            carModelRepository.Delete(carModel);

        }
    }
}
