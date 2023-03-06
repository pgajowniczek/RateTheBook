using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateTheBook
{
    public abstract class BookBase: Reading, IBook
    {
        public override string Title { get; set; }
        public override string AuthorName {  get; set; }

        public override int NumberOfPages { get; set; }

        public delegate void BookAddedDelegate(object sender, EventArgs args);

        public event BookAddedDelegate BookAdded;

        private const string logPath = "Logs.txt";

        public delegate void RatingAddedDelegate(object sender, EventArgs args);

        public event RatingAddedDelegate RatingAdded;
        

        public BookBase(string title, string authorName, int numberOfPages): base(title, authorName, numberOfPages)
        {
            this.BookAdded += BookBase_BookAdded;
            if (BookAdded != null)
            {
                BookAdded(this, new EventArgs());
            }
            this.RatingAdded += BookBase_RatingAdded;
        }

        private void BookBase_BookAdded(object sender, EventArgs args)
        {
            using (var writer = File.AppendText($"{logPath}"))
            {
                writer.WriteLine($"{DateTime.Now} - New book added: {this.Title}, {this.AuthorName}, {this.NumberOfPages}");
            }
        }
        
        public virtual void AddRatings(double rate)
        {            
            if(RatingAdded != null)
            {
                RatingAdded(this, new EventArgs());
            }
        }

        private void BookBase_RatingAdded(object sender, EventArgs args)
        {
            using (var writer = File.AppendText($"{logPath}"))
            {
                writer.WriteLine($"{DateTime.Now} - New rating added into \"{this.Title}\"");
            }
        }

        public abstract Statistics GetStatistics();

        public void ShowStatistics()
        {
            ShowBookDetails();
            var statistics = GetStatistics();
            if (statistics.WasAdded)
            {
                Console.WriteLine($"Highest: {statistics.HighestRating}");
                Console.WriteLine($"Lowest: {statistics.LowestRating}");
                Console.WriteLine($"Average: {statistics.AverageRating}");
            }
            else
            {
                Console.WriteLine("Unfortunately there is no statistics yet, please provide your ratings first!");
            }
            
        }
        public void ShowBookDetails()
        {
            Console.WriteLine($"ID: {this.Id}, Title: {this.Title}, Author: {this.AuthorName}, Number of pages: {this.NumberOfPages}");
        }
        
        
    }
}
