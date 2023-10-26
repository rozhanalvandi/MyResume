using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Implementation;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Entities.Education;
using Resume.Domain.Entities.Exprience;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Resume.Presentation.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ExprienceController : Controller
    {

        private readonly IExprienceService _exprienceService;

        public ExprienceController (IExprienceService exprienceService)
        {
            _exprienceService = exprienceService;
        }
        public async Task<IActionResult> ListOfExpriences()
        {
            var model = await _exprienceService.GetListOfExprience();
            return View(model);
        }
        public async Task<IActionResult> CreateAnExprience()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAnExprience(Exprience exprience)
        {
            await _exprienceService.AddAnExprienceToDataBase(exprience);
            return RedirectToAction(nameof(ListOfExpriences));
            
        }
        public async Task<IActionResult> EditAnExprience(int exprienceId)
        {
            var exprience = await _exprienceService.GetAnExprienceById(exprienceId);
            return View(exprience);
        }
        [HttpPost]
        public async Task<IActionResult> EditAnExprience(Exprience exprience)
        {
            await _exprienceService.EditAnExprience(exprience);
            return RedirectToAction(nameof(ListOfExpriences));

        }
        public async Task<IActionResult> DeleteAnExprience(int exprienceId)
        {
            var exprience = await _exprienceService.GetAnExprienceById(exprienceId);
            return View(exprience);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAnExprience(Exprience exprience)
        {
            await _exprienceService.DeleteAnExprience(exprience);
            return RedirectToAction(nameof(ListOfExpriences));

        }

    }
}

