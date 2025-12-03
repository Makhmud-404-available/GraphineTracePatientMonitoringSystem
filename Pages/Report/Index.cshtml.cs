using System;
using System.Collections.Generic;
using GraphineTracePatientMonitoringSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraphineTracePatientMonitoringSystem.Pages.Report
{
    public class IndexModel : PageModel
    {
        public PatientReportViewModel ModelData { get; private set; } = new();

        public void OnGet()
        {
            var patient = GetDemoPatient();
            var alerts = GetDemoAlerts(patient.Id);
            var lastUlcerCheck = GetLastUlcerCheck(patient.Id);

            ModelData = new PatientReportViewModel
            {
                Patient = patient,
                ReportDate = DateTime.Today,
                Alerts = alerts,
                LatestUlcerCheck = lastUlcerCheck
            };
        }

        private Patient GetDemoPatient()
        {
            return new Patient
            {
                Id = 1,
                FullName = "Jane Doe",
                Age = 78,
                RoomNumber = "12A",
                CurrentHealthStatus = "Stable"
            };
        }

        private List<Alert> GetDemoAlerts(int patientId)
        {
            return new List<Alert>();
        }

        private UlcerCheckResult? GetLastUlcerCheck(int patientId)
        {
            // return null or a demo UlcerCheckResult
            return null;
        }
    }