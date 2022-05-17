using System;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********** Gradebook Console Program **********");
            Console.WriteLine("Enter the type of the book");
            Console.WriteLine("1 - In Memory Book");
            Console.WriteLine("2 - In File Book");
            string? bookType = Console.ReadLine();

            if (!BookValidator.isBookTypeValid(bookType))
            {
                Console.WriteLine("The book type is not valid. Program terminated.");
                return;
            }

            Console.WriteLine("Enter the book name: ");
            string? bookName = Console.ReadLine();

            if (!BookValidator.isBookNameValid(bookName))
            {
                Console.WriteLine("The book name is not valid. Program terminated.");
                return;
            }

            Book book = getBook(bookType, bookName);

            enterGrades(book);

            if (book.GetGrades().Count > 0)
            {
                Statistics result = book.GetStatistics();
                Console.WriteLine($"For the book name {book.Name}:");
                Console.WriteLine($"The lowest grade is {result.Lowest:N2}");
                Console.WriteLine($"The highest grade is {result.Highest:N2}");
                Console.WriteLine($"The average grade is {result.Average:N2}");
                Console.WriteLine($"The letter grade is {result.AverageInLetter}");
            }
        }

        private static void enterGrades(Book book)
        {
            while (true)
            {
                Console.WriteLine("Enter the grade or press 'q' to quit: ");
                string? inputGrade = Console.ReadLine();

                if (inputGrade == "Q" || inputGrade == "q") break;

                if (BookValidator.isGradeValid(inputGrade))
                {   
                    var grade = double.Parse(inputGrade);
                    book.AddGrade(grade);
                }
            }
        }

        private static Book getBook(string bookType, string bookName)
        {
            var bookTypeInt = int.Parse(bookType);

            switch (bookTypeInt)
            {
                case 1:
                    return new InMemoryBook(bookName);
                case 2:
                    return new InFileBook(bookName);
                default:
                    return new InMemoryBook(bookName);
            }
        }
    }
}
