using System.Collections.Generic;

namespace GraphineTracePatientMonitoringSystem.Models
{
    public class PatientDashboardViewModel
    {
        public Patient Patient { get; set; } = null!;

        // Last pressure / ulcer check summary
        public UlcerCheckResult LastUlcerCheck { get; set; } = null!;

        // Recent alerts to show in a small list/card
        public List<Alert> RecentAlerts { get; set; } = new();

        // Recent clinician reviews / recommendations (if you want to show them)
        public List<ClinicianReview> RecentReviews { get; set; } = new();
    }
}
