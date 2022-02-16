using DSU22_Team4.Models.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.ViewModels
{
    public class SessionDetailViewModel 
    {
        public List<Serie> Series { get; set; }

        

        public int NextPage { get; set; } 
        public int PreviousPage { get; set; }

        public int CurrentPage { get; set; } = 1;

        public SessionDetailViewModel(List<Serie> series)
        {
            Series = series;
            SplitList(series, CurrentPage);
            NextPage = CurrentPage + 1;
           
        }


        public List <Serie> SplitList(List <Serie> series, int page)
        {
            page = page - 1 * 5;
            while(series.Count > 0)
            {
                
                return series.Skip(page).Take(5).ToList();
            }
           
            return null;
        }

        public int GetTotalNumOfShots(List <Serie> series)
        {
            int shots = 0;
            foreach (var serie in series)
            {
                foreach (var shot in serie.Shots)
                {
                    shots += 1;
                }
            }
            return shots;
        }

        public int GetTotalNumOfHits(List <Serie> series)
        {
            int hits = 0;
            foreach (var serie in series)
            {
                foreach (var shot in serie.Shots)
                {
                    if (shot.Result == "hit")
                    {
                        hits += 1;
                    }
                }
            }
            return hits;
        }

        //public List <Serie> SkipListItems(List <Serie> series)
        //{

        //    while (series.Count > 0)
        //    {
        //        return series.Skip(5).Take(5).ToList();
        //    }
        //    return null;
        //}


    }
}
