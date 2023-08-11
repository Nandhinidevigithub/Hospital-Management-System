using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSysSprint_CoreMvc.Models
{
    public class DoctorVM
    {
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Please Enter the doctorName"), MaxLength(30)]
        public string DoctorName { get; set; }
        [Required]
        public int? DepartmentId { get; set; }
        public virtual DepartmentVM Department { get; set; }
        public string DepartmentName { get; set; }
    }
}
