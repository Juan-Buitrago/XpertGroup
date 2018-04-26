using System;
using System.Collections.Generic;
using System.IO;
using XpertGroup.Models;
using XpertGroup.Logic;

namespace XpertGroup
{
    class Program
    {
        const string pathDataFile = "./Files/EQUNOSBOVINOS.DAT";
        const string pathFile = "./Files";

        static void Main(string[] args)
        {
            System.Console.WriteLine("Prueba XpertGroup");
            List<Mammal> mammals = Bussines.GetFileContentByPath(pathDataFile);
            Bussines.FilterAndWriteFiles(mammals,pathFile);
            System.Console.WriteLine("Finalizando Prueba XpertGroup");
        }
    }
}
