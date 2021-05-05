using System;

namespace InventarioSystem{
    public class ArmaduraGuerreiro : IEquipamento
    {
        public int STR { get; private set; } = 8;
        public int AGI { get; private set; } = 3;
        public int DEX { get; private set; } = 3;
        public int LUK { get; private set; } = 5;
        public int Peso { get; private set; } = 15;
        public string Tipo { get; private set; } = "equipavel";
        public string bodyPart {get; private set;} = "Body";
        public string Nome{get; set;}

        public void BuffItem(){
            STR += 3;
            AGI -= 1;
        }

    }
}