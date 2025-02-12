﻿using Microsoft.AspNetCore.Mvc;
using PickMe.Business.Services.Abstractions;

namespace PickMe.Web.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        public async Task<IActionResult> Index()
        {
            var reports = await _reportService.GetAllReportsAsync();
            return View(reports);
        }
    }
}
