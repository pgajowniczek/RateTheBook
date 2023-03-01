using RateTheBook;

//testy @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
var test = new Reading("asd", "asd", 1);
var test2 = new Reading("asd", "asd", 1);
Console.WriteLine(test.Id);
Console.WriteLine(test2.Id);

var book = new BookInMemory("asdf", "asdfasdfasdf", 345);
var book2 = new BookInMemory("assdfsdfgsdfgsdgfdf", "asdsdfgsdfgsdgffasdfasdf", 34534);

book.AddRates(5.0);
book.AddRates(10.0);
book.AddRates(45.0);
book.ShowStatistics();
BookInMemory.ShowListOfBooks();
var testID = 3;
var objectWithID3 = BookInMemory.ReturnSpecificBookObject(testID);
objectWithID3.ShowStatistics();
//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

var isProgramWorking = true;
while (isProgramWorking)
{
    ClearConsole();
    Console.WriteLine("Welcome in RateTheBook app! ");
    var userChoice = GetValueFromUser("1 - Add new book or verify statistics of books in memory\nX - Cloese app\n");
    var stayInCurrentView = true;
    switch (userChoice)
    {
        case "1":
            while (stayInCurrentView)
            {
                ClearConsole();
                userChoice = GetValueFromUser("1 - Add new book\n2 - Show specific book statistics\n3 - Show list of all books\n4 - Go back to previous menu\nX - Close the app.");
                switch (userChoice)
                {
                    case "1":
                        ClearConsole();
                        AddBookInMemory();
                        break;
                    case "2":
                        ClearConsole();
                        BookInMemory.ShowListOfBooks();
                        ShowSpecificBookInMemoryStatistics();
                        GetValueFromUser("\nPress any key to continue");
                        break;
                    case "3":
                        ClearConsole();
                        BookInMemory.ShowListOfBooks();
                        GetValueFromUser("\nPress any key to continue");
                        break;
                    case "4":
                        stayInCurrentView = false;
                        break;
                    case "X":
                    case "x":
                        stayInCurrentView = false;
                        isProgramWorking = false;
                        break;
                    default:
                        break;
                }
            }

            break;
        case "x":
        case "X":
            isProgramWorking = false;
            break;
        default:
            break;
    }
}

static string GetValueFromUser(string text)
{
    Console.WriteLine(text);
    string userInput = Console.ReadLine();
    return userInput;
}

static void AddBookInMemory()
{
    var title = GetValueFromUser("Please provide book title: ");
    var author = GetValueFromUser("Please provide book Author: ");
    int pageNumber = int.Parse(GetValueFromUser("Please provide number of pages"));

    var book = new BookInMemory(title, author, pageNumber);
    BookInMemory.ShowListOfBooks();
}

static void ShowSpecificBookInMemoryStatistics()
{
    int providedId = int.Parse(GetValueFromUser("Please provide Id of the book, whose statistics you want to check"));
    ClearConsole();
    var objectWithProvidedId = BookInMemory.ReturnSpecificBookObject(providedId);
    objectWithProvidedId.ShowStatistics();
}

static void ClearConsole()
{
    var logo = "  _____            _            _______   _              ____                    _    \r\n |  __ \\          | |          |__   __| | |            |  _ \\                  | |   \r\n | |__) |   __ _  | |_    ___     | |    | |__     ___  | |_) |   ___     ___   | | __\r\n |  _  /   / _` | | __|  / _ \\    | |    | '_ \\   / _ \\ |  _ <   / _ \\   / _ \\  | |/ /\r\n | | \\ \\  | (_| | | |_  |  __/    | |    | | | | |  __/ | |_) | | (_) | | (_) | |   < \r\n |_|  \\_\\  \\__,_|  \\__|  \\___|    |_|    |_| |_|  \\___| |____/   \\___/   \\___/  |_|\\_\\\r\n                                                                                      \n______________________________________________________________________________________\n";
    Console.Clear();
    Console.WriteLine(logo);
}