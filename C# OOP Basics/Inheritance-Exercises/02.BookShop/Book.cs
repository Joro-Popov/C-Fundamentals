using System;

public class Book
{
    private string title;
    private string author;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        Author = author;
        Title = title;
        Price = price;
    }

    protected virtual decimal Price
    {
        get
        {
            return price;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            price = value;
        }
    }

    protected string Author
    {
        get { return author; }
        set
        {
            if (value.Split().Length > 1 && char.IsDigit(value.Split()[1][0]))
            {
                throw new ArgumentException("Author not valid!");
            }
            author = value;
        }
    }

    protected string Title
    {
        get { return title; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            title = value;
        }
    }

    public override string ToString()
    {
        return $"Type: {GetType().Name}\r\n" +
               $"Title: {this.Title}\r\n" +
               $"Author: {this.Author}\r\n" +
               $"Price: {this.Price:f2}".TrimEnd();
    }
}