using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GraphineTracePatientMonitoringSystem.Models;

namespace GraphineTracePatientMonitoringSystem.Controllers
{
    public class PatientController : Controller
    {
        // GET: /Patient/Index
        public IActionResult Index()
        {
            ViewBag.ActivePage = "Dashboard";
            ViewData["Title"] = "Patient Dashboard";

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

                    if (value >= 100)
                    {
                        contactCells++;
                    }
                }
            }

            model.MaxPressureValue = maxValue;
            model.PeakPressureIndex = Math.Round(maxValue / 255.0 * 10.0, 1);

            double percent = contactCells / (double)totalCells * 100.0;
            model.ContactAreaPercent = Math.Round(percent, 1);

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

        // GET: /Patient/PressureAnalysis
        public IActionResult PressureAnalysis()
        {
            ViewBag.ActivePage = "Analysis";
            ViewData["Title"] = "Patient Pressure Analysis";

            var readings = new List<PressureReading>
            {
                new PressureReading
                {
                    DateTime = DateTime.Today.AddHours(9),
                    MetricName = "Peak Pressure Index",
                    Value = "8.7",
                    RiskLevel = "High",
                    BodyArea = "Lower back"
                },
                new PressureReading
                {
                    DateTime = DateTime.Today.AddHours(8),
                    MetricName = "Contact Area %",
                    Value = "67.3%",
                    RiskLevel = "Moderate",
                    BodyArea = "Right hip"
                },
                new PressureReading
                {
                    DateTime = DateTime.Today.AddDays(-1).AddHours(20),
                    MetricName = "Peak Pressure Index",
                    Value = "6.2",
                    RiskLevel = "Moderate",
                    BodyArea = "Left heel"
                },
                new PressureReading
                {
                    DateTime = DateTime.Today.AddDays(-1).AddHours(10),
                    MetricName = "Contact Area %",
                    Value = "45.1%",
                    RiskLevel = "Low",
                    BodyArea = "Shoulders"
                }
            };

            return View(readings);
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

            var alerts = new List<Alert>
            {
                new Alert
                {
                    Time = DateTime.Today.AddHours(10).AddMinutes(12),
                    Title = "High blood pressure detected",
                    Message = "Please take BP reading now.",
                    Severity = "High"
                },
                new Alert
                {
                    Time = DateTime.Today.AddHours(9).AddMinutes(30),
                    Title = "No movement detected for 3 hours",
                    Message = "Please adjust your position.",
                    Severity = "Medium"
                },
                new Alert
                {
                    Time = DateTime.Today.AddHours(6),
                    Title = "Pressure returned to safe range",
                    Message = "Monitoring continues.",
                    Severity = "Normal"
                }
            };

            return View(alerts);
        }
    }
}
