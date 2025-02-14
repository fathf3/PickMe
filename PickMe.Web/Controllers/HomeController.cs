using Microsoft.AspNetCore.Mvc;
using PickMe.Business.Services.Abstractions;
using PickMe.Web.Models;
using System.Diagnostics;

namespace PickMe.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISurveyService _surveyService;

        public HomeController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        public async Task<IActionResult> Index()
        {
            var surveys = await _surveyService.GetActiveSurveysAsync();
            return View(surveys);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error(int? code)
        {
            if (code.HasValue)
            {
                ViewBag.StatusCode = code.Value;
            }
            return View();
        }
    }
}
