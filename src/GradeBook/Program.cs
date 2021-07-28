using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        //method named Main
        static void Main(string[] args)
        {
            Book book = new Book("Scott's grade book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);

            var stats = book.GetStatistics();
            
            Console.WriteLine($"The average grade is {stats.Average:N3}"); //N3 = number with 3 decimal points - float formatting
            Console.WriteLine($"The highest grade is {stats.High:N3}"); //N3 = number with 3 decimal points - float formatting
            Console.WriteLine($"The lowest grade is {stats.Low:N3}"); //N3 = number with 3 decimal points - float formatting
        }
    }
}
