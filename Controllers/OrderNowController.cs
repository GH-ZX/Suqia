using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Soqia.Data;
using Soqia.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Soqia.Controllers
{
    [Authorize]
    public class OrderNowController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderNowController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Step 1: Select a Region
        public async Task<IActionResult> SelectRegion()
        {
            var regions = await _context.Regions.ToListAsync();
            return View(regions);
        }

        // Step 2: Select a Tank from the chosen region
        public async Task<IActionResult> SelectTank(int regionId)
        {
            var tanks = await _context.Tanks
                .Where(t => t.RegionId == regionId)
                .OrderBy(t => t.Price)
                .ToListAsync();
            ViewData["RegionId"] = regionId;
            return View(tanks);
        }

        // Step 3: Create the order
        public async Task<IActionResult> CreateOrder(int tankId)
        {
            var tank = await _context.Tanks.FindAsync(tankId);
            if (tank == null)
            {
                return NotFound();
            }

            var order = new Order
            {
                TankId = tankId,
                Tank = tank
            };
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                // For simplicity, we'll find or create a customer based on the logged-in user's email.
                var user = await _context.Users.FirstAsync(u => u.UserName == User.Identity.Name);
                var customer = await _context.Customers.FirstOrDefaultAsync(c => c.PhoneNumber == user.Email);
                if (customer == null)
                {
                    customer = new Customer { Name = user.UserName, PhoneNumber = user.Email, Address = "Default Address", RegionId = _context.Tanks.Find(order.TankId).RegionId };
                    _context.Customers.Add(customer);
                }
                order.Customer = customer;
                order.OrderTime = System.DateTime.Now;
                order.Status = "Pending";
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(OrderSuccess));
            }
            return View(order);
        }
        
        public IActionResult OrderSuccess()
        {
            return View();
        }
    }
}
