using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSysSprint_CoreMvc.Models
{
    public class InBillVM
    {
        public int BillId { get; set; }
        public int? InPatientId { get; set; }
        [Required(ErrorMessage = "Please Enter the doctorFees")]
        public decimal? DoctorFees { get; set; }
       
        public decimal? OperationCharges { get; set; }
        
        public decimal? MedicineCharges { get; set; }
        public decimal? RoomCharges { get; set; }
        public decimal? LabCharges { get; set; }


    }
}
