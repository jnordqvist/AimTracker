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
    public class MockRepository : IStatsDbRepository
    {
        private readonly string basePath;

        public MockRepository(IWebHostEnvironment environment)
        {
            basePath = $@"{environment.ContentRootPath}\Mock\";
        }

        public async Task<TrainingSession> GetSessionAsync()
        {
            await Task.Delay(0);
            return GetTestData<TrainingSession>("shootings.json");
        }

        public T GetTestData<T>(string testfile)
        {
            var path = $"{basePath}{testfile}";
            string data = File.ReadAllText(path);
            var test = JsonConvert.DeserializeObject<T>(data);
            return test;
        }
    }
}
