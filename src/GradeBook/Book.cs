using System;
using System.Collections.Generic;

namespace GradeBook
{
    //1 class per file
    public class Book
    {
        private List<double> grades;
        public string Name;

        public Book(string name)
        {
            grades = new List<double>();
            this.Name = name;
        } //this is known as a field

        public void AddLetterGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);   
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;             
            }
        }
        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"The {nameof(grade)} entered is invalid"); //nameof just prints the name of the variable so that we don't have to manially change it each time.
            }
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

            switch(result.Average)
            {
                case var d when d >= 90.0: //d takes the value of result.Average
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0: //d takes the value of result.Average
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0: //d takes the value of result.Average
                    result.Letter = 'C';
                    break;  
                case var d when d >= 60.0: //d takes the value of result.Average
                    result.Letter = 'D';
                    break;       
                default: //d takes the value of result.Average
                    result.Letter = 'F';
                    break;       
            }

            return result;
            // Console.WriteLine($"The average grade is {average:N3}"); //N3 = number with 3 decimal points - float formatting
            // Console.WriteLine($"The highest grade is {highGrade:N3}"); //N3 = number with 3 decimal points - float formatting
            // Console.WriteLine($"The lowest grade is {lowGrade:N3}"); //N3 = number with 3 decimal points - float formatting
        }
    }
}