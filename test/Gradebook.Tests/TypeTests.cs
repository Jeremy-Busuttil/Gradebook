using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Jeremy";
            var upper = MakeUppercase(name);

            Assert.Equal("Jeremy", name);
            Assert.Equal("JEREMY", upper);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void Test1(){
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact] //this is an attribute -  a little piece of data attached to the methods Test1
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact] //this is an attribute -  a little piece of data attached to the methods Test1
        public void TwoVariablesCanReferenceSameObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1; //we copy the POINTER value of book1 into book2, therefore changes done to book2 are done on book1 and vice versa

            Assert.Same(book1, book2); //both objects pointing at same object in memory
            Assert.True(Object.ReferenceEquals(book1, book2)); //tells us if they are the exact same reference
        }

        [Fact] //this is an attribute -  a little piece of data attached to the methods Test1
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name"); //ref is passing an argument by reference

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
