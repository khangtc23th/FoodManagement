using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wed.Models.EF;

namespace wed.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReportController : Controller
    {
        private readonly FoodContext _dbContext;

        public ReportController(FoodContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Hiển thị trang biểu đồ
        public IActionResult IncomeByMonth()
        {
            return View();
        }

        // Trả dữ liệu doanh thu cho Chart.js
        [HttpGet]
        public async Task<IActionResult> getIncomeByMonth(int year)
        {
            var items =
             from k in
                 (
                     from o in _dbContext.Orders
                         .Where(i => i.CreatedOn.Value.Year == year
                                  && i.UpdateOn != null)
                     join d in _dbContext.Details
                         on o.Id equals d.OrderId
                     select new
                     {
                         Month = o.CreatedOn.Value.Month,
                         Income = d.Amount * d.Price * 1.1 + 30000
                     }
                 )
             group k by k.Month into g
             select new
             {
                 Months = g.Key,
                 Incomes = g.Sum(p => p.Income)
             };

            return Ok(await items.OrderBy(p=>p.Months).ToListAsync());
        }
    }
}