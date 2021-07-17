using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private DataBaseContext db;
        public IDatabaseRepository databaseRepository;
        private readonly IServiceScopeFactory serviceScopeFactory;

        public HomeController(DataBaseContext context, IDatabaseRepository databaseRepository, IServiceScopeFactory serviceScopeFactory)
        {
            db = context;
            this.databaseRepository = databaseRepository;
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<IActionResult> Index()
        {            
            return View(databaseRepository.GetEmployees());
        }

        public async Task<IActionResult> Add()
        {
            return View(databaseRepository.GetDepartamentAndProgrammingLanguages());            
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeesModel employeesModel)
        {
            employeesModel.EmployeeId = null;
            db.employees.Add(employeesModel);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            return View(databaseRepository.GetEmployeeDeparAndPL(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeesModel model, int? id)
        {
            model.EmployeeId = id;
            db.employees.Update(model);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            
            if (id != null)
            {
                EmployeesModel user = databaseRepository.GetEmployee(id);
                Task.Run(() => BgTask(user, serviceScopeFactory));
            }
            return RedirectToAction("Index");
        }

        private async Task BgTask(EmployeesModel user, IServiceScopeFactory serviceScopeFactory)
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<DataBaseContext>();

                dbContext.employees.Remove(user);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
