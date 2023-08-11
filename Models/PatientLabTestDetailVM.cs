using System;

namespace HospitalManagementSysSprint_CoreMvc.Models
{
    public class PatientLabTestDetailVM
    {
        public int Id { get; set; }
        public int? LabTestId { get; set; }
        public int? PatientId { get; set; }
        public DateTime? TestDate { get; set; }
        public string LabTestName { get; set; }
        public string PatientName { get; set; }

        public virtual PatientVM Patient { get; set; }
        public virtual LabTestVM LabTest { get; set; }
    }
}
