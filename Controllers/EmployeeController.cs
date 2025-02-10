using System.Web.Helpers;
using DataVisualization.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataVisualization.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            var employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "John Doe", Position = "Manager", Salary = 50000 },
                new Employee { Id = 2, Name = "Jane Smith", Position = "Developer", Salary = 40000 },
                new Employee { Id = 3, Name = "Mike Johnson", Position = "Designer", Salary = 35000 }
            };

            return View(employees);
        }

        public ActionResult SalaryChart()
        {
            var names = new[] { "John", "Jane", "Mike" };
            var salaries = new[] { "50000", "40000", "35000" };

            var chart = new Chart(width: 600, height: 400)
                .AddTitle("Employee Salaries")
                .AddSeries(
                    chartType: "Column",
                    xValue: names,
                    yValues: salaries
                )
                .GetBytes("png");

            return File(chart, "image/png");
        }
    }
}
