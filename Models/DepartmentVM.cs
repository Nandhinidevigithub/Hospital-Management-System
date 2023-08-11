using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSysSprint_CoreMvc.Models
{
    public class DepartmentVM
    {
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please Enter the DepartmentName"), MaxLength(30)]
        public string DepartmentName { get; set; }
        
    }
}
