using System;

namespace GraphineTracePatientMonitoringSystem.Models
{
    // View model for the main patient dashboard page
    public class PatientDashboardViewModel
    {
        // 32x32 heat map values (1–255)
        public int[,] HeatMapValues { get; set; } = new int[32, 32];

        // Calculated metrics
        public double PeakPressureIndex { get; set; }
        public double ContactAreaPercent { get; set; }
        public int MaxPressureValue { get; set; }

        // Alert banner
        public bool HasHighPressureAlert { get; set; }
        public string AlertMessage { get; set; } = string.Empty;

        // --- Patient details shown on the dashboard ---
        public string PatientName { get; set; } = "Dexter Morgan";
        public int Age { get; set; } = 65;
        public string Disease { get; set; } = "Hypertension";
        public string Cause { get; set; } = "Disabled, bedridden";

        // --- Simple vitals for the cards on the left ---
        public int HeartRate { get; set; } = 98;
        public string HeartRateStatus { get; set; } = "Normal";

        public string BloodPressure { get; set; } = "102 / 72";
        public string BloodPressureStatus { get; set; } = "Normal";
        public string BloodPressureUnit { get; set; } = "mmHg";
    }
}
