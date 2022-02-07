﻿using DSU22_Team4.Infrastructure;
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
        private readonly string startDateEndpoint = "startDate=";
        private readonly string endDateEndpoint = "endDate=";

        public Repository(IApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public async Task<List<TrainingSession>> GetAimTrackerData()
        {
            var athleteId = "BTSWE11008199501";
            var trainingSessions = await apiClient.GetAsync<TrainingSession>($"{baseEndPoint}{athleteId}");
            //await DoAsync(trainingSessions);
            List<TrainingSession> trainingSessions1 = new List <TrainingSession>
            {
                trainingSessions
            };

            return trainingSessions1;
        }

        public async Task<List<TrainingSession>> GetAimTrackerDataByDate(string athleteId, string startDate, string endDate)
        {
            var training = await apiClient.GetAsync <List<TrainingSession>>($"{basePoint}" +
                $"{athleteId}?{startDateEndpoint}{startDate}&{endDateEndpoint}{endDate}");
            
            return training;
        }

        //private async Task<TrainingSession> DoAsync(TrainingSession trainingSession)
        //{
        //    var athleteId = 1;
        //    var result = await apiClient.GetAsync<TrainingSession>($"{baseEndPoint}{athleteId}");
        //    trainingSession.Date = result.Date;
        //    trainingSession.IbuId = result.IbuId;
        //    trainingSession.Id = result.Id;
        //    trainingSession.Location = result.Location;
        //    trainingSession.Results = result.Results;

        //    return trainingSession;
        //}

    }
}
