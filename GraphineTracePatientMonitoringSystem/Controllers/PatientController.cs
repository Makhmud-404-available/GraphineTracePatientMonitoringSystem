using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GraphineTracePatientMonitoringSystem.Models;

namespace GraphineTracePatientMonitoringSystem.Controllers
{
    public class PatientController : Controller
    {
        // --------------------------------------------------------------------
        // 1) PATIENT DASHBOARD  (wireframe screen 1)
        // URL: /Patient or /Patient/Index
        // --------------------------------------------------------------------
        public IActionResult Index()
        {
            ViewData["ActiveSection"] = "Dashboard";

            var patient = GetDemoPatient();
            var lastUlcerCheck = GetLastUlcerCheck(patient.Id);
            var alerts = GetDemoAlerts(patient.Id);
            var reviews = GetDemoReviews(patient.Id);

            var viewModel = new PatientDashboardViewModel
            {
                Patient = patient,
                LastUlcerCheck = lastUlcerCheck,
                RecentAlerts = alerts,
                RecentReviews = reviews
            };

            return View(viewModel);
        }

        // --------------------------------------------------------------------
        // 2) PATIENT PRESSURE ANALYSIS  (wireframe screen 2)
        //    Shows history of pressure / ulcer checks in a table + chart
        // URL: /Patient/PressureAnalysis
        // --------------------------------------------------------------------
        public IActionResult PressureAnalysis()
        {
            ViewData["ActiveSection"] = "Analysis";

            var patient = GetDemoPatient();
            var history = GetDemoPressureHistory(patient.Id);

            var viewModel = new PatientPressureAnalysisViewModel
            {
                Patient = patient,
                PressureChecks = history
            };

            return View(viewModel);
        }

        // --------------------------------------------------------------------
        // 3) DOCTOR COMMENTS & RECOMMENDATIONS  (wireframe screen 3)
        //    This is for the patient to READ comments.
        // URL: /Patient/ReviewClinician
        // (You can rename the view later if you want it to be Comments.cshtml)
        // --------------------------------------------------------------------
        [HttpGet]
        public IActionResult ReviewClinician()
        {
            ViewData["ActiveSection"] = "Comments";

            var patient = GetDemoPatient();
            var existingReviews = GetDemoReviews(patient.Id);
            ClinicianReview? existing = existingReviews.Count > 0 ? existingReviews[0] : null;

            var model = new ReviewClinicianViewModel
            {
                PatientId = patient.Id,
                ClinicianId = 1,
                ClinicianName = "Dr. Smith",
                Rating = existing?.Rating ?? 5,
                Comment = existing?.Comment ?? string.Empty
            };

            return View(model);
        }

        // Handles the feedback form submit (Save as draft / Submit)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ReviewClinician(ReviewClinicianViewModel model)
        {
            ViewData["ActiveSection"] = "Comments";

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // In a real app: save to database here.
            TempData["ReviewSaved"] = "Doctor feedback saved (demo only).";

            // Show the same page again so the patient sees the feedback.
            return RedirectToAction(nameof(ReviewClinician));
        }

        // --------------------------------------------------------------------
        // 4) ALERTS  (wireframe screen 4)
        //    List of recent alerts for this patient.
        // URL: /Patient/Alerts
        // --------------------------------------------------------------------
        public IActionResult Alerts()
        {
            ViewData["ActiveSection"] = "Alerts";

            var patient = GetDemoPatient();
            var alerts = GetDemoAlerts(patient.Id);

            // You can later create a PatientAlertsViewModel if you want.
            return View(alerts);
        }

        // ====================================================================
        // DEMO DATA HELPERS (NO DATABASE YET)
        // These methods just create fake data so the views have something
        // to display. This still counts as functionality.
        // ====================================================================

        private Patient GetDemoPatient()
        {
            return new Patient
            {
                Id = 1,
                FullName = "Dexter Morgan",
                Age = 65,
                HeightCm = 170,
                WeightKg = 72,
                Diagnosis = "Hypertension",
                Cause = "Disabled, bedridden"
            };
        }

        // Last ulcer / pressure check (used on Dashboard)
        private UlcerCheckResult GetLastUlcerCheck(int patientId)
        {
            return new UlcerCheckResult
            {
                Id = 1,
                PatientId = patientId,
                CheckTime = DateTime.Now.AddMinutes(-10),
                RiskLevel = "High",
                Notes = "High pressure on lower back detected in the last 10 minutes."
            };
        }

        // History of checks (used on PressureAnalysis page)
        private List<UlcerCheckResult> GetDemoPressureHistory(int patientId)
        {
            return new List<UlcerCheckResult>
            {
                new UlcerCheckResult
                {
                    Id = 1,
                    PatientId = patientId,
                    CheckTime = DateTime.Now.AddHours(-3),
                    RiskLevel = "Normal",
                    Notes = "Pressure within safe range."
                },
                new UlcerCheckResult
                {
                    Id = 2,
                    PatientId = patientId,
                    CheckTime = DateTime.Now.AddHours(-2),
                    RiskLevel = "Elevated",
                    Notes = "Slight increase in pressure on hips."
                },
                new UlcerCheckResult
                {
                    Id = 3,
                    PatientId = patientId,
                    CheckTime = DateTime.Now.AddHours(-1),
                    RiskLevel = "High",
                    Notes = "Sustained high pressure on lower back."
                }
            };
        }

        // Alerts used on Dashboard + Alerts page
        private List<Alert> GetDemoAlerts(int patientId)
        {
            return new List<Alert>
            {
                new Alert
                {
                    Id = 1,
                    PatientId = patientId,
                    Timestamp = DateTime.Now.AddMinutes(-30),
                    Type = "Pressure",
                    Severity = "High",
                    BodyArea = "Lower back",
                    Message = "High pressure detected for 45 minutes.",
                    IsAcknowledged = false
                },
                new Alert
                {
                    Id = 2,
                    PatientId = patientId,
                    Timestamp = DateTime.Now.AddHours(-2),
                    Type = "Movement",
                    Severity = "Medium",
                    BodyArea = "Hips",
                    Message = "No movement detected for 3 hours.",
                    IsAcknowledged = true
                },
                new Alert
                {
                    Id = 3,
                    PatientId = patientId,
                    Timestamp = DateTime.Now.AddHours(-4),
                    Type = "Pressure",
                    Severity = "Low",
                    BodyArea = "Shoulders",
                    Message = "Pressure returned to safe range.",
                    IsAcknowledged = true
                }
            };
        }

        // Example doctor review used on Comments page
        private List<ClinicianReview> GetDemoReviews(int patientId)
        {
            return new List<ClinicianReview>
            {
                new ClinicianReview
                {
                    Id = 1,
                    PatientId = patientId,
                    ClinicianId = 1,
                    Rating = 5,
                    Comment = "Monitor lower back closely. Reposition every 2 hours.",
                    CreatedAt = DateTime.Now.AddDays(-1)
                }
            };
        }
    }
}
