using System;

namespace HospitalManagementSysSprint_CoreMvc.Models
{
    public class OutpatientVM
    {
        public int OutPatientId { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public DateTime? TreatmentDate { get; set; }
        public virtual DoctorVM Doctor { get; set; }

        public string DoctorName { get; set; }
    }
}
