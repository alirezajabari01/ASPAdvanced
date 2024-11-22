using Newtonsoft.Json;
using Shop.Application.Contract.Dtos.Quantities;
using Shop.Application.Contract.IServices.Products;
using System.Net.Http;
using System.Text;

namespace Shop.Application.Services.Products
{
    public class InventoryExternalService : IInventoryExternalService
    {
        private readonly HttpClient httpClient;

        public InventoryExternalService(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient.CreateClient();
        }

        public int GetQuantity(QuantityRequestDto dto)
        {
            int result = 0;
            try
            {
                var json = JsonConvert.SerializeObject(dto);
                var content = new StringContent(json, Encoding.UTF8, "Application/json");
                var response = httpClient.PostAsync("http://localhost:2022/api/quantities", content).GetAwaiter().GetResult();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    result = Convert.ToInt32(responseContent);

                }

                //if (response.IsSuccessStatusCode)
                //{

                //}

            }
            catch (Exception ex)
            {

                throw;
            }


            return result;
        }
    }
}
