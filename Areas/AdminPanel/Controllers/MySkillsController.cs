using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Entities.MySkills;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Resume.Presentation.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class MySkillsController : Controller
    {
        public MySkillsController(IMyskillsService myskillsService)
        {
            _myskillsService = myskillsService;
        }

        public IMyskillsService _myskillsService { get; }

        public async Task<IActionResult> ListOfMySkills()
        {
            var skills = await _myskillsService.GetListOfMySkills();
            return View(skills);
        }
        public async Task<IActionResult> CreateMySkills()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> CreateMySkills(MySkills mySkills)
        {
            await _myskillsService.AddMySkillSToDataBase(mySkills);
            return RedirectToAction(nameof(ListOfMySkills));

        }
        public async Task<IActionResult> EditMySkills(int myskillsId)
        {
            var myskill = await _myskillsService.GetMySkillsById(myskillsId);
            return View(myskill);

        }
        [HttpPost]
        public async Task<IActionResult> EditMySkills(MySkills mySkills)
        {
            await _myskillsService.EditMYSkills(mySkills);
            return RedirectToAction(nameof(ListOfMySkills));

        }
        public async Task<IActionResult> DeleteMySkills(int myskillsId)
        {
            var myskill = await _myskillsService.GetMySkillsById(myskillsId);
            return View(myskill);

        }
        [HttpPost]
        public async Task<IActionResult> DeleteMySkills(MySkills mySkills)
        {
            await _myskillsService.DeleteMYSkills(mySkills);
            return RedirectToAction(nameof(ListOfMySkills));
            return View(mySkills);

        }
    }
}
