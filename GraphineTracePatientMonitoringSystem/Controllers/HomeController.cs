using Microsoft.AspNetCore.Mvc;

namespace GraphineTracePatientMonitoringSystem.Controllers
{
    public class HomeController : Controller
    {
        // When user goes to / or /Home/Index,
        // send them straight to the Patient Dashboard.
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Patient");
        }
    }
}
