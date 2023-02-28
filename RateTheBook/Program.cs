using RateTheBook;

var test = new Reading("asd", "asd", 1);
var test2 = new Reading("asd", "asd", 1);
Console.WriteLine(test.Id);
Console.WriteLine(test2.Id);

var book = new BookInMemory("asdf", "asdfasdfasdf", 345);
book.AddRates(5.0);
book.AddRates(10.0);
book.AddRates(45.0);
book.AddRates(15.0);
book.ShowStatistics();