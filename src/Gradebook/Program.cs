using System;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********** Gradebook Console Program **********");
            Console.WriteLine("Enter the book name: ");

            var bookName = Console.ReadLine();

            if (!String.IsNullOrEmpty(bookName) && !String.IsNullOrWhiteSpace(bookName))
            {
                var book = new InFileBook(bookName);

                EnterGrades(book);

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
            else
            {
                Console.WriteLine("The book name is not valid. Program terminated.");
            }
        }

        private static void EnterGrades(Book book)
        {
            while (true)
            {
                Console.WriteLine("Enter the grade or press 'q' to quit: ");
                string? inputGrade = Console.ReadLine();

                if (inputGrade == "Q" || inputGrade == "q") break;

                if (!String.IsNullOrEmpty(inputGrade))
                {
                    try
                    {
                        var grade = double.Parse(inputGrade);
                        book.AddGrade(grade);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}
