using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test_Task.Models;
using Test_Task.Services;
using Test_Task.ViewModels;

namespace Test_Task.Controllers
{
    public class ExcelController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly ApplicationDbContext _context;
        private readonly IExcelImporter _excelImporter;

        public ExcelController(IWebHostEnvironment env, ApplicationDbContext context, IExcelImporter excelImporter)
        {
            _env = env;
            _context = context;
            _excelImporter = excelImporter;
        }

        public async Task<IActionResult> Index(int page, int? year, int? month)
        {
            IQueryable<ExcelFileData> data = _context.ExcelData.OrderBy(x => x.Date);

            if (year != null)
            {

                data = data.Where(x => x.Date.HasValue && x.Date.Value.Year == year);
            }
            if (month != null)
            {
                data = data.Where(x => x.Date.HasValue && x.Date.Value.Month == month);

            }

            const int pageSize = 20;
            if (page < 1)
                page = 1;

            int dataCount = await data.CountAsync();
            int dataSkip = (page - 1) * pageSize;
            var values = await data.Skip(dataSkip).Take(pageSize).ToListAsync();

            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PagerViewModel(dataCount, page, pageSize),
                FilterViewModel = new FilterViewModel(year, month),
                Data = values
            };

            return View(viewModel);
        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IEnumerable<IFormFile> uploads)
        {
            var valide = ValideFile(uploads);
            if (valide)
            {
                foreach (var upload in uploads)
                {
                    string path = "/excels/" + upload.FileName;
                    using (var fileStream = new FileStream(_env.WebRootPath + path, FileMode.Create))
                    {
                        upload.CopyTo(fileStream);
                    }

                    var isSucess = await _excelImporter.TryImportExcelToDb(_env.WebRootPath + path);
                    ViewBag.Error = !isSucess;
                }
            }
            else
                ViewBag.Error = true;

            if (ViewBag.Error)
                return View();
            else
                return RedirectToAction("Index");
        }

        private bool ValideFile(IEnumerable<IFormFile> uploads)
        {
            foreach (var file in uploads)
            {
                var fileExt = Path.GetExtension(file.FileName).ToLower();
                if (fileExt == ".xls" || fileExt == ".xlsx")
                    return true;
            }
            return false;


        }

    }
}
