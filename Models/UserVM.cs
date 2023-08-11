using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSysSprint_CoreMvc.Models
{
    public class UserVM
    {
        public int UserId { get; set; }
        public int? RoleId { get; set; }
        [Required(ErrorMessage = "Enter Email Id")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter Phoneno")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Enter Password ")]
        public string Password { get; set; }

       // public virtual Role Role { get; set; }
    }
}
