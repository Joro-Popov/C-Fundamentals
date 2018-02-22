using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace _04.Copy_Binary_File
{
    public class StartUp
    {
        public static void Main()
        {
            using (var stream = new FileStream("image.jpg",FileMode.Open))
            {
                using (var destination = new FileStream("image-copy.jpg",FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        int readBytes = stream.Read(buffer, 0, buffer.Length);

                        if (readBytes == 0)
                        {
                            break;
                        }
                        destination.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
