 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var type = typeof(HarvestingFields);

            var fields = type.GetFields(
                BindingFlags.NonPublic | 
                BindingFlags.Public |
                BindingFlags.Instance);
            
            string command;

            while ((command = Console.ReadLine()) != "HARVEST")
            {
                switch (command)
                {
                    case "protected": Print(fields.Where(f => f.IsFamily)); break;

                    case "private": Print(fields.Where(f => f.IsPrivate)); break;
                       
                    case "public": Print(fields.Where(f => f.IsPublic)); break;
                       
                    case "all": Print(fields); break;
                }
            }
        }
        private static void Print(IEnumerable<FieldInfo> collection)
        {
            foreach (FieldInfo field in collection)
            {
                string modifier = field.Attributes.ToString().ToLower();

                if (field.IsFamily)
                {
                    modifier = "protected";
                }

                Console.WriteLine($"{modifier} {field.FieldType.Name} {field.Name}");
            }
        }
    }
}
