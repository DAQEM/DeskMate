using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers;

public class SelectionController : BaseController<SelectionController>
{
    [HttpGet]
    [Route("selection/date")]
    public IActionResult Date()
    {
        return View();
    }
    
    [HttpPost]
    [Route("selection/date")]
    public IActionResult SubmitDate()
    {
        return RedirectToAction("Group");
    }
    
    [HttpGet]
    [Route("selection/group")]
    public IActionResult Group()
    {
        return View();
    }
    
    [HttpGet]
    [Route("selection/select")]
    public IActionResult Select()
    {
        return View();
    }
}