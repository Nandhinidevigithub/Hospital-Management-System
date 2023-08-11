using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSysSprint_CoreMvc.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
