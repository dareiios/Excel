namespace Test_Task.ViewModels
{
    public class PagerViewModel
    {
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }

        public PagerViewModel() { }

        public PagerViewModel(int totalItems, int page, int pageSize = 50)
        {
            int totalPages = (int)Math.Ceiling(totalItems / (decimal)pageSize); // 100/50=2pages
            int currentPage = page;

            //5 6 7 8 9 10! 11 12 13 14
            int startPage = currentPage - 5;
            int endPage = currentPage + 4;

            if (startPage <= 0) //if current=2 => start = 2-5=-3 <0
            {
                endPage = endPage - (startPage - 1); //before: end = 2+4=6 => after:6-(-3 - 1)=10
                startPage = 1; //before -3. after 1
            }

            if (endPage > totalPages)
            {
                endPage = totalPages;

                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalItems = totalItems;
            TotalPages = totalPages;
            CurrentPage = currentPage;
            PageSize = pageSize;
            StartPage = startPage;
            EndPage = endPage;
        }

    }

}
