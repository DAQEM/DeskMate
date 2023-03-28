using BLL.Entities;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers;

public class SelectionController : BaseController<SelectionController>
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(new SelectionModel());
    }

    [HttpPost]
    public IActionResult Selection(SelectionModel model)
    {
        return model.Step switch
        {
            1 => DateTimeSelection(model),
            2 => EmployeeSelection(model),
            3 => WorkspaceSelection(model),
            _ => Index()
        };
    }

    [HttpPost]
    public IActionResult DateTimeSelection(SelectionModel model)
    {
        Console.WriteLine(DateTime.Now.ToLongTimeString() + " => " +
                          model.DateTimeSelectionModel.Date.ToShortDateString() + " " +
                          model.DateTimeSelectionModel.StartTime.ToShortTimeString() + " " +
                          model.DateTimeSelectionModel.EndTime.ToShortTimeString());
        //TODO: Get employees from database
        model.EmployeeModels = new List<EmployeeModel>
            { new() { Employee = new Employee(Guid.NewGuid(), "Viewer name") } };
        return View("Index", model);
    }

    [HttpPost]
    public IActionResult EmployeeSelection(SelectionModel model)
    {
        Console.WriteLine(DateTime.Now.ToLongTimeString() + " => " + model.EmployeeModels.Count);
        return View("Index", model);
    }

    [HttpPost]
    public IActionResult WorkspaceSelection(SelectionModel model)
    {
        Console.WriteLine(DateTime.Now.ToLongTimeString() + " => " + model.WorkspaceModels.Count);
        return View("Index", model);
    }
}