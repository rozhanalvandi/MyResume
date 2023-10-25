 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Implementation;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Entities.Education;
using Resume.Domain.Entities.MySkills;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Resume.Presentation.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class EducationController : Controller
    {
        private readonly IEducationService _educationService;
        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;

        }
        public async Task<IActionResult> ListOfAnEducation()
        {
            var model = await _educationService.GetListOfEducations();
            return View(model);
        }
        public async Task<IActionResult> CreateAnEducation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAnEducation(Education education)
        {
            await _educationService.AddAnEducationToDatabase(education);
            return RedirectToAction(nameof(ListOfAnEducation));
        }
        public async Task<IActionResult> EditAnEducation(int educationId)
        {
            var education = await _educationService.GetEducationById(educationId);
            return View(education);
        }
        [HttpPost]
        public async Task<IActionResult> EditAnEducation(Education education)
        {
            await _educationService.AddAnEducationToDatabase(education);
            return RedirectToAction(nameof(ListOfAnEducation));

        }
        public async Task<IActionResult> DeleteAnEducation(int educationId)
        {
            var education = await _educationService.GetEducationById(educationId);
            return View(education);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAnEducation(Education education)
        {
            await _educationService.DeleteAnEducation(education);
            return RedirectToAction(nameof(ListOfAnEducation));

        }
    }
}