using CustomIdentityApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CustomIdentityApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationContext db;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cars()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Booking()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Booking(Orders order)
        {
            db.Orders.Add(order);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Orders()
        {
            return View(await db.Orders.ToListAsync());
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Orders order = await db.Orders.FirstOrDefaultAsync(p => p.Id == id);
                if (order != null)
                    return View(order);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Orders order = await db.Orders.FirstOrDefaultAsync(p => p.Id == id);
                if (order != null)
                {
                    db.Orders.Remove(order);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Orders");
                }
            }
            return NotFound();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
