using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XpertGroup.Models;

namespace XpertGroup.Helpers
{
    public class FileHelper
    {

        public static List<string> GetFileContentByPath(string path)
        {
            List<string> data = new List<string>();
            try
            {
                var file = new FileStream(path, FileMode.Open);

                using (StreamReader sr = new StreamReader(file))
                {
                    while (sr.Peek() >= 0)
                    {
                        data.Add(sr.ReadLine());
                    }
                }
            }
            catch (FileNotFoundException)
            {
                System.Console.Write("Oops, Ocurrio un problema al intentar acceder al archivo");
            }
            catch (Exception e)
            {
                System.Console.Write($"Oops, Ocurrio un problema: {e.Message}");
            }
            return data;
        }

        public static void WriteFileForStringList(List<Mammal> mammals, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                foreach (var mammal in mammals)
                {
                    string name = $"{mammal.name}\n";
                    fs.Write(Encoding.UTF8.GetBytes(name), 0, name.Length);
                }
            }
        }
    }
}
