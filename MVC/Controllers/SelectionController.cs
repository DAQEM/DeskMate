using BLL.Entities;
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

    [HttpGet]
    public IActionResult Index()
    {
        return View(new SelectionModel());
    }

    [HttpPost]
    public IActionResult DateTimeSelection(SelectionModel model)
    {
        Console.WriteLine(DateTime.Now.ToLongTimeString() + " => " +
                          model.DateTimeSelectionModel.Date.ToShortDateString() + " " +
                          model.DateTimeSelectionModel.StartTime.ToShortTimeString() + " " +
                          model.DateTimeSelectionModel.EndTime.ToShortTimeString());
        model.Step = 2;
        //TODO: Get employees from database
        model.EmployeeModels = new List<EmployeeModel>
            { new() { Employee = new Employee(id: Guid.NewGuid(), name: "Viewer name") } };
        return View("Index", model);
    }

    [HttpPost]
    public IActionResult EmployeeSelection(SelectionModel model)
    {
        Console.WriteLine(DateTime.Now.ToLongTimeString() + " => " + model.EmployeeModels.Count);
        model.Step = 3;
        return View("Index", model);
    }

    [HttpPost]
    public IActionResult WorkspaceSelection(SelectionModel model)
    {
        Console.WriteLine(DateTime.Now.ToLongTimeString() + " => " + model.WorkspaceModels.Count);
        model.Step = 4;
        return View("Index", model);
    }
}