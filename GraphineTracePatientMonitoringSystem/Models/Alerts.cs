using System;

namespace GraphineTracePatientMonitoringSystem.Models
{
    // One alert item on the alerts page
    public class Alert
    {
        public DateTime Time { get; set; }
        public string Title { get; set; } = "";
        public string Message { get; set; } = "";
        public string Severity { get; set; } = "";   // "High", "Medium", "Normal"
    }
}
