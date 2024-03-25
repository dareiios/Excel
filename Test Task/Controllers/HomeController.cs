using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Test_Task.Models;


namespace Test_Task.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //var excel = "C:\\Users\\user\\source\\repos\\ConsoleApp1\\Book1.xlsx";
            //ExcelFileData data = null;

            //using (FileStream file = new FileStream(excel, FileMode.Open, FileAccess.ReadWrite))
            //{
            //    XSSFWorkbook workbook = new XSSFWorkbook(file);
            //    ISheet sheet = workbook.GetSheet("Sheet1");
                
            //    //List<ExcelFileData> excelData = new List<ExcelFileData>();
            //    for (int i = 2; i < 10; i++)
            //    {
            //        data = new ExcelFileData();
            //        IRow row = sheet.GetRow(i);
            //        data.Temperature = row.GetCell(0).ToString();
            //        data.Humidity = row.GetCell(1).ToString();
            //        data.DewPoint = row.GetCell(2).ToString();
            //        data.AtmosphericPressure = row.GetCell(3).ToString();
            //        _context.ExcelData.Add(data);
            //        _context.SaveChanges();
            //    }

            //}

            //var values = GetlAll();

            return View();
        }


        //public IEnumerable<ExcelFileData> GetlAll()
        //{
        //    return _context.ExcelData;
        //}

    }
}
