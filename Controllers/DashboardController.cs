using Microsoft.AspNetCore.Mvc;
using Soqia.Data;
using System.Linq;

namespace Soqia.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["TotalOrders"] = _context.Orders.Count();
            ViewData["TotalCustomers"] = _context.Customers.Count();
            ViewData["TotalTanks"] = _context.Tanks.Count();
            ViewData["TotalDrivers"] = _context.Drivers.Count();
            return View();
        }
    }
}
