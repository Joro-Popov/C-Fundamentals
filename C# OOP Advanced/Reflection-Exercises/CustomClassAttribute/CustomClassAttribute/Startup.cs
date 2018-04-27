using System;
using System.Linq;
using System.Reflection;

namespace CustomClassAttribute
{
    public class Startup
    {
        public static void Main()
        {
            var attributes = typeof(Weapon)
                    .GetCustomAttributes(typeof(InfoAttribute), false)
                    .OfType<InfoAttribute>()
                    .SingleOrDefault();

            while (true)
            {

                var attrProp = Console.ReadLine().Trim();

                if (attrProp == "END")
                    break;

                var output = string.Empty;

                switch (attrProp)
                {
                    case "Author":
                        output = $"Author: {attributes.Author}";
                        break;
                    case "Revision":
                        output = $"Revision: {attributes.Revision}";
                        break;
                    case "Description":
                        output = $"Class description: {attributes.Description}";
                        break;
                    case "Reviewers":
                        output = $"Reviewers: {string.Join(", ", attributes.Reviewers)}";
                        break;
                }

                Console.WriteLine(output);
            }
        }
    }

    [Info
       (Author = "Pesho",
       Description = "Used for C# OOP Advanced Course - Enumerations and Attributes.",
       Revision = 3,
       Reviewers = new string[] { "Pesho", "Svetlio" })]
    class Weapon { }
}
