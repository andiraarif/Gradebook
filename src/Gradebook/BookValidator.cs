using System;

namespace Gradebook
{
    public class BookValidator
    {
        public static bool isBookTypeValid(string? bookType)
        {
            if (!string.IsNullOrEmpty(bookType) && !string.IsNullOrWhiteSpace(bookType))
            {
                try
                {
                    var bookTypeInt = int.Parse(bookType);
                    if (bookTypeInt >= 1 && bookTypeInt <= 2) return true;
                }
                catch (FormatException e) {}
            }
            return false;
        }

        public static bool isBookNameValid(string? bookName)
        {
            return !string.IsNullOrEmpty(bookName) && !string.IsNullOrWhiteSpace(bookName);
        }

        public static bool isGradeValid(string? grade)
        {
            if (!string.IsNullOrEmpty(grade) && !string.IsNullOrWhiteSpace(grade))
            {
                try
                {
                var gradeDouble = double.Parse(grade);
                return true;
                }
                catch (FormatException e) {}
            }
            return false;
        }
    }
}