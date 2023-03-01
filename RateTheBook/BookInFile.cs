using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateTheBook
{
    internal class BookInFile : BookBase
    {
        private const string fileName = "_ratings.txt";
        private string fullFileName;
        public BookInFile(string title, string authorName, int numberOfPages) : base(title, authorName, numberOfPages) 
        {
            fullFileName = $"{this.Title}_{fileName}";
        }

        internal static void ShowListOfBooks()
        {
            throw new NotImplementedException();
        }

        public override void AddRatings(double rating)
        {
            using (var writer = File.AppendText($"{fullFileName}"))
            {
                writer.WriteLine(rating);
            }    
        }

        public override Statistics GetStatistics() 
        {
            throw new NotImplementedException();
        }
    }
}
