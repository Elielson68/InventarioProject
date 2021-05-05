using System;

namespace InventarioSystem{
    public class FerreiroDeGuerreiro: IFerreiro{
        public IEquipamento criarHelmo(){
            return new HelmoGuerreiro();
        }
        public IEquipamento criarArmadura(){
            return new ArmaduraGuerreiro();
        }
    }
}