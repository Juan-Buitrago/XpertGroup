using System;
using System.Collections.Generic;
using XpertGroup.Models;
using XpertGroup.Helpers;

namespace XpertGroup.Logic
{
    public class Bussines
    {
        private static Dictionary<string, MammalType> rules = new Dictionary<string, MammalType>(){
            {"^b", MammalType.Bovine}
        };
            
        public static List<Mammal> GetFileContentByPath(string path){

            List<string> contentList = FileHelper.GetFileContentByPath(path);
            List<Mammal> mammaList = new List<Mammal>();

            foreach(string txt in contentList){
                mammaList.Add(new Mammal(txt,rules));
            }
            return mammaList;
        }

        public static void FilterAndWriteFiles(List<Mammal> mammals,string path){

            try
            {
                List<Mammal> bovines = mammals.FindAll((mammal) => mammal.type == MammalType.Bovine);
                List<Mammal> equines = mammals.FindAll((mammal) => mammal.type == MammalType.Equine);
                WriteMammalFiles(bovines, $"{path}/Bovine.txt");
                WriteMammalFiles(equines, $"{path}/Equine.txt");

            }catch(ArgumentNullException){
                System.Console.WriteLine("Oops, Ocurrio un problema al intentar realizar un filtro por tipo de mamifero");
            }
        }

        private static void WriteMammalFiles(List<Mammal> mammals, string pathFile){
            FileHelper.WriteFileForStringList(mammals, pathFile);
        }
    }
}
