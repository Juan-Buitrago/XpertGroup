using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace XpertGroup.Models
{
    public class Mammal
    {
        public string name { get; set; }
        public MammalType type { get; set; }

        public Mammal(string name,Dictionary<string, MammalType> RulesType)
        {
            this.name = name;
            SetMammalType(RulesType);
        }

        private void SetMammalType(Dictionary<string, MammalType> RulesType){

            foreach(var rule in RulesType){

                this.type = Regex.IsMatch(this.name, rule.Key) ? rule.Value : MammalType.Equine;
            }
        }
    }
}
