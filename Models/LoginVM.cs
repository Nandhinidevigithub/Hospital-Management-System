using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSysSprint_CoreMvc.Models
{
    public class LoginVM
    {
       public int RoleName { get; set; }

        [Required(ErrorMessage = "Enter UserName")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

       // public short? RoleId { get; set; }
    }
}
