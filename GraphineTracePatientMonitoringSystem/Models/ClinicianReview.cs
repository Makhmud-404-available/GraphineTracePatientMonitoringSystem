using System;

namespace GraphineTracePatientMonitoringSystem.Models
{
    public class ClinicianReview
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int ClinicianId { get; set; }

        // Simple 1–5 rating if you want to use it
        public int Rating { get; set; }

        // Main feedback / recommendations text
        public string Comment { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}
