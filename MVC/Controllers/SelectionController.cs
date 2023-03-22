using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers;

public class SelectionController : BaseController<SelectionController>
{
    [HttpGet]
    [Route("selection/date")]
    public IActionResult Date()
    {
        return View(new DateSelectorModel
        {
            Date = DateOnly.Parse(DateTime.Now.ToString("yyyy-MM-dd")),
            TimeFrom = TimeOnly.Parse(DateTime.Now.ToString("HH:mm:ss")),
            TimeTo = TimeOnly.Parse(DateTime.Now.AddHours(1).ToString("HH:mm:ss"))
        }.SetMinutesToFives());
    }

    [HttpPost]
    [Route("selection/date")]
    public IActionResult Date(DateSelectorModel model)
    {
        if (model.ReservationType == "Group")
        {
            return RedirectToAction("Group");
        }

        return RedirectToAction("Select");
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