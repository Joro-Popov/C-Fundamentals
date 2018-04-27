using System;
using System.Collections.Generic;
using System.Text;

namespace CustomClassAttribute
{
    public class InfoAttribute : Attribute
    {
        public string Author { get; set; }
        public int Revision { get; set; }
        public string Description { get; set; }
        public string[] Reviewers { get; set; }
    }
}
