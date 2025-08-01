using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Suqia.Data;
using Suqia.Models;
using System.Linq;
using System.Threading.Tasks;

public class DashboardController : Controller
{
    private readonly ApplicationDbContext _context;

    public DashboardController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var viewModel = new DashboardViewModel
        {
            // حساب عدد الطلبات المكتملة
            CompletedOrdersCount = await _context.Orders
                                        .CountAsync(o => o.Status == OrderStatus.Completed),

            // حساب عدد الزبائن
            CustomersCount = await _context.Customers.CountAsync(),

            // حساب عدد السائقين
            DriversCount = await _context.Drivers.CountAsync(),

            // حساب السعة الإجمالية للخزانات
            TotalTanksCapacity = await _context.Tanks.SumAsync(t => t.Capacity),

            // إيجاد المنطقة الأكثر طلباً
            MostRequestedArea = (await _context.Orders
                                     .Include(o => o.Customer)
                                    .ThenInclude(c => c.Area)
                                    .GroupBy(o => o.Customer.Area.Name)
                                    .OrderByDescending(g => g.Count())
                                    .Select(g => g.Key)
                                    .FirstOrDefaultAsync()) ?? "No orders yet"
        };

        return View(viewModel);
    }
}