using AutoMapper;
using RentACar.DTOs;
using RentACar.DTOs.Request;
using RentACar.DTOs.Response;
using RentACar.Models.Business.Abstract;
using RentACar.Models.Entities.Concreate;
using RentACar.Models.Repository.Abstract;
using RentACar.Models.Repository.Concreate;

namespace RentACar.Models.Business.Concreate
{
    public class BrandManager : IBrandService<Brand>
    {
        public IBrandRepository brandRepository;
        public readonly IMapper _mapper;

        public BrandManager(IBrandRepository brandRepository, IMapper mapper) 
        {
            this.brandRepository = brandRepository;
            this._mapper = mapper;

        }
        public void AddNewBrand(CreateNewBrandRequest createNewBrandRequest)
        {

            Brand brand= _mapper.Map<Brand>(createNewBrandRequest);

            brandRepository.Add(brand);
            
        }

        public IEnumerable<GetAllBrandsResponse> GetAll(string? includeProps = null)
        {
            IEnumerable<Brand> brands= brandRepository.GetAll();

            IEnumerable<GetAllBrandsResponse> brandResponse =_mapper.Map<IEnumerable<GetAllBrandsResponse>>(brands);

            return brandResponse;
        }

        public void UpdateBrand(UpdateBrandRequest updateBrandRequest)
        {
           

            Brand tempbrand= _mapper.Map<Brand>(updateBrandRequest);

           
            brandRepository.Update(tempbrand);

        }

        public GetBrandByIdResponse GetBrandById(int id)
        {
            Brand brand= brandRepository.Get(x=>x.id==id);

            GetBrandByIdResponse getBrandByIdResponse=_mapper.Map<GetBrandByIdResponse>(brand);

            return getBrandByIdResponse;
           
        }

        public void DeleteBrand(GetBrandByIdResponse getBrandByIdResponse)
        {
            Brand brand=_mapper.Map<Brand>(getBrandByIdResponse);
           brandRepository.Delete(brand);
        }
    }
}
