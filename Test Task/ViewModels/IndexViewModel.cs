using Test_Task.Models;

namespace Test_Task.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<ExcelFileData> Data { get; set; }
        public PagerViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
    }
}
