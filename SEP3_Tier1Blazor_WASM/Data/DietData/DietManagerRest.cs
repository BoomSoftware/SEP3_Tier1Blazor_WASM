using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models.Diet;

namespace SEP3_Tier1Blazor_WASM.Data.DietData
{
    public class DietManagerRest : DataManager, IDietManager
    {
        private readonly HttpClient client;
        private readonly string uri;
        
        public DietManagerRest()
        {
            client = Client;
            uri = "https://localhost:8443/diets";
        }
        
        public async Task<int> AddDiet(DietWithOwner diet)
        {
            HttpResponseMessage responseMessage = await client.PostAsync($"{uri}", PrepareObjectForRequest(diet));
            return int.Parse(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<DietWithOwner> GetDietById(int id)
        {
            return JsonSerializer.Deserialize<DietWithOwner>(await client.GetStringAsync($"{uri}/{id}"));
        }

        public async Task<List<DietSVWithOwner>> GetPublicDiets(int offset)
        {
            string responseMessage = await client.GetStringAsync($"{uri}/public?offset={offset}");
            if (!String.IsNullOrEmpty(responseMessage))
            {
                 return JsonSerializer.Deserialize<List<DietSVWithOwner>>(responseMessage);
            }

            return null;
        }

        public async Task<List<DietShortVersion>> GetPrivateDietsForUser(int userId, int offset)
        {
            string responseMessage = await client.GetStringAsync($"{uri}/private?userId={userId}&offset={offset}");
            if (!String.IsNullOrEmpty(responseMessage))
            {
                return JsonSerializer.Deserialize<List<DietShortVersion>>(responseMessage);
            }

            return null;
        }

        public async Task EditDiet(DietModel diet)
        {
            await client.PutAsync($"{uri}/{diet.Id}", PrepareObjectForRequest(diet));
        }

        public async Task DeleteDiet(int id)
        {
            await client.DeleteAsync($"{uri}/{id}");
        }

        public async Task<int> AddMealInDiet(int dietId, MealModel mealModel)
        {
            HttpResponseMessage responseMessage =
                await client.PostAsync($"{uri}/{dietId}/meals", PrepareObjectForRequest(mealModel));
            return int.Parse(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task EditMealInDiet(int dietId, MealModel mealModel)
        {
            await client.PutAsync($"{uri}/{dietId}/meals/{mealModel.Id}", PrepareObjectForRequest(mealModel));
        }

        public async Task DeleteMealFromDiet(int mealId, int dietId)
        {
            await client.DeleteAsync($"{uri}/{dietId}/meals/{mealId}");
        }
    }
}