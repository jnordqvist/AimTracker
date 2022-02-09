using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.Poco
{
    public class TrainingSession
    {
        public string Id { get; set; }
        public string IbuId { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public virtual Geometry Geometry { get; set; }
        public virtual ICollection<SerieDto> Results { get; set; }


        public TrainingSession(TrainingSessionDto trainingSession)
        {
            Id = trainingSession.Id;
            IbuId = trainingSession.IbuId;
            Date = trainingSession.Date;
            Location = trainingSession.Location;
            Geometry = trainingSession.Geometry;
            Results = trainingSession.Results;
        }

        public TrainingSession()
        {

        }
    }
}
