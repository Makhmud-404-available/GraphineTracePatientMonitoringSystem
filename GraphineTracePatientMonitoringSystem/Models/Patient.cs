namespace GraphineTracePatientMonitoringSystem.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }

        public double HeightCm { get; set; }
        public double WeightKg { get; set; }

        public string Diagnosis { get; set; } = string.Empty;
        public string Cause { get; set; } = string.Empty;

        // added back for old views
        public string? RoomNumber { get; set; }
        public string CurrentHealthStatus { get; set; } = string.Empty;
    }
}
