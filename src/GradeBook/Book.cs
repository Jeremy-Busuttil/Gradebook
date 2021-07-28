using System;
using System.Collections.Generic;

namespace GradeBook
{
    //1 class per file
    public class Book
    {
        private List<double> grades;
        public string Name;

        public Book(string name){
            grades = new List<double>();
            this.Name = name;
        } //this is known as a field

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public Statistics GetStatistics(){
            Statistics result =  new Statistics();

            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach(double grade in grades){
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Average += grade;
            }

            result.Average /= grades.Count;

            return result;
            // Console.WriteLine($"The average grade is {average:N3}"); //N3 = number with 3 decimal points - float formatting
            // Console.WriteLine($"The highest grade is {highGrade:N3}"); //N3 = number with 3 decimal points - float formatting
            // Console.WriteLine($"The lowest grade is {lowGrade:N3}"); //N3 = number with 3 decimal points - float formatting
        }
    }
}