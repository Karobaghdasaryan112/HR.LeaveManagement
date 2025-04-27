using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.MVC.Controllers
{
    public class LeaveAllocationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
