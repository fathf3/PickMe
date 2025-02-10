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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
