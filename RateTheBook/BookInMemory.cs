namespace RateTheBook
{
    internal class BookInMemory : BookBase
    {
        private List<double> rates;
        public BookInMemory(string title, string authorName, int numberOfPages) : base(title, authorName, numberOfPages)
        {
            rates = new List<double>();
        }

        public override string Title { get; set; }
        public override string AuthorName { get; set;}
        public override int NumberOfPages { get; set;}

        public override void AddRates (double rate)
        {
            rates.Add(rate);
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            foreach (var rate in rates) 
            {
                result.AddNewStatistics(rate);
            }
            return result;
        }
    }
}
