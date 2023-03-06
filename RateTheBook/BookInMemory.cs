namespace RateTheBook
{
    internal class BookInMemory : BookBase
    {
        private List<double> ratings;
        static List<BookInMemory> allBooks = new List<BookInMemory>();
        
        public BookInMemory(string title, string authorName, int numberOfPages) : base(title, authorName, numberOfPages)
        {
            ratings = new List<double>();
            allBooks.Add(this);
        }

        public override string Title { get; set; }
        public override string AuthorName { get; set;}
        public override int NumberOfPages { get; set; }
        public override void AddRatings (double rating)
        {
            ratings.Add(rating);
            base.AddRatings(rating);
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            foreach (var rating in ratings) 
            {
                result.AddNewStatistics(rating);
            }
            return result;
        }

        public static void ShowListOfBooks()
        {
            foreach (var book in allBooks)
            {
                book.ShowBookDetails();
            }
        }

        public static BookInMemory ReturnSpecificBookObject(int providedId)
        {
            List<BookInMemory> test = allBooks.Where(x => x.Id == providedId).ToList();
            if (test.Count < 1)
            {
                throw new Exception("Provided ID value is incorrect");
            }
            else
            {
                return test[0];
            }
        }

        
    }
}
