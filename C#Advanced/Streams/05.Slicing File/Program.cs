using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _05.Slicing_File
{
    public class StartUp
    {
        private const int bufferSize = 4096;

        public static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (var FileReader = new FileStream(sourceFile,FileMode.Open))
            {
                long pieceSize = (long)Math.Ceiling((double)FileReader.Length / parts);
                string extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);
               
                for (int i = 0; i < parts; i++)
                {
                    long currentPieceSize = 0;

                    if (destinationDirectory == string.Empty)
                    {
                        destinationDirectory = "./";
                    }

                    string currentPart = destinationDirectory + $"Part - {i}.{extension}";
                    
                    using (var FileWriter = new FileStream(currentPart,FileMode.Create))
                    {
                        byte[] buffer = new byte[bufferSize];

                        while (FileReader.Read(buffer,0,buffer.Length) == bufferSize)
                        {
                            FileWriter.Write(buffer, 0, bufferSize);
                            currentPieceSize += 4096;

                            if (currentPieceSize >= pieceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
        public static void Assemble(List<string> files, string destinationDirectory)
        {
            string extension = files[0].Substring(files[0].LastIndexOf('.') + 1);

            if (destinationDirectory == string.Empty)
            {
                destinationDirectory = "./";
            }

            if (!destinationDirectory.EndsWith("/"))
            {
                destinationDirectory += "/";
            }

            string assembledFIle = $"{destinationDirectory}Assembled.{extension}";

            using (var writer = new FileStream(assembledFIle,FileMode.Create))
            {
                byte[] buffer = new byte[bufferSize];

                foreach (var file in files)
                {
                    using (var reader = new FileStream(file,FileMode.Open))
                    {
                        while (reader.Read(buffer,0,bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                        }
                    }
                }
            }
        }
        public static void Main()
        {
            string sourceFile = "../Resources/sliceMe.mp4";
            string destination = "";
            int parts = 5;

            List<string> files = new List<string>()
            {
                "Part - 0.mp4",
                "Part - 1.mp4",
                "Part - 2.mp4",
                "Part - 3.mp4",
                "Part - 4.mp4",

            };
            
            Slice(sourceFile, destination, parts);
            Assemble(files, destination);
        }
    }
}
