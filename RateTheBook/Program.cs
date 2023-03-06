using RateTheBook;
using System;

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
                        catch (Exception exception)
                        {

                            Console.WriteLine($"Exception catched: {exception.Message}");
                            GetValueFromUser("\nPress any key to continue");
                        }
                        break;
                    case "2":
                        ClearConsole();
                        BookInMemory.ShowListOfBooks();
                        Console.WriteLine();
                        try
                        {

                            AddRaitingsToTheSpecificBook();
                        }
                        catch (Exception exception)
                        {

                            Console.WriteLine($"Exception catched: {exception.Message}");
                            GetValueFromUser("\nPress any key to continue");
                        }
                        GetValueFromUser("\nPress any key to continue");
                        break;
                    case "3":
                        ClearConsole();
                        BookInMemory.ShowListOfBooks();
                        Console.WriteLine();
                        try
                        {
                            ShowSpecificBookInMemoryStatistics();
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine($"Exception catched: {exception.Message}");
                            GetValueFromUser("\nPress any key to continue");
                        }
                        
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
                        Console.WriteLine("Invalid value. Please try again when this text will disapear");
                        Thread.Sleep(1500);
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
                    try
                    {
                        AddBookInFile();
                    }
                    catch (Exception exception)
                    {

                        Console.WriteLine($"Exception catched: {exception.Message}");
                        GetValueFromUser("\nPress any key to continue");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid value. Please try again when this text will disapear");
                    Thread.Sleep(1500);
                    break;
            }
            break;
        case "x":
        case "X":
            isProgramWorking = false;
            break;
        default:
            Console.WriteLine("Invalid value. Please try again when this text will disapear");
            Thread.Sleep(1500);
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
    var pageNumberString = GetValueFromUser("Please provide number of pages");
    ClearConsole();
    if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(author))
    {
        if (int.TryParse(pageNumberString, out int pageNumber))
        {
            var book = new BookInMemory(title, author, pageNumber);
            Console.WriteLine("Book successfully added!\n\nCurrent list of books:\n");
            BookInMemory.ShowListOfBooks();
        }
        else 
        {
            throw new Exception("Please provide page number as intiger");
        }
    }
    else
    {
        throw new Exception("Provided book title or author name can not be empty");
    }
}

static void AddBookInFile()
{
    var title = GetValueFromUser("Please provide book title: ");
    var author = GetValueFromUser("Please provide book Author: ");
    var pageNumberString = GetValueFromUser("Please provide number of pages");
    ClearConsole();
    if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(author))
    {
        if (int.TryParse(pageNumberString, out int pageNumber))
        {
            var book = new BookInFile(title, author, pageNumber);
            Console.WriteLine("Book successfully added!");

            while (true)
            {
                var userInput = GetValueFromUser("Please provide raiting for this book: ");
                if (userInput == "q" || userInput == "Q")
                {
                    break;
                }
                else if (double.TryParse(userInput, out double raiting))
                {
                    book.AddRatings(raiting);
                    Console.WriteLine("To leave and show book raitings press 'q'.\n");
                }
                else
                {
                    throw new Exception("Incorrect value provided. Please try again");
                }
                
            }
            book.GetStatistics();
            book.ShowStatistics();
            GetValueFromUser("\nPress any key to continue");
        }
        else
        {
            throw new Exception("Please provide page number as intiger");
        }
    }
    else
    {
        throw new Exception("Provided book title or author name can not be empty");
    }

    
    
}



static void ShowSpecificBookInMemoryStatistics()
{
    int providedId = int.Parse(GetValueFromUser("Please provide Id of the book, whose statistics you want to check"));
    ClearConsole();
    try
    {
        var objectWithProvidedId = BookInMemory.ReturnSpecificBookObject(providedId);
        objectWithProvidedId.ShowStatistics();
    }
    catch (Exception exception)
    {

        Console.WriteLine($"Exception catched: {exception.Message}");
    }
    
}

static void AddRaitingsToTheSpecificBook()
{
    var providedStringId = GetValueFromUser("Please provide Id of the book, whose statistics you want to add");
    if (int.TryParse(providedStringId, out int providedId))
    {
        ClearConsole();
        try
        {
            var objectWithProvidedId = BookInMemory.ReturnSpecificBookObject(providedId);

            var userRating = GetValueFromUser("Please provide the raiting ");
            if (double.TryParse(userRating, out double rating))
            {
                objectWithProvidedId.AddRatings(rating);
            }
            else
            {
                throw new Exception("Provided value is incorrect");
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Exception catched: {exception.Message}");
        }
    }
    else
    {
        throw new Exception("Please provide integer value");
    }
    
    
    
    
}

static void ClearConsole()
{
    Console.ForegroundColor = ConsoleColor.Green;
    var logo = "  _____            _            _______   _              ____                    _    \r\n |  __ \\          | |          |__   __| | |            |  _ \\                  | |   \r\n | |__) |   __ _  | |_    ___     | |    | |__     ___  | |_) |   ___     ___   | | __\r\n |  _  /   / _` | | __|  / _ \\    | |    | '_ \\   / _ \\ |  _ <   / _ \\   / _ \\  | |/ /\r\n | | \\ \\  | (_| | | |_  |  __/    | |    | | | | |  __/ | |_) | | (_) | | (_) | |   < \r\n |_|  \\_\\  \\__,_|  \\__|  \\___|    |_|    |_| |_|  \\___| |____/   \\___/   \\___/  |_|\\_\\\r\n                                                                                      \n______________________________________________________________________________________\n";
    Console.Clear();
    Console.WriteLine(logo);
    Console.ResetColor();
}