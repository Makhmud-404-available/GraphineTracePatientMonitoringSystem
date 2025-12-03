using System;

namespace GraphineTracePatientMonitoringSystem.Models
{
    public class UlcerCheckResult
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        // When the check was taken
        public DateTime CheckTime { get; set; }

        // What we measured (e.g. "Peak pressure index")
        public string MetricName { get; set; } = string.Empty;

        // Measured value as text (e.g. "145/95 mmHg" or "High")
        public string Value { get; set; } = string.Empty;

        // Risk level shown as coloured tags (Normal / Elevated / High)
        public string RiskLevel { get; set; } = string.Empty;

        // Body area where pressure is high (e.g. "Lower back")
        public string BodyArea { get; set; } = string.Empty;

        // Extra details or notes
        public string Notes { get; set; } = string.Empty;
    }
}
