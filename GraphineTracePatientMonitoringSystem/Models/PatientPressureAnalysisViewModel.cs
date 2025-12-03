using System.Collections.Generic;

namespace GraphineTracePatientMonitoringSystem.Models
{
    public class PatientPressureAnalysisViewModel
    {
        public Patient Patient { get; set; } = null!;

        // List of checks that fill the table
        public List<UlcerCheckResult> PressureChecks { get; set; } = new();
    }
}
