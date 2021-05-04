using System;

namespace InventarioSystem{
    public interface IEquipamento : Item{
        int STR {get;}
        int AGI {get;}
        int DEX {get;}
        int LUK {get;}

        string bodyPart {get;}
        void BuffItem();
    }
}