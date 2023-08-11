using System.Collections.Generic;

namespace HospitalManagementSysSprint_CoreMvc.Models
{
    public class RoomVM
    {
        public int RoomId { get; set; }
        public int? RoomTypeId { get; set; }
        public string Status { get; set; }

        public string RoomTypeName { get; set; }
        public virtual RoomTypeVM RoomType { get; set; }
    }
}
