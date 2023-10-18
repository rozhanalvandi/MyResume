using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resume.Presentation.Data;
using Resume.Presentation.Models.Entitis.Education;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Resume.Presentation.Controllers
{
    public class EducationController : Controller
    {
        
        [HttpGet]
        public async Task<IActionResult> ListOfEducations()
        {
            return View();
        }
        public async Task<IActionResult> CreateAnEducation()
        {
            return RedirectToAction(nameof(ListOfEducations));
        }
        public async Task<IActionResult> DeleteAnEducation(int id)
        {

            
            return RedirectToAction(nameof(ListOfEducations));
        }
    }
}

