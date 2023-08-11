using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSysSprint_CoreMvc.Models
{
    public class RoomTypeVM
    {
        public int RoomTypeId { get; set; }
        [Required(ErrorMessage = "Please Enter the RoomTypeName")]
        public string RoomTypeName { get; set; }
        [Required]
        public decimal? ChargesPerDay { get; set; }

       

    }
}
