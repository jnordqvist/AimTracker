using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.Poco
{
    public class TrainingSession
    {
        public string Id { get; set; }
        public TrainingSession(TrainingSessionDto trainingSession)
        {
            Id = trainingSession.Id;
        }
    }
}
