using System;

namespace InventarioSystem{
    interface IFerreiro{
        IEquipamento criarHelmo();
        IEquipamento criarArmadura();
    }
}