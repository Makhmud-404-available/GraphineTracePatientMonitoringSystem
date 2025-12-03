using System;

namespace GraphineTracePatientMonitoringSystem.Models
{
    // Simple view model for the main patient dashboard
    public class PatientDashboardViewModel
    {
        // 32x32 heat map values (1–255)
        public int[,] HeatMapValues { get; set; }

        public double PeakPressureIndex { get; set; }
        public double ContactAreaPercent { get; set; }
        public int MaxPressureValue { get; set; }

        public bool HasHighPressureAlert { get; set; }
        public string AlertMessage { get; set; }

        public PatientDashboardViewModel()
        {
            // Always create the 32x32 matrix
            HeatMapValues = new int[32, 32];
            AlertMessage = "";
        }
    }
}
