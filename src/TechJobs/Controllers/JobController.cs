using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.ViewModels;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {
        private static JobData jobData;
        static JobController()
        {
            jobData = JobData.GetInstance();
        }
        public IActionResult Index(int id)
        {
            return View(jobData.Jobs[id]);
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            if (newJobViewModel != null && newJobViewModel.Name != null && newJobViewModel.Name.Trim().Length != 0) {
                Models.Employer employer = jobData.Employers.Find(newJobViewModel.EmployerID);
                Models.Location location = jobData.Locations.Find(newJobViewModel.LocationID);
                Models.PositionType positionType = jobData.PositionTypes.Find(newJobViewModel.PositionTypeID);
                Models.CoreCompetency coreCompetency = jobData.CoreCompetencies.Find(newJobViewModel.CoreCompetencyID);

                Models.Job newJob = new Models.Job
                {
                    Name = newJobViewModel.Name,
                    Employer = employer,
                    Location = location,
                    PositionType = positionType,
                    CoreCompetency = coreCompetency
                };
                jobData.Jobs.Add(newJob);
                return View("Index", newJob);
            }
            return View(newJobViewModel);
        }
    }
}
