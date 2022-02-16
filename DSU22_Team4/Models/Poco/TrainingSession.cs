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
        public virtual ICollection<Serie> Results { get; set; } = new List<Serie>();


        public TrainingSession(TrainingSessionDto trainingSession)
        {
            Id = trainingSession.Id;
            IbuId = trainingSession.IbuId;
            Date = trainingSession.Date;
            Geometry = new Geometry(trainingSession.Geometry);
            Location = trainingSession.Location;
            GetOneResult(trainingSession.Results); 
        }

        public TrainingSession()
        {

        }

        public void GetOneResult(ICollection<SerieDto> s)
        {
            foreach (var result in  s)
            {
                Results.Add(new Serie(result));
            }
        }
    }
}
