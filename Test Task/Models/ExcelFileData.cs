namespace Test_Task.Models;

public class ExcelFileData
{
    public int Id { get; set; }
    public DateOnly? Date { get; set; }
    public TimeOnly? MoscowTime { get; set; }
    public double? Temperature { get; set; }
    public double? Humidity { get; set; }
    public double? DewPoint { get; set; }
    public int? AtmosphericPressure { get; set; }
    public string WindDirection { get; set; }
    public int? WindSpeed { get; set; }
    public int? CloudCover { get; set; }
    public int? LowLimit { get; set; }
    public double? HorizontalVisibility { get; set; }
    public string WeatherPhenomena { get; set; }
}
