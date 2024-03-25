using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Test_Task.Models;

namespace Test_Task.Services
{
    public class ExcelImporter : IExcelImporter
    {
        private readonly ApplicationDbContext _context;

        public ExcelImporter(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> TryImportExcelToDb(string path)
        {
            try
            {
                using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
                {
                    XSSFWorkbook workbook = new XSSFWorkbook(file);
                    var sheetCount = workbook.NumberOfSheets;
                    List<ExcelFileData> dataList = new();

                    for (int c = 0; c < sheetCount; c++)
                    {
                        ISheet sheet = workbook.GetSheetAt(c);

                        if (sheet.LastRowNum > 0)
                        {
                            for (int i = 4; i < sheet.LastRowNum + 1; i++)
                            {
                                ExcelFileData data = new();
                                IRow row = sheet.GetRow(i);

                                if (row.GetCell(0) != null && !string.IsNullOrEmpty(row.GetCell(0).ToString()))
                                    data.Date = DateOnly.Parse(row.GetCell(0).ToString());

                                if (row.GetCell(1) != null && !string.IsNullOrEmpty(row.GetCell(1).ToString()))
                                    data.MoscowTime = TimeOnly.Parse(row.GetCell(1).ToString());

                                data.Temperature = GetDoubleValue(row.GetCell(2));
                                data.Humidity = GetDoubleValue(row.GetCell(3));
                                data.DewPoint = GetDoubleValue(row.GetCell(4));
                                data.AtmosphericPressure = GetIntValue(row.GetCell(5));
                                data.WindDirection = GetStringValue(row.GetCell(6));
                                data.WindSpeed = GetIntValue(row.GetCell(7));
                                data.CloudCover = GetIntValue(row.GetCell(8));
                                data.LowLimit = GetIntValue(row.GetCell(9));
                                data.HorizontalVisibility = GetDoubleValue(row.GetCell(10));
                                data.WeatherPhenomena = GetStringValue(row.GetCell(11));

                                dataList.Add(data);
                            }                            
                        }
                        else
                            return false;
                    }
                    _context.ExcelData.AddRange(dataList);
                    await _context.SaveChangesAsync();
                }
            }
            catch
            {                
                return false;
            }
            return true;
        }

        private static int? GetIntValue(ICell cell)
        {
            if (cell.CellType == CellType.Numeric)
                return Convert.ToInt32(cell.ToString());
            return null;
        }

        private static double? GetDoubleValue(ICell cell)
        {
            if (cell.CellType == CellType.Numeric)
                return Convert.ToDouble(cell.ToString());
            return null;
        }

        private static string? GetStringValue(ICell cell)
        {
            return cell != null ? cell.ToString() : "";
        }


    }
}
