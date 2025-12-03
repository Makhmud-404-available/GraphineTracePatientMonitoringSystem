using System;
using System.Collections.Generic;
using GraphineTracePatientMonitoringSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraphineTracePatientMonitoringSystem.Pages.Alerts
{
    public class IndexModel : PageModel
    {
        public List<Alert> Alerts { get; private set; } = new();

        public void OnGet()
        {
            Alerts = GetDemoAlerts();
        }

        private List<Alert> GetDemoAlerts()
        {
            return new List<Alert>
            {
                new Alert
                {
                    Id = 1,
                    PatientId = 1,
                    Timestamp = DateTime.Now.AddMinutes(-30),
                    Type = "Fall",
                    Severity = "High",
                    Message = "Possible fall detected in room 12",
                    IsAcknowledged = false
                },
                new Alert
                {
                    Id = 2,
                    PatientId = 2,
                    Timestamp = DateTime.Now.AddHours(-1),
                    Type = "LowBattery",
                    Severity = "Low",
                    Message = "Sensor battery low",
                    IsAcknowledged = true
                }
            };
        }
    }