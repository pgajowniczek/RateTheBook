
namespace RateTheBook.Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            //arrange
            var book = new BookInMemory("Jednym strza³em", "Lee Child", 324);
            book.AddRatings(4);
            book.AddRatings(5);
            book.AddRatings(6);
            book.AddRatings(7);
            book.AddRatings(8);
            //act
            var result = book.GetStatistics();
            //assert
            Assert.AreEqual(6.0, result.AverageRating);
            Assert.AreEqual(4, result.LowestRating);
            Assert.AreEqual(8, result.HighestRating);
        }
        [Test]
        public void Test2() 
        {
            //arrange
            var book = new BookInFile("Sto milionów dolarów", "Lee Child", 298);
            book.AddRatings(4);
            book.AddRatings(5);
            book.AddRatings(6);
            book.AddRatings(7);
            book.AddRatings(8);
            //act
            var result = book.GetStatistics();
            //assert
            Assert.AreEqual(6.0, result.AverageRating);
            Assert.AreEqual(4, result.LowestRating);
            Assert.AreEqual(8, result.HighestRating);
        }
    }
}