using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models.Diet;

namespace SEP3_Tier1Blazor_WASM.Data.DietData
{
    /// <summary>
    /// Interface responsible for containing all methods related with managing diet's data
    /// </summary>
    public interface IDietManager
    {
        /// <summary>
        /// Sends a request for adding new diet
        /// <param name="diet">The given diet</param>
        /// </summary>
        Task<int> AddDiet(DietWithOwner diet);
        /// <summary>
        /// Sends a request for getting diet by id
        /// <param name="id">The given diet id</param>
        /// </summary>
        Task<DietWithOwner> GetDietById(int id);
        /// <summary>
        /// Sends a request for getting public diets
        /// <param name="offset">The given offset</param>
        /// </summary>
        Task<List<DietSVWithOwner>> GetPublicDiets(int offset);
        /// <summary>
        /// Sends a request for getting private diets
        /// <param name="userId">The given user id</param>
        /// <param name="offset">The given offset</param>
        /// </summary>
        Task<List<DietShortVersion>> GetPrivateDietsForUser(int userId, int offset);
        /// <summary>
        /// Sends a request for editing diet
        /// <param name="diet">The given diet</param>
        /// </summary>
        Task EditDiet(DietModel diet);
        /// <summary>
        /// Sends a request for deleting diet
        /// <param name="id">The given diet id</param>
        /// </summary>
        Task DeleteDiet(int id);
        /// <summary>
        /// Sends a request for adding meal to a diet
        /// <param name="dietId">The given diet id</param>
        /// <param name="mealModel">The given meal</param>
        /// </summary>
        Task<int> AddMealInDiet(int dietId, MealModel mealModel);
        /// <summary>
        /// Sends a request for editing meal in a diet
        /// <param name="dietId">The given diet id</param>
        /// <param name="mealModel">The given meal</param>
        /// </summary>
        Task EditMealInDiet(int dietId, MealModel mealModel);
        /// <summary>
        /// Sends a request for deleting meal in a diet
        /// <param name="mealId">The given meal id</param>
        /// <param name="dietId">The given diet id</param>
        /// </summary>
        Task DeleteMealFromDiet(int mealId, int dietId);
    }
}