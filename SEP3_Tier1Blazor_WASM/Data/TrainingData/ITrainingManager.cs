using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models;
using SEP3_Tier1Blazor_WASM.Models.Training;

namespace SEP3_Tier1Blazor_WASM.Data.TrainingData
{
    public interface ITrainingManager
    {
        Task<int> AddTraining(TrainingWithOwner training);
        Task<TrainingWithOwner> GetTrainingById(int id);
        Task<List<TrainingSVWithOwner>> GetPublicTrainings(int offset);
        Task<List<TrainingShortVersion>> GetPrivateTrainingsForUser(int userId, int offset);
        Task<List<TrainingShortVersion>> GetTrainingsForUser(int userId, int offset);
        Task<List<TrainingSVWithTime>> GetTrainingsInWeekForUser(int userId, int weekNumber);
        Task EditTraining( TrainingModel training);
        Task DeleteTraining(int id);
        Task<int> AddExerciseToTraining(int trainingId, ExerciseModel exercise);
        Task EditExerciseInTraining( int trainingId, ExerciseModel exercise);
        Task DeleteExerciseFromTraining(int trainingId, int exerciseId);
        Task<List<TrainingSVWithTime>> GetTrainingForToday(int userId);
    }
}