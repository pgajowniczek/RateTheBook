using RateTheBook;

//testy @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//var test = new Reading("asd", "asd", 1);
//var test2 = new Reading("asd", "asd", 1);
//Console.WriteLine(test.Id);
//Console.WriteLine(test2.Id);

//var book = new BookInMemory("asdf", "asdfasdfasdf", 345);
//var book2 = new BookInMemory("assdfsdfgsdfgsdgfdf", "asdsdfgsdfgsdgffasdfasdf", 34534);

//book.AddRatings(5.0);
//book.AddRatings(10.0);
//book.AddRatings(45.0);
//book.ShowStatistics();
//BookInMemory.ShowListOfBooks();
//var testID = 3;
//var objectWithID3 = BookInMemory.ReturnSpecificBookObject(testID);
//objectWithID3.ShowStatistics();
//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

var isProgramWorking = true;
while (isProgramWorking)
{
    ClearConsole();
    Console.WriteLine("Welcome in RateTheBook app! ");
    var userChoice = GetValueFromUser("1 - Add new book or verify statistics in memory\n2 - Add new book, verify statistics and save in .txt file\nX - Cloese app\n");
    var stayInCurrentView = true;
    switch (userChoice)
    {
        case "1":
            while (stayInCurrentView)
            {
                ClearConsole();
                userChoice = GetValueFromUser("1 - Add new book\n2 - Add raitings\n3 - Show specific book statistics\n4 - Show list of all books\n5 - Go back to previous menu\nX - Close the app.");
                switch (userChoice)
                {
                    case "1":
                        ClearConsole();
                        try
                        {
                            AddBookInMemory();
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        
                        break;
                    case "2":
                        ClearConsole();
                        BookInMemory.ShowListOfBooks();
                        Console.WriteLine();
                        AddRaitingsToTheSpecificBook();
                        GetValueFromUser("\nPress any key to continue");
                        break;
                    case "3":
                        ClearConsole();
                        BookInMemory.ShowListOfBooks();
                        Console.WriteLine();
                        ShowSpecificBookInMemoryStatistics();
                        GetValueFromUser("\nPress any key to continue");
                        break;
                    case "4":
                        ClearConsole();
                        BookInMemory.ShowListOfBooks();
                        GetValueFromUser("\nPress any key to continue");
                        break;
                    case "5":
                        stayInCurrentView = false;
                        break;
                    case "X":
                    case "x":
                        stayInCurrentView = false;
                        isProgramWorking = false;
                        break;
                    default:
                        Console.WriteLine("Invalid value. Please try again");
                        break;
                }
            }
            break;
        case"2":
            ClearConsole();
            userChoice = GetValueFromUser("1 - Add and save new book\nX - Close the app.");
            switch (userChoice)
            {
                case "1":
                    ClearConsole();
                    AddBookInFile();
                    break;
                default:
                    Console.WriteLine("Invalid value. Please try again");
                    break;
            }
            break;
        case "x":
        case "X":
            isProgramWorking = false;
            break;
        default:
            Console.WriteLine("Invalid value. Please try again");
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
    ClearConsole();
    var book = new BookInMemory(title, author, pageNumber);
    Console.WriteLine("Book successfully added!\n\nCurrent list of books:\n");
    BookInMemory.ShowListOfBooks();
    GetValueFromUser("\nPress any key to continue");
}

static void AddBookInFile()
{
    var title = GetValueFromUser("Please provide book title: ");
    var author = GetValueFromUser("Please provide book Author: ");
    int pageNumber = int.Parse(GetValueFromUser("Please provide number of pages"));
    ClearConsole();
    var book = new BookInFile(title, author, pageNumber);
    Console.WriteLine("Book successfully added!\n");
    while (true)
    {
        var userInput = GetValueFromUser("Please provide raiting for this book: ");
        if (userInput == "q" || userInput == "Q")
        {
            break;
        }
        double raiting = double.Parse(userInput);
        book.AddRatings(raiting);
        Console.WriteLine("To leave and show book raitings press 'q'.\n");
    }
    
}



static void ShowSpecificBookInMemoryStatistics()
{
    int providedId = int.Parse(GetValueFromUser("Please provide Id of the book, whose statistics you want to check"));
    ClearConsole();
    var objectWithProvidedId = BookInMemory.ReturnSpecificBookObject(providedId);
    objectWithProvidedId.ShowStatistics();
}

static void AddRaitingsToTheSpecificBook()
{
    int providedId = int.Parse(GetValueFromUser("Please provide Id of the book, whose statistics you want to add"));
    ClearConsole();
    var objectWithProvidedId = BookInMemory.ReturnSpecificBookObject(providedId);
    double rating = double.Parse(GetValueFromUser("Please provide the raiting "));
    objectWithProvidedId.AddRatings(rating);
}

static void ClearConsole()
{
    Console.ForegroundColor = ConsoleColor.Green;
    var logo = "  _____            _            _______   _              ____                    _    \r\n |  __ \\          | |          |__   __| | |            |  _ \\                  | |   \r\n | |__) |   __ _  | |_    ___     | |    | |__     ___  | |_) |   ___     ___   | | __\r\n |  _  /   / _` | | __|  / _ \\    | |    | '_ \\   / _ \\ |  _ <   / _ \\   / _ \\  | |/ /\r\n | | \\ \\  | (_| | | |_  |  __/    | |    | | | | |  __/ | |_) | | (_) | | (_) | |   < \r\n |_|  \\_\\  \\__,_|  \\__|  \\___|    |_|    |_| |_|  \\___| |____/   \\___/   \\___/  |_|\\_\\\r\n                                                                                      \n______________________________________________________________________________________\n";
    Console.Clear();
    Console.WriteLine(logo);
    Console.ResetColor();
}