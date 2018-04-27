using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Library : IEnumerable<Book>
{
    private SortedSet<Book> books;

    public Library(params Book[] books)
    {
        this.books = new SortedSet<Book>(books, new BookComparator());
    }

    public IEnumerator<Book> GetEnumerator()
    {
        for (int i = 0; i < this.books.Count; i++)
        {
            yield return this.books.ElementAt(i);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    
}
