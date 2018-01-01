using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class SearchJobsViewModel : BaseViewModel
    {
        public List<Job> Jobs { get; set; }

        [Display(Name = "Keyword: ")]
        public string Value { get; set; } = "";

        public SearchJobsViewModel()
        {
            Column = JobFieldType.All;

            Columns = new List<JobFieldType>();

            foreach (JobFieldType num in Enum.GetValues(typeof(JobFieldType))) {
                Columns.Add(num);
            }
        }
    }
}
