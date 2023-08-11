using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSysSprint_CoreMvc.Models
{
    public class PatientVM
       
    {
        public int PatientId { get; set; }

        [Required(ErrorMessage ="Please Enter the Name"), MaxLength(30)]
        public string PatientName { get; set; }

        [Required(ErrorMessage = "Please Enter the Age")]
        public short? Age { get; set; }
        public short? Weight { get; set; }

        [Required(ErrorMessage = "Please Enter the Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please Enter the Address")]
        public string Address { get; set; }

       // [RegularExpression]
        [Required(ErrorMessage = "Please Enter the Phoneno"), MaxLength(10)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Enter the Disease"), MaxLength(30)]
        public string Disease { get; set; }

    }
}
