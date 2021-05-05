using System;

namespace InventarioSystem{
    public class HelmoGuerreiro : IEquipamento
    {
        public int STR { get; private set; } = 6;
        public int AGI { get; private set; } = 3;
        public int DEX { get; private set; } = 4;
        public int LUK { get; private set; } = 5;
        public int Peso { get; private set; } = 9;
        public string Tipo { get; private set; } = "equipavel";
        public string bodyPart {get; private set;} = "Head";
        public string Nome{get; set;}
        public void BuffItem(){
            STR += 2;
        }


    }
}