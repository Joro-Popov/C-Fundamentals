using System;
using System.Collections.Generic;
using System.Linq;

public class Smartphone : ICallable, IBrowseble
{
    private IEnumerable<string> phoneNumbers;
    private IEnumerable<string> urls;

    public Smartphone(IEnumerable<string> phoneNumbers, IEnumerable<string> urls)
    {
        this.PhoneNumbers = phoneNumbers;
        this.URLs = urls;
    }

    public IEnumerable<string> URLs
    {
        get { return urls; }
        private set { this.urls = value; }
    }

    public IEnumerable<string> PhoneNumbers
    {
        get { return phoneNumbers; }
        set { this.phoneNumbers = value; }
    }

    public void Browse()
    {
        if (this.URLs.Count() == 0)
        {
            Console.WriteLine($"Browsing: !");
        }
        foreach (var url in this.URLs)
        {
            if (url.Any(u => char.IsDigit(u)))
            {
                Console.WriteLine("Invalid URL!");
            }
            else
            {
                Console.WriteLine($"Browsing: {url}!");
            }
        }
    }

    public void Call()
    {
        foreach (var number in this.PhoneNumbers)
        {
            if (number.Any(n => char.IsLetter(n)))
            {
                Console.WriteLine("Invalid number!");
            }
            else
            {
                Console.WriteLine($"Calling... {number}");
            }
        }
    }
}