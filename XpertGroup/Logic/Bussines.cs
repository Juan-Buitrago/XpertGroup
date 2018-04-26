using System;
using System.Collections.Generic;
using XpertGroup.Models;
using XpertGroup.Helpers;

namespace XpertGroup.Logic
{
    public class Bussines
    {
        private static Dictionary<string, MammalType> Rules = new Dictionary<string, MammalType>(){
            {"^b", MammalType.Bovine}
        };
            
        public static List<Mammal> GetFileContentByPath(string path){

            List<string> MammalsTxt = FileHelper.GetFileContentByPath(path);
            List<Mammal> MammaList = new List<Mammal>();

            foreach(string m in MammalsTxt){
                MammaList.Add(new Mammal(m,Rules));
            }
            return MammaList;
        }

        public static void FilterAndWriteFiles(List<Mammal> mammals,string path){

            List<Mammal> Bovines = mammals.FindAll((mammal) => mammal.type == MammalType.Bovine);
            List<Mammal> Equines = mammals.FindAll((mammal) => mammal.type == MammalType.Equine);
            WriteMammalFiles(Bovines, $"{path}/Bovine.txt");
            WriteMammalFiles(Equines, $"{path}/Equine.txt");
        }

        private static void WriteMammalFiles(List<Mammal> mammals, string pathFile){
            FileHelper.WriteFileForStringList(mammals, pathFile);
        }
    }
}
