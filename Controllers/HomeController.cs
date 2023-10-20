using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resume.Application.DTOs.SiteSide.HomeIndex;
using Resume.Domain.RepositoryInterface;
using Resume.Infrastructure.Dbcontext;
using Resume.Presentation.Models;

namespace Resume.Presentation.Controllers;

public class HomeController : Controller
{

    private readonly IEducationRepository _educationRepository;
    private readonly IExprienceRepository _exprienceRepository;
    private readonly IMySkillsRepository _mySkillsRepository;
    public HomeController(IEducationRepository educationRepository,
                          IExprienceRepository exprienceRepository,
                          IMySkillsRepository mySkillsRepository)
    {
        _educationRepository = educationRepository;
        _exprienceRepository = exprienceRepository;
        _mySkillsRepository = mySkillsRepository;

    }
    public async Task<IActionResult> Index()
    {

        var myskillsAsync = await _mySkillsRepository.GetListOfMySkills();

        
        var EducationAsync = await _educationRepository.GetListOfEduction();

        var ExprinceAsync = await _exprienceRepository.GetListOfExprience();
       
       
        HomeIndexModelDTOs homeIndexModelDTOs = new HomeIndexModelDTOs()
        {
            Educations = EducationAsync,
            Expriences= ExprinceAsync,
            MySkills= myskillsAsync,

        };
        return View(homeIndexModelDTOs);
    }

}

