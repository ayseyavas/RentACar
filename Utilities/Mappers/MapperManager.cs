using AutoMapper;
using RentACar.DTOs;
using RentACar.DTOs.Request;
using RentACar.DTOs.Response;
using RentACar.Models.Entities.Concreate;

namespace RentACar.Utilities.Mappers
{
    public class MapperManager : Profile
    {

        public MapperManager() 
        {

            //CreateMap<Source,Destination>();

            //Brand
            CreateMap<Brand,GetAllBrandsResponse>();
            CreateMap<CreateNewBrandRequest, Brand>();
            CreateMap<UpdateBrandRequest, Brand>();
            //CreateMap<Brand, BrandDTO>();
            //CreateMap<BrandDTO,Brand>();
            CreateMap<Brand,GetBrandByIdResponse>();
            CreateMap<GetBrandByIdResponse, Brand>();

            //CarModel
            CreateMap<CreateNewCarModelRequest,CarModel>();
            CreateMap<CarModel, GetAllCarModelsResponse>();
            
            CreateMap<CarModel,GetCarModelByIdResponse>();
            CreateMap<CarModel, UpdateCarModelRequest>();
            CreateMap<UpdateCarModelRequest, CarModel>();
            CreateMap<GetCarModelByIdResponse, CarModel>();

            //Car
            CreateMap<Car,GetAllCarsResponse>();
            CreateMap<CreateNewCarRequest, Car>();

        }
    }
}
