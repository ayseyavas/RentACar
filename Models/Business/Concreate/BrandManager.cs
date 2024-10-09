using AutoMapper;
using Microsoft.AspNetCore.Hosting;
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
        public readonly IWebHostEnvironment webHostEnvironment;


        public BrandManager(IBrandRepository brandRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            this.brandRepository = brandRepository;
            this._mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
        }
        public void AddNewBrand(CreateNewBrandRequest createNewBrandRequest, IFormFile file)
        {
            string wwwRootPath = webHostEnvironment.WebRootPath;
            string brandpath = Path.Combine(wwwRootPath, @"img", @"brand");

            using (var fileStream = new FileStream(Path.Combine(brandpath, file.FileName), FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            createNewBrandRequest.PictureUrl = @"\img\brand\" + file.FileName;

            Brand brand = _mapper.Map<Brand>(createNewBrandRequest);

            brandRepository.Add(brand);

        }

        public IEnumerable<GetAllBrandsResponse> GetAll(string? includeProps = null)
        {
            IEnumerable<Brand> brands = brandRepository.GetAll();

            IEnumerable<GetAllBrandsResponse> brandResponse = _mapper.Map<IEnumerable<GetAllBrandsResponse>>(brands);

            return brandResponse;
        }

        public void UpdateBrand(UpdateBrandRequest updateBrandRequest, IFormFile file)
        {
            string wwwRootPath = webHostEnvironment.WebRootPath;
            string brandpath = Path.Combine(wwwRootPath, @"img", @"brand");

            Brand brand=brandRepository.Get(x=>x.id == updateBrandRequest.id);


            if (file !=null)
            {
                using (var fileStream = new FileStream(Path.Combine(brandpath, file.FileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                updateBrandRequest.PictureUrl = @"\img\brand\" + file.FileName;
            }
            else 
            {
                updateBrandRequest.PictureUrl=brand.PictureUrl;
            }
            

            Brand tempbrand = _mapper.Map<Brand>(updateBrandRequest);
           



            brandRepository.Update(tempbrand);


        }

        public GetBrandByIdResponse GetBrandById(int id)
        {
            Brand brand = brandRepository.Get(x => x.id == id);

            GetBrandByIdResponse getBrandByIdResponse = _mapper.Map<GetBrandByIdResponse>(brand);

            return getBrandByIdResponse;

        }

        public void DeleteBrand(GetBrandByIdResponse getBrandByIdResponse)
        {
            Brand brand = _mapper.Map<Brand>(getBrandByIdResponse);
            brandRepository.Delete(brand);
        }
    }
}
