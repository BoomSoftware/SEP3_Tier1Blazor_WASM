using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models.Training;

namespace SEP3_Tier1Blazor_WASM.Data.TrainingData
{
    /// <summary>
    /// Interface responsible for containing all methods related with managing training's data
    /// </summary>
    public interface ITrainingManager
    {
        /// <summary>
        /// Sends a request for adding new training
        /// <param name="training">The given training</param>
        /// </summary>
        Task<int> AddTraining(TrainingWithOwner training);
        /// <summary>
        /// Sends a request for getting training by id
        /// <param name="id">The given training id</param>
        /// </summary>
        Task<TrainingWithOwner> GetTrainingById(int id);
        /// <summary>
        /// Sends a request for getting public trainings
        /// <param name="offset">The given offset</param>
        /// </summary>
        Task<List<TrainingSVWithOwner>> GetPublicTrainings(int offset);
        /// <summary>
        /// Sends a request for getting private training
        /// <param name="userId">The given user id</param>
        /// <param name="offset">The given offset</param>
        /// </summary>
        Task<List<TrainingShortVersion>> GetPrivateTrainingsForUser(int userId, int offset);
        /// <summary>
        /// Sends a request for getting training in a given week
        /// <param name="userId">The given user id</param>
        /// <param name="weekNumber">The given week number</param>
        /// </summary>
        Task<List<TrainingSVWithTime>> GetTrainingsInWeekForUser(int userId, int weekNumber);
        /// <summary>
        /// Sends a request for editing training
        /// <param name="training">The given training</param>
        /// </summary>
        Task EditTraining( TrainingModel training);
        /// <summary>
        /// Sends a request for deleting training
        /// <param name="id">The given training id</param>
        /// </summary>
        Task DeleteTraining(int id);
        /// <summary>
        /// Sends a request for adding exercise to a training
        /// <param name="trainingId">The given training id</param>
        /// <param name="exercise">The given exercise</param>
        /// </summary>
        Task<int> AddExerciseToTraining(int trainingId, ExerciseModel exercise);
        /// <summary>
        /// Sends a request for editing exercise in a training
        /// <param name="trainingId">The given training id</param>
        /// <param name="exercise">The given exercise</param>
        /// </summary>
        Task EditExerciseInTraining( int trainingId, ExerciseModel exercise);
        /// <summary>
        /// Sends a request for deleting exercise in a training
        /// <param name="trainingId">The given training id</param>
        /// <param name="exerciseId">The given exercise id</param>
        /// </summary>
        Task DeleteExerciseFromTraining(int trainingId, int exerciseId);
        /// <summary>
        /// Sends a request for getting trainings for today
        /// <param name="userId">The given user id</param>
        /// </summary>
        Task<List<TrainingSVWithTime>> GetTrainingForToday(int userId);
    }
}