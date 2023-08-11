using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSysSprint_CoreMvc.Models
{
    public class OutBillVM
    {
        public int BillId { get; set; }
        public int? OutPatientId { get; set; }
        [Required]
        public decimal? DoctorFees { get; set; }
        public decimal? LabCharges { get; set; }

    }
}
