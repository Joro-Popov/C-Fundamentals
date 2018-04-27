using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            GraphicEditor editor = new GraphicEditor();

            IShape rectangle = new Rectangle();
            IShape square = new Square();
            IShape circle = new Circle();
            IShape triangle = new Triangle();

            Console.WriteLine(editor.DrawShape(rectangle));
            Console.WriteLine(editor.DrawShape(square));
            Console.WriteLine(editor.DrawShape(circle));
            Console.WriteLine(editor.DrawShape(triangle));
        }
    }
}
