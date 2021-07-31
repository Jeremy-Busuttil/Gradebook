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
            
            do
            {
                Console.WriteLine("Please enter a grade (q to quit)");
                var input = Console.ReadLine();
                if(input == "q")
                {
                    Console.WriteLine("The statistics will now be printed and the program will then exit.");
                    break;
                }else
                {
                    try
                    {
                        var grade = Double.Parse(input);
                        book.AddGrade(grade);
                    }catch(ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        // throw; this re-throws the current Exception
                    }catch(FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        // this executes when the code in the try block works and even when it doesnt.
                    }
                }
            }while(true);

            var stats = book.GetStatistics();
            
            Console.WriteLine($"The average grade is {stats.Average:N3}"); //N3 = number with 3 decimal points - float formatting
            Console.WriteLine($"The highest grade is {stats.High:N3}"); //N3 = number with 3 decimal points - float formatting
            Console.WriteLine($"The lowest grade is {stats.Low:N3}"); //N3 = number with 3 decimal points - float formatting
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }
    }
}
