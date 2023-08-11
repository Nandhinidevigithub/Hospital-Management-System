using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSysSprint_CoreMvc.Models
{
    public class RegisterVM
    {
        public int UserId { get; set; }

        //public int? RoleId { get; set; }
        [Required(ErrorMessage = "Enter UserName")]
        public string UserName { get; set; }

        [RegularExpression("\\d{​​​​​10}​​​​​", ErrorMessage = "Invalid Mobile Number")]
        [Display(Name = "Cell Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password do not match")]
        public string ConfirmPassword{get;set; }
        public int RoleId { get; set; }
    }
}
