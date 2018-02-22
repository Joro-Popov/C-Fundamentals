using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07._Directory_Traversal
{
    public class Startup
    {
        public static void Main()
        {
            var extensions = new Dictionary<string, List<string>>();
            string directoryToTraverse = "../../";

            List<string> allFiles = GetAllFiles(directoryToTraverse);

            GroupExtensions(extensions, allFiles);

            extensions = extensions
                .OrderByDescending(w => w.Value.Count)
                .ToDictionary(w => w.Key, w => w.Value);

            SaveResult(extensions);
        }
        public static List<string> GetAllFiles(string path)
        {
            Stack<string> stack = new Stack<string>();
            List<string> allfiles = new List<string>();

            string[] files;
            string[] directories;
            string dir;
            
            stack.Push(path);

            while (stack.Count > 0)
            {
                dir = stack.Pop();

                files = Directory.GetFiles(dir);
                foreach (string file in files)
                {
                    allfiles.Add(file);
                }

                directories = Directory.GetDirectories(dir);

                foreach (string directory in directories)
                {
                    stack.Push(directory);
                }
            }

            return allfiles;
        }
        public static void SaveResult(Dictionary<string, List<string>> extensions)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/report.txt";

            using (var writer = new StreamWriter(path))
            {
                foreach (var KVP in extensions)
                {
                    string extension = KVP.Key;
                    List<string> files = KVP.Value;

                    writer.WriteLine($".{extension}");

                    foreach (var file in files.OrderBy(w => w))
                    {
                        FileInfo f = new FileInfo(file);

                        writer.WriteLine($"--{file} - {f.Length}kb");
                    }
                }
            }
        }
        public static void GroupExtensions(Dictionary<string, List<string>> extensions, List<string> allFiles)
        {
            foreach (var file in allFiles)
            {
                string extension = Path.GetExtension(file);

                if (!extensions.ContainsKey(extension))
                {
                    extensions[extension] = new List<string>();
                }
                extensions[extension].Add(file);
            }
        }
    }
}
