using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTattoos.Web.Data;
using NetTattoos.Web.Models;
using NetTattoos.Web.Models.Entities;

namespace NetTattoos.Web.Controllers
{
    public class VisitsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public VisitsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddVisitViewModel viewModel)
        {

            var visit = new Visit
            {
                Name = viewModel.Name,
                Surname = viewModel.Surname,
                Email = viewModel.Email,
                Visit_type = viewModel.Visit_type,
                Visit_date = viewModel.Visit_date
            };

            await dbContext.Visits.AddAsync(visit);

            await dbContext.SaveChangesAsync();

            return RedirectToAction("List", "Visits");

        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var visits = await dbContext.Visits.ToListAsync();

            return View(visits);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var visit = await dbContext.Visits.FindAsync(id);

            return View(visit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Visit viewModel)
        {
            var visit = await dbContext.Visits.FindAsync(viewModel.Id);

            if (visit != null)
            {
                visit.Name = viewModel.Name;
                visit.Surname = viewModel.Surname;
                visit.Email = viewModel.Email;
                visit.Visit_type = viewModel.Visit_type;
                visit.Visit_date = viewModel.Visit_date;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Visits");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Visit viewModel)
        {
            var visit = await dbContext.Visits.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (visit != null)
            {
                dbContext.Visits.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Visits");
        }
    }
}
