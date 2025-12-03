using Microsoft.AspNetCore.Mvc;
using GraphineTracePatientMonitoringSystem.Models;
using System;

namespace GraphineTracePatientMonitoringSystem.Controllers
{
    public class PatientController : Controller
    {
        // GET: /Patient/Index
        public IActionResult Index()
        {
            ViewBag.ActivePage = "Dashboard";
            ViewData["Title"] = "Patient Dashboard";

            // Create a simple model and fill heat map with random data
            var model = new PatientDashboardViewModel();

            var random = new Random();

            int maxValue = 0;
            int contactCells = 0;
            int totalCells = 32 * 32;

            // Fill 32x32 matrix with random values (1–255)
            for (int row = 0; row < 32; row++)
            {
                for (int col = 0; col < 32; col++)
                {
                    int value = random.Next(1, 256); // 1 to 255
                    model.HeatMapValues[row, col] = value;

                    if (value > maxValue)
                    {
                        maxValue = value;
                    }

                    // count “contact area” as cells above a simple threshold
                    if (value >= 100)
                    {
                        contactCells++;
                    }
                }
            }

            model.MaxPressureValue = maxValue;

            // Very simple formula for Peak Pressure Index (0–10 scale)
            model.PeakPressureIndex = Math.Round(maxValue / 255.0 * 10.0, 1);

            // Contact Area % (cells above 100)
            double percent = contactCells / (double)totalCells * 100.0;
            model.ContactAreaPercent = Math.Round(percent, 1);

            // Simple rule for alert
            if (maxValue >= 180)
            {
                model.HasHighPressureAlert = true;
                model.AlertMessage = "High pressure region detected in last 10 minutes.";
            }
            else
            {
                model.HasHighPressureAlert = false;
                model.AlertMessage = "No critical pressure regions at the moment.";
            }

            return View(model);
        }

        public IActionResult PressureAnalysis()
        {
            ViewBag.ActivePage = "Analysis";
            ViewData["Title"] = "Patient Pressure Analysis";
            return View();
        }

        public IActionResult ReviewClinician()
        {
            ViewBag.ActivePage = "Comments";
            ViewData["Title"] = "Comments";
            return View();
        }

        public IActionResult Alerts()
        {
            ViewBag.ActivePage = "Alerts";
            ViewData["Title"] = "Alerts";
            return View();
        }
    }
}
