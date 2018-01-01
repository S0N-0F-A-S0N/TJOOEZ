﻿using System;
using System.Collections.Generic;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class JobFieldsViewModel : BaseViewModel
    {
        public IEnumerable<JobField> Fields { get; set; }
        public JobFieldsViewModel()
        {
            Columns = new List<JobFieldType>();
            foreach (JobFieldType enumVal in Enum.GetValues(typeof(JobFieldType))) {
                Columns.Add(enumVal);
            }
        }
    }
}