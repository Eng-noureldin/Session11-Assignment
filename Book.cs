using System;

namespace Assignment08.Section01
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }

        // Constructor initializing all properties
        public Book(string _ISBN, string _Title, string[] _Authors, DateTime _PublicationDate, decimal _Price)
        {
            ISBN = _ISBN;
            Title = _Title;
            Authors = _Authors;
            PublicationDate = _PublicationDate;
            Price = _Price;
        }

        // Override ToString to return formatted book details
        public override string ToString()
        {
            string authorsStr = Authors != null ? string.Join(", ", Authors) : "None";
            return $"ISBN: {ISBN}, Title: {Title}, Authors: [{authorsStr}], Date: {PublicationDate:yyyy-MM-dd}, Price: {Price:C}";
        }
    }
}