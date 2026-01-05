using System.Diagnostics;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using Web_Gastos.Data;
using Web_Gastos.Models;

namespace Web_Gastos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SpendSmartDbContext _context;

        public SpendSmartDbContext? Context { get; }

        public HomeController(ILogger<HomeController> logger, SpendSmartDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Expenses()
        {
            var allExpenses = _context.Expenses.ToList();
            var totalExpenses = allExpenses.Sum(x => x.Value);
            ViewBag.Expenses = totalExpenses;
            return View(allExpenses);
        }
        public IActionResult CreateEditExpenses(int? id)
        {
            if(id!= null)
            {
                var expenseindb = _context.Expenses.FirstOrDefault(x => x.Id == id);
                return View(expenseindb);
            }
            return View();
        }

        public IActionResult CreateEditExpensesForm(Expense model)
        {
            if(model.Id == 0)
            {
                _context.Expenses.Add(model);
            }
            else
            {
                _context.Expenses.Update(model);
            }
            _context.SaveChanges();
            return RedirectToAction("Expenses");
        }
        public IActionResult Delete(int id) 
        {
            var expenseindb = _context.Expenses.FirstOrDefault( x => x.Id == id);
            _context.Expenses.Remove(expenseindb);
            _context.SaveChanges();
            return RedirectToAction("Expense");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
