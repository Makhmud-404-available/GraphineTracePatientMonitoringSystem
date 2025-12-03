using System.ComponentModel.DataAnnotations;

namespace GraphineTracePatientMonitoringSystem.Models
{
    public class ReviewClinicianViewModel
    {
        public int PatientId { get; set; }

        public int ClinicianId { get; set; }

        public string ClinicianName { get; set; } = string.Empty;

        [Range(1, 5)]
        public int Rating { get; set; }

        [Display(Name = "Doctor feedback & recommendations")]
        [Required]
        [StringLength(2000)]
        public string Comment { get; set; } = string.Empty;
    }
}
