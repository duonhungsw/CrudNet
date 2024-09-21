using AppLayer.Models;
using BusinessLayer.Model;
using DataLayer.Repository.HRepository;
using DataLayer.Repository.IRopesitory;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(ILogger<HomeController> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string name, string email)
        {
            if (ModelState.IsValid)
            {
                var employee  = _employeeRepository.login(name, email);
                if(employee != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Khong dung");
                }
            }
            return View();
        }
        public IActionResult Index()
        {
            List<Employee> list = _employeeRepository.GetAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Create(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public IActionResult Update(int id) 
        {

            Employee employee = _employeeRepository.GetById(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            _employeeRepository.Update(employee);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _employeeRepository.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
