using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class GraphicEditor
    {
        public string DrawShape(IShape shape)
        {
            string result = $"I'm {shape.Type}";
            return result;
        }
    }
}
