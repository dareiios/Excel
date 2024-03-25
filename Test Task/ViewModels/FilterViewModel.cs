namespace Test_Task.ViewModels
{
    public class FilterViewModel
    {
        public int? SelectedYear { get; set; }
        public int? SelectedMonth { get; set; }

        public FilterViewModel(int? year, int? month)
        {
            SelectedYear = year;
            SelectedMonth = month;
        }
    }
}
