using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models.Diet;

namespace SEP3_Tier1Blazor_WASM.Data.DietData
{
    public interface IDietManager
    {
        Task<int> AddDiet(DietWithOwner diet);
        Task<DietWithOwner> GetDietById(int id);
        Task<List<DietSVWithOwner>> GetPublicDiets(int offset);
        Task<List<DietShortVersion>> GetPrivateDietsForUser(int userId, int offset);
        Task EditDiet(DietModel diet);
        Task DeleteDiet(int id);
        Task<int> AddMealInDiet(int dietId, MealModel mealModel);
        Task EditMealInDiet(int dietId, MealModel mealModel);
        Task DeleteMealFromDiet(int mealId, int dietId);
    }
}