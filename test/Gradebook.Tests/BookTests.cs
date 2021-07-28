using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact] //this is an attribute -  a little piece of data attached to the methods Test1
        public void BookCalculatesAnAverageGrade()
        {
            //Testing is split into 3 sections
            //Arrange section
            Book book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //act section
            var result = book.GetStatistics();
            
            //assert section
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1); //1 is the precision
            Assert.Equal(77.3, result.Low, 1);
        }
    }
}
