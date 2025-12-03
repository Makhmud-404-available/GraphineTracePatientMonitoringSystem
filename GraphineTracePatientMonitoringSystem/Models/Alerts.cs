using System;

namespace GraphineTracePatientMonitoringSystem.Models
{
    public class Alert
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public DateTime Timestamp { get; set; }

        // Category, e.g. Pressure / Movement / Oxygen
        public string Type { get; set; } = string.Empty;

        // High / Medium / Low
        public string Severity { get; set; } = string.Empty;

        // Body area affected (e.g. "Lower back")
        public string BodyArea { get; set; } = string.Empty;

        // Main alert message text
        public string Message { get; set; } = string.Empty;

        // Whether the patient / clinician has acknowledged it
        public bool IsAcknowledged { get; set; }
    }
}
