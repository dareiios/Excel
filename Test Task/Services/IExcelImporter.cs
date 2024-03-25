namespace Test_Task.Services
{
    public interface IExcelImporter
    {
        public Task<bool> TryImportExcelToDb(string path);
    }
}
