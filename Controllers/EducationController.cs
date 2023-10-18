using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resume.Presentation.Data;
using Resume.Presentation.Models.Entitis.Education;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Resume.Presentation.Controllers
{
    public class EducationController : Controller
    {
        private readonly ResumeDbContext _context;

        public EducationController(ResumeDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult ListOfEducations()
        {
            List<Education> educations = _context.Educations.ToList();
            Education education = educations.First();
            return View();
        }
        public IActionResult CreateAnEducation()
        {
            
            Education EducationDataBase = new Education()
            {
                EducationTitle="MATH",
                EducationDuration="2023",
                Description="TEST"

            };
            _context.Educations.Add(EducationDataBase);
           _context.SaveChanges();
            return View();
        }
    }
}

