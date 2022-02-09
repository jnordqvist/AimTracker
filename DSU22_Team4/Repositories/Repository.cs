using DSU22_Team4.Data;
using DSU22_Team4.Infrastructure;
using DSU22_Team4.Models.Dto;
using DSU22_Team4.Models.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Repositories
{
    public class Repository : IRepository
    {
        private readonly IApiClient _apiClient;
        private readonly string baseEndPoint = "https://grupp8.dsvkurs.miun.se/api/Training/";
        private readonly string basePoint = "https://grupp8.dsvkurs.miun.se/api/history/Date/";
        private readonly string baseEndPointAthlete = "https://grupp8.dsvkurs.miun.se/api/athletes";
        private readonly string startDateEndpoint = "startDate=";
        private readonly string endDateEndpoint = "endDate=";

        private readonly AppDbContext _db;

        public Repository(IApiClient apiClient, AppDbContext db)
        {
            _apiClient = apiClient;
            _db = db;
        }


        public async Task<List<TrainingSessionDto>> GetAimTrackerData()
        {
            var athleteId = "BTSWE11008199501";
            var trainingSessions = await _apiClient.GetAsync<TrainingSessionDto>($"{baseEndPoint}{athleteId}");

            //await DoAsync(trainingSessions);
            List<TrainingSessionDto> trainingSessions1 = new List <TrainingSessionDto>
            {
                trainingSessions
            };

            return trainingSessions1;
        }

        public async Task<List<TrainingSessionDto>> GetTrainingSessionsByDate(string athleteId, string startDate, string endDate)
        {
            var trainingSessions = await _apiClient.GetAsync <List<TrainingSessionDto>>($"{basePoint}" +
            $"{athleteId}?{startDateEndpoint}{startDate}&{endDateEndpoint}{endDate}");
            
            return trainingSessions;
        }

        public async Task<List<AthleteDto>> GetAthletesAsync()
        {
            var athletes = await _apiClient.GetAsync<List<AthleteDto>>($"{baseEndPointAthlete}");
            return athletes;
        }

        public void SeedAthletes(Athlete athlete)
        {
            _db.Add(athlete);
            _db.SaveChanges();
        }

    }
}
