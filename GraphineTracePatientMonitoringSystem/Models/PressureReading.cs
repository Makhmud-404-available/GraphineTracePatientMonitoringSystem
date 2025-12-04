using System;

namespace GraphineTracePatientMonitoringSystem.Models
{
    // One row in the pressure analysis table
    public class PressureReading
    {
        public DateTime DateTime { get; set; }
        public string MetricName { get; set; } = "";
        public string Value { get; set; } = "";
        public string RiskLevel { get; set; } = "";  // "Low", "Moderate", "High"
        public string BodyArea { get; set; } = "";
    }
}
