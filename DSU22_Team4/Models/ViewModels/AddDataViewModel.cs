using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4.Models.ViewModels
{
    public class AddDataViewModel
    {
        public DateTime Date { get; set; }
        public DateTime SleepTime { get; set; }
        public DateTime AwakeTime { get; set; }
        public string Quality { get; set; }
        public AddDataViewModel()
        {

        }
    }
}
