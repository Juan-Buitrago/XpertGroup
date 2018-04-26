using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace XpertGroup.Models
{
    public class Mammal
    {
        public string name { get; set; }
        public MammalType type { get; set; }

        public Mammal(string name, Dictionary<string, MammalType> rulesType)
        {
            this.name = name;
            SetMammalType(rulesType);
        }

        private void SetMammalType(Dictionary<string, MammalType> rulesType)
        {
            try
            {
                foreach (var rule in rulesType)
                {
                    this.type = Regex.IsMatch(this.name, rule.Key) ? rule.Value : MammalType.Equine;
                }
            }
            catch (ArgumentNullException)
            {
                System.Console.WriteLine($"Oops, La regla establecida para el mamifero {this.name} no es permitida.");
            }
        }
    }
}
