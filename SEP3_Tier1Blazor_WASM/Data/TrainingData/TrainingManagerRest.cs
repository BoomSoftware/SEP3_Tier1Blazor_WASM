using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models;
using SEP3_Tier1Blazor_WASM.Models.Training;

namespace SEP3_Tier1Blazor_WASM.Data.TrainingData
{
    public class TrainingManagerRest : DataManager, ITrainingManager
    {
        private HttpClient client;
        private string uri;


        public TrainingManagerRest()
        {
            client = Client;
            uri = "https://localhost:8443/trainings";
        }
        
        
        public async Task<int> AddTraining(TrainingWithOwner training)
        {
            HttpResponseMessage responseMessage = await client.PostAsync(uri, PrepareObjectForRequest(training));
            return int.Parse(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<TrainingWithOwner> GetTrainingById(int id)
        {
            string temp = await client.GetStringAsync($"{uri}/{id}");
            Console.WriteLine("GetTrainingByID: "+ temp);
            return JsonSerializer.Deserialize<TrainingWithOwner>(temp);
        }

        public async Task<List<TrainingSVWithOwner>> GetPublicTrainings(int offset)
        {
            string temp = await client.GetStringAsync($"{uri}/public?offset={offset}");
            if (!String.IsNullOrEmpty(temp))
            {
                return JsonSerializer.Deserialize<List<TrainingSVWithOwner>>(temp);
            }

            return null;
        }

        public async Task<List<TrainingShortVersion>> GetPrivateTrainingsForUser(int userId, int offset)
        {
            string temp = await client.GetStringAsync($"{uri}/private?userId={userId}&offset={offset}");
            if (!String.IsNullOrEmpty(temp))
            {
                 return JsonSerializer.Deserialize<List<TrainingShortVersion>>(temp);
            }

            return null;
        }

        public Task<List<TrainingShortVersion>> GetTrainingsForUser(int userId, int offset)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<TrainingSVWithTime>> GetTrainingsInWeekForUser(int userId, int weekNumber)
        {

            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}?userId={userId}&weekNumber={weekNumber}");
            string content = await responseMessage.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(content))
            {
               return JsonSerializer.Deserialize<List<TrainingSVWithTime>>(content);
            }
            
            return null;
        }

        public async Task EditTraining(TrainingModel training)
        {
            await client.PutAsync($"{uri}/{training.Id}", PrepareObjectForRequest(training));
        }

        public async Task DeleteTraining(int id)
        {
            await client.DeleteAsync($"{uri}/{id}");
        }

        public async Task<int> AddExerciseToTraining(int trainingId, ExerciseModel exercise)
        {
            
           HttpResponseMessage responseMessage = await client.PostAsync($"{uri}/{trainingId}/exercises", PrepareObjectForRequest(exercise));
           return int.Parse(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task EditExerciseInTraining(int trainingId,ExerciseModel exercise)
        {
            await client.PutAsync($"{uri}/{trainingId}/exercises/{exercise.Id}", PrepareObjectForRequest(exercise));
        }

        public async Task DeleteExerciseFromTraining(int trainingId, int exerciseId)
        {
            await client.DeleteAsync($"{uri}/{trainingId}/exercises/{exerciseId}");
        }

        public async Task<List<TrainingSVWithTime>> GetTrainingForToday(int userId)
        {
            string temp = await client.GetStringAsync($"{uri}/today?userId={userId}");
            if (!String.IsNullOrEmpty(temp))
            {
                return JsonSerializer.Deserialize<List<TrainingSVWithTime>>(temp);
            }

            return null;
        }
    }
}