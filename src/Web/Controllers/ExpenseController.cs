using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class ExpenseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GroupedByMonth()
        {
            var service = new ExpenseService();
            var data = await service.GetGroupedByMonth();
            var model = data.Select(item => new MonthlyExpenseViewModel 
            {
                Month = item.Name, 
                Value = item.Value 
            });

            return View(model);
        }

        public async Task<IActionResult> GroupedByCategory()
        {
            var service = new ExpenseService();
            var data = await service.GetGroupedByCategory();
            var model = data.Select(item => new CategorizedExpenseViewModel
            {
                CategoryName = item.Name,
                Value = item.Value
            });

            return View(model);
        }

        public async Task<IActionResult> GroupedBySource()
        {
            var service = new ExpenseService();
            var data = await service.GetGroupedBySource();
            var model = data.Select(item => new SourceExpenseViewModel
            {
                SourceName = item.Name,
                Value = item.Value
            });

            return View(model);
        }
    }
}