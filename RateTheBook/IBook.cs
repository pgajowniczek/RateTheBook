using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateTheBook
{
    internal interface IBook
    {
        string Title { get; }
        string AuthorName { get; }
        int NumberOfPages { get; }
        int Id { get; }

        void AddRates(double rate);

        Statistics GetStatistics();

        void ShowStatistics();

        //void ShowListOfBooks();
    }
}
