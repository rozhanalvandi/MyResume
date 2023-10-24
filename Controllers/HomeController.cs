
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;

namespace Resume.Presentation.Controllers;

public class HomeController : Controller
{

    private readonly IDashbordService _dashboardService;
    public HomeController (IDashbordService dashbordService)
    {

        _dashboardService = dashbordService;
    }

    public async Task<IActionResult> Index()
    {
        var model = await _dashboardService.FillDashBoardModel();
        return View(model);
    }

}

