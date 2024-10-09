using KpsIdentity;
using RentACar.Models.KpsService;

namespace RentACar.Models
{
    public class ServiceKpsPublic
    {        public async Task<bool> OnGetService(Parametters parametters)         {            bool result=false;            var client = new KpsIdentity.KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);            var response = await client.TCKimlikNoDogrulaAsync(parametters.TCKimlikNo,parametters.Ad,parametters.Soyad,parametters.DogumYili);            return result=response.Body.TCKimlikNoDogrulaResult;        }
    }
}