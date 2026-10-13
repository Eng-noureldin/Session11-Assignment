using System;

namespace Assignment08.Section01
{
    public class BookFunctions
    {
        public static string GetTitle(Book B)
        {
            return B?.Title ?? "No Title";
        }

        public static string GetAuthors(Book B)
        {
            if (B?.Authors == null || B.Authors.Length == 0) return "No Authors";
            return string.Join(", ", B.Authors);
        }

        public static string GetPrice(Book B)
        {
            return B != null ? B.Price.ToString("C") : "$0.00";
        }
    }
}