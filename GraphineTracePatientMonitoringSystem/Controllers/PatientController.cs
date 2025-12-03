using Microsoft.AspNetCore.Mvc;

namespace GraphineTracePatientMonitoringSystem.Controllers
{
    public class PatientController : Controller
    {
        // GET: /Patient/Index
        public IActionResult Index()
        {
            ViewBag.ActivePage = "Dashboard";
            ViewData["Title"] = "Patient Dashboard";
            return View();
        }

        // GET: /Patient/PressureAnalysis
        public IActionResult PressureAnalysis()
        {
            ViewBag.ActivePage = "Analysis";
            ViewData["Title"] = "Patient Pressure Analysis";
            return View();
        }

        // GET: /Patient/ReviewClinician
        public IActionResult ReviewClinician()
        {
            ViewBag.ActivePage = "Comments";
            ViewData["Title"] = "Comments";
            return View();
        }

        // GET: /Patient/Alerts
        public IActionResult Alerts()
        {
            ViewBag.ActivePage = "Alerts";
            ViewData["Title"] = "Alerts";
            return View();
        }
    }
}
