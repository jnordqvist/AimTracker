using DSU22_Team4.Models.Poco;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.ViewModels
{
    public class StatisticsViewModel
    {
        public Athlete Athlete { get; set; }
        [Display(Name = "Training Session")]
        public TrainingSession SelectedTrainingSession { get; set; }
        public IEnumerable<SelectListItem> DropDownTrainingSessions { get; set; }
        public int Intensity { get; set; }
        public StatisticsViewModel(Athlete athlete, TrainingSession session ,IEnumerable<SelectListItem> selectListItems, int intensity)
        {
            Athlete = athlete;
            DropDownTrainingSessions = selectListItems;
            SelectedTrainingSession = session;
            Intensity = intensity;
        }
    }
}
