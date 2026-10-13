using System;
using System.Collections.Generic;

namespace Assignment08.Section01
{
    // a. User-defined delegate with the same signature
    public delegate string BookDelegate(Book B);

    public class LibraryEngine
    {
        // Parameterized using user-defined delegate
        public static void ProcessBooks(List<Book> bList, BookDelegate fPtr)
        {
            if (bList == null || fPtr == null) return;

            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }

        // b. Parameterized using built-in Func<> delegate
        public static void ProcessBooks(List<Book> bList, Func<Book, string> fPtr)
        {
            if (bList == null || fPtr == null) return;

            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }
    }
}