using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IMapper _mapper;

        public ExpenseController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GroupedByMonth()
        {
            using var service = new ExpenseService();

            var data = await service.GetGroupedByMonth();
            var model = _mapper.Map<IEnumerable<MonthlyExpenseViewModel>>(data);

            return PartialView(model);
        }

        public async Task<IActionResult> GroupedByCategory()
        {
            using var service = new ExpenseService();

            var data = await service.GetGroupedByCategory();
            var model = _mapper.Map<IEnumerable<CategorizedExpenseViewModel>>(data);

            return PartialView(model);
        }

        public async Task<IActionResult> GroupedBySource()
        {
            using var service = new ExpenseService();

            var data = await service.GetGroupedBySource();
            var model = _mapper.Map<IEnumerable<SourceExpenseViewModel>>(data);

            return PartialView(model);
        }
    }
}