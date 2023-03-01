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

        public BookBase(string title, string authorName, int numberOfPages): base(title, authorName, numberOfPages)
        {

        }

        public abstract void AddRatings(double rate);

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
