using DSU22_Team4.Infrastructure;
using DSU22_Team4.Models.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Repositories
{
    public class Repository : IRepository
    {
        private readonly IApiClient apiClient;
        private readonly string baseEndPoint = "https://grupp8.dsvkurs.miun.se/api/Training/";
        private readonly string basePoint = "https://grupp8.dsvkurs.miun.se/api/history/Date/";
        private readonly string baseEndPointAthlete = "https://grupp8.dsvkurs.miun.se/api/athletes";
        private readonly string startDateEndpoint = "startDate=";
        private readonly string endDateEndpoint = "endDate=";

        public Repository(IApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public async Task<List<TrainingSessionDto>> GetAimTrackerData()
        {
            var athleteId = "BTSWE11008199501";
            var trainingSessions = await apiClient.GetAsync<TrainingSessionDto>($"{baseEndPoint}{athleteId}");
            //await DoAsync(trainingSessions);
            List<TrainingSessionDto> trainingSessions1 = new List <TrainingSessionDto>
            {
                trainingSessions
            };

            return trainingSessions1;
        }

        public async Task<List<TrainingSessionDto>> GetAimTrackerDataByDate(string athleteId, string startDate, string endDate)
        {

            var training = await apiClient.GetAsync <List<TrainingSessionDto>>($"{basePoint}" +
                $"{athleteId}?{startDateEndpoint}{startDate}&{endDateEndpoint}{endDate}");  
            return training;
        }

        public async Task<List<Athlete>> GetAthletesAsync()
        {
            var athletes = await apiClient.GetAsync<List<Athlete>>($"{baseEndPointAthlete}");
            return athletes;
        }


    }
}
