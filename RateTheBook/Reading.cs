namespace RateTheBook
{
    public class Reading
    {

        protected static int instances = 1;
        public virtual string Title { get; set; }

        public virtual string AuthorName { get; set; }

        public virtual int NumberOfPages { get; set; }

        public virtual int Id { get; private set; }

        public Reading(string title, string authorName, int numberOfPages)
        {
            this.Title = title;
            this.AuthorName = authorName;
            this.NumberOfPages = numberOfPages;
            this.Id = instances++;
        }
    }
}
