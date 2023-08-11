using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSysSprint_CoreMvc.Models
{
    public class LabTestVM
    {
        public int LabTestId { get; set; }
        [Required(ErrorMessage = "Please Enter the LabTestName"), MaxLength(30)]

        public string LabTestName { get; set; }
        [Required]
        public decimal? Price { get; set; }
    }
}
