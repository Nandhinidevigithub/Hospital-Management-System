using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSysSprint_CoreMvc.Models
{
    public class InpatientVM
    {
        public int InPatientId { get; set; }

        [Required(ErrorMessage = "Please Enter the PatientId")]
        public int? PatientId { get; set; }

        [Required(ErrorMessage = "Please Enter the DoctorId")]
        public int? DoctorId { get; set; }

        [Required(ErrorMessage = "Please Enter the AdmissionDate")]
        public DateTime? AdmissionDate { get; set; }
        [Required(ErrorMessage = "Please Enter the RoomId")]
        public int? RoomId { get; set; }
        public virtual DoctorVM Doctor { get; set; }
        
         public virtual PatientVM Patient { get; set; }
        // public virtual RoomTypeVM RoomType { get; set; }
        public string DoctorName { get; set; }

        public string PatientName { get; set; }
    }
}
