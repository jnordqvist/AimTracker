﻿using DSU22_Team4.Data;
using DSU22_Team4.Models.Poco;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Repositories
{
    public class MockRepository//://IStatsDbRepository
    {
        private readonly string basePath;
        private readonly AppDbContext _db;
        public MockRepository(IWebHostEnvironment environment, AppDbContext db)
        {
            basePath = $@"{environment.ContentRootPath}\Mock\";
            _db = db;

            SeedAthletes();
        }

        public void UpdateAthlete(Athlete athlete)
        {
            throw new NotImplementedException();
        }

        public async Task<Athlete> GetAthleteAsync()
        {
            await Task.Delay(0);
            return GetTestData<Athlete>("shootings.json");
        }

        public Athlete GetAthleteById(string id)
        {
            throw new NotImplementedException();
        }

        public T GetTestData<T>(string testfile)
        {
            var path = $"{basePath}{testfile}";
            string data = File.ReadAllText(path);
            var test = JsonConvert.DeserializeObject<T>(data);
            return test;
        }

        public void Seed(Athlete a)
        {
            throw new NotImplementedException();
        }

        private async void SeedAthletes()
        {
            if (_db.Athlete.Count() == 0)
            {
                var athletes = await GetAthleteAsync();
                _db.Add(athletes);
                _db.SaveChanges();
            }
        }

        public void AddSleepToAthlete(Athlete athlete, Sleep sleep)
        {
            throw new NotImplementedException();
        }
    }
}
