namespace Book.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class Tests
    {
        Book book;
        string author;
        string bookName;

        [SetUp]
        //reusable arrangement
        public void ReusableCode()
        {
            author = "Stanislav Stoychev";
            bookName = "Unit Tests";

            book = new Book(author, bookName);
        }

        [Test]
        public void ConstructorCheck()
        {
            //act is in the set up in this case
            //asle check valid peoperties value
            //assertion
            Assert.AreEqual("Unit Tests", book.Author);
            Assert.AreEqual("Stanislav Stoychev", book.BookName);
            Assert.AreEqual(0, book.FootnoteCount);
        }

        [TestCase("")]
        [TestCase(null)]
        public void checkBookName(string bookNameProp)
        {
            //act and assertion
            Assert.Throws<ArgumentException>(() => new Book(bookNameProp, author));
        }

        [TestCase("")]
        [TestCase(null)]
        public void checkAuthorName(string authorNameProp)
        {
            //act and assertion
            Assert.Throws<ArgumentException>(() => new Book(bookName, authorNameProp));
        }

        [TestCase(7)]
        [TestCase(14)]
        public void AddFootnote_Valid(int footNoteNum)
        {
            //arrangement
            string text = "Footnote number 2";
            var expected = 1;

            //act
            book.AddFootnote(footNoteNum, text);

            //assert
            Assert.AreEqual(expected, book.FootnoteCount);
        }

        [Test]
        public void AddFootnote_Invalid()
        {
            //arrangement
            int footNoteNumber = 2;
            string text = "Footnote number 2 ";

            //act
            book.AddFootnote(footNoteNumber, text);

            //assert
            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(footNoteNumber, text + "different"));
        }

        [TestCase(6)]
        [TestCase(10)]
        public void FindFootnote_Valid(int listCount)
        {
            //arrangement
            int footNoteNumber = 4;
            int expectedResult = listCount;
            string text = "A";
            for (int i = 0; i < listCount; i++)
            {
                book.AddFootnote(i, text);
                text += "A";
            }

            //act and assert
            Assert.AreEqual(expectedResult, book.FootnoteCount);
        }

        [TestCase(6)]
        [TestCase(4)]
        public void FindFootnote_Invalid(int listCount)
        {
            //arrangement
            int footNoteNumber = 8;
            string text = "A";
            for (int i = 0; i < listCount; i++)
            {
                book.AddFootnote(i, text);
                text += "A";
            }

            //act and assert
            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(footNoteNumber));
        }

        [TestCase(2, "new text of footnote 2")]
        [TestCase(1, "new text for footnote 1")]
        public void AlterFootnote_Valid(int footNoteNum, string newText)
        {
            //arrangement
            book.AddFootnote(1, "Old text of footnote 1");
            book.AddFootnote(2, "Old text of footnote 2");
            book.AddFootnote(3, "Old text of footnote 3");

            //act
            book.AlterFootnote(footNoteNum, newText);

            //asseretion
            Assert.AreEqual($"Footnote #{footNoteNum}: {newText}", book.FindFootnote(footNoteNum));
        }

        [TestCase(5, "new text of footnote 5")]
        [TestCase(6, "new text for footnote 6")]
        public void AlterFootnote_Invalid(int footNoteNum, string newText)
        {
            //arrangement
            book.AddFootnote(1, "Old text of footnote 1");
            book.AddFootnote(2, "Old text of footnote 2");
            book.AddFootnote(3, "Old text of footnote 3");

            //act and assert

            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(footNoteNum, newText));
        }

    }
}